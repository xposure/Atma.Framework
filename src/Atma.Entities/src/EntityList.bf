using System.Collections;
using System;
using internal Atma;

namespace Atma
{
	public class EntityList
	{
		public readonly Scene Scene;

		private Dictionary<Type, List<Entity>> _entityByTypes = new .() ~ DeleteDictionaryAndItems!(_);
		private Dictionary<Type, List<Component>> _entityByComponents = new .() ~ DeleteDictionaryAndItems!(_);
		private Dictionary<Type, List<Entity>> _entityByInterfaces = new .() ~ DeleteDictionaryAndItems!(_);

		
		private HashSet<uint64> _activeEntities = new .() ~ delete _;
		private List<Entity> __entities = new .() ~ delete _;
		private List<Entity> _removeEntities = new .() ~ delete _;
		private List<Entity> _destroyEntities = new .() ~ delete _;
		private Entity _root = new .("Root") ~ delete _;
		private List<Entity> _addedEntities = new .() ~ DeleteContainerAndItems!(_);

		public int Count => __entities.Count;

		public Entity Root => _root;

		public this(Scene scene)
		{
			Scene = scene;
			_root.[Friend]_entityList = this;
		}

		public T SceneAs<T>() where T : Scene
		{
			return Scene as T;
		}

		internal void AddComponentToEntity(Component component)
		{
			let type = component.GetType();
			if (_entityByComponents.TryAdd(type, ?, var ptr))
				*ptr = new .();

			let list = *ptr;
			list.Add(component);
		}

		internal void RemoveComponentFromEntity(Component component)
		{
			let type = component.GetType();
			if (!_entityByComponents.TryGet(type, ?, let list))
				Runtime.FatalError("Component not found.");

			list.RemoveFast(component);
		}

		internal void Add(Entity entity)
		{
			_addedEntities.Add(entity);
		}

		internal void Remove(Entity entity)
		{
			_removeEntities.Add(entity);
		}

		internal void Destroy(Entity entity)
		{
			_destroyEntities.Add(entity);
		}

		private void InternalUpdate()
		{
			for (var it in _removeEntities)
				it.[Friend]RemoveSelfInternal();
			_removeEntities.Clear();

			for (var it in _destroyEntities)
				it.[Friend]RemoveSelfInternal();

			for (var it in _destroyEntities)
				it.[Friend]Destroyed();

			for (var it in _destroyEntities)
			{
				let type = it.GetType();
				if (!_entityByTypes.TryGet(type, ?, var ptr))
					Runtime.FatalError("Entity by type didn't exist!");

				ptr.RemoveFast(it);
				_activeEntities.Remove(it.ID);
				__entities.RemoveFast(it);
			}

			DeleteAndClearItems!(_destroyEntities);

			let entityIndex = __entities.Count;
			for (var it in _addedEntities)
			{
				it.[Friend]AddSelfInternal();
				let type = it.GetType();
				if (_entityByTypes.TryAdd(type, ?, var ptr))
					*ptr = new .();

				(*ptr).Add(it);

				__entities.Add(it);
				_activeEntities.Add(it.ID);
			}

			_addedEntities.Clear();

			for (var i = entityIndex; i < __entities.Count; i++)
				__entities[i].Ready();
		}

		public void FixedUpdate()
		{
			InternalUpdate();
			_root.FixedUpdate();
		}

		public void Update()
		{
			InternalUpdate();
			_root.Update();
		}

		public Entity Find(StringView name)
		{
			for (var it in __entities)
				if (it.[Friend]_name == name)
					return it;

			return null;
		}

		public Entity.EntityChildEnumerator GetEnumerator() => .(Root);

		public T FindFirstByType<T>()
			where T : Entity
		{
			for (var it in Root.FindType<T>())
				return it;

			return null;
		}

		public void FindByType<T>(List<T> output)
			where T : Entity
		{
			for (var it in FindByType<T>())
				output.Add(it);
		}

		public Entity.EntityChildTypeEnumerator<T> FindByType<T>()
			where T : Entity
		{
			return .(Root);
		}

		public bool IsDestroyed(uint64 entityId) => !_activeEntities.Contains(entityId);
		public bool IsValid(uint64 entityId) => _activeEntities.Contains(entityId);

		public struct EntityEnumerator<T> : IEnumerator<T>
			where T : Entity
		{
			private List<Entity> _entities;
			private int index = 0;

			public this(List<Entity> entities)
			{
				_entities = entities;
			}

			public Result<T> GetNext() mut
			{
				while (index < _entities.Count)
					if (let t = _entities[index++] as T)
						return .Ok(t);

				return .Err;
			}
		}

		public InterfaceEnumerator<T> FindByInterface<T>()
		{
			if (_entityByInterfaces.TryGet(typeof(T), ?, let list))
				return .(list);

			return .(null);
		}

		public struct InterfaceEnumerator<T> : IEnumerator<T>
		{
			private List<Entity> _entities;
			private List<Entity>.Enumerator _enumerator;

			public this(List<Entity> entities)
			{
				_entities = entities;
				_enumerator = entities != null ? entities.GetEnumerator() : default;
			}

			public Result<T> GetNext() mut
			{
				if (_entities == null)
					return .Err;

				switch (_enumerator.GetNext()) {
				case .Ok(let val): return .Ok((T)(Object)val);
				case .Err: return .Err;
				}
			}
		}

		internal void RegisterInterface(Type type, Entity entity)
		{
			if (_entityByInterfaces.TryAdd(type, ?, var ptr))
				*ptr = new .();

			let list = *ptr;
			list.Add(entity);
		}

		internal void UnRegisterInterface(Type type, Entity entity)
		{
			if (_entityByInterfaces.TryAdd(type, ?, var ptr))
				Runtime.FatalError("Type was not registered!");

			let list = *ptr;
			list.RemoveFast(entity);
		}

		public ComponentEnumerator<T> Components<T>()
			where T : Component
		{
			if (_entityByComponents.TryGet(typeof(T), ?, let list))
				return .(list);

			return .(null);
		}

		public struct ComponentEnumerator<T> : IEnumerator<T>
			where T : Component
		{
			private List<Component> _components;
			private List<Component>.Enumerator _enumerator;

			public this(List<Component> components)
			{
				_components = components;
				_enumerator = components != null ? components.GetEnumerator() : default;
			}

			public Result<T> GetNext() mut
			{
				if (_components == null)
					return .Err;

				switch (_enumerator.GetNext()) {
				case .Ok(let val): return .Ok((T)val);
				case .Err: return .Err;
				}
			}
		}

		public void Filter<T, K>(List<T> list, K dlg) where K : delegate bool(T t)
			where T : Entity
		{
			for (var it in FindByType<T>())
				if (dlg(it))
					list.Add(it);
		}
	}
}
