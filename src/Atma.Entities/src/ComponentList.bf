using System.Collections;
using System;
using internal Atma;

namespace Atma
{
	public struct ComponentList//: IDisposable
	{
		typealias ComponentState = (ComponentMode Mode, Component Component, IRenderableComponent Renderable);

		public enum ComponentMode
		{
			Added,
			Adding,
			Removing,
			Removed,
		}

		public enum LockMode
		{
			case Open;
			case Locked;
		}

		private Entity _entity;
		public Entity Entity => _entity;

		private List<ComponentState> _components;
		private LockMode _lockMode;

		protected EntityList EntityManager => _entity._entityList;
		internal aabb2? _renderBounds = null;

		public this(Entity entity)
		{
			_lockMode = .Open;
			_entity = entity;
			_components = new .();
		}

		public void Dispose() mut
		{
			Destroying();
		}

		private void SetLockMode(LockMode lockMode) mut
		{
			_lockMode = lockMode;
		}

		internal void InternalAdd(ref ComponentState item)
		{
			let component = item.Component;
			Assert.IsTrue(item.Mode == .Adding);

			item.Mode = .Added;
			component.Added(Entity);
			component._inComponentList = true;

			if (component._track)
				EntityManager?.AddComponentToEntity(component);
		}

		internal void InternalRemove(ref ComponentState item)
		{
			let component = item.Component;
			Assert.IsTrue(item.Mode == .Removing);

			item.Mode = .Removed;
			component.Removed(Entity);
			component._inComponentList = false;

			if (component._track)
				EntityManager?.RemoveComponentFromEntity(component);
		}

		public T Add<T>(T component) mut
			where T : Component
		{
			Assert.IsFalse(component._inComponentList);
			_components.Add((.Adding, component, component as IRenderableComponent));

			/*if (_lockMode == .Open)
				InternalAdd(ref _components.Back);*/

			return component;
		}

		private int GetComponentIndex(Component component)
		{
			for (var i < _components.Count)
				if (_components[i].Component == component)
					return i;

			return -1;
		}

		public void Remove(Component component) mut
		{
			Assert.IsTrue(component._inComponentList);

			let index = GetComponentIndex(component);
			Assert.IsTrue(index >= 0);

			_components[index].Mode = .Removing;

			/*if (_lockMode == .Open)
				InternalRemove(ref _components[index]);*/
		}

		public void Add(params Component[] components) mut
		{
			for (var component in components)
				Add(component);
		}

		public void Remove(params Component[] components) mut
		{
			for (var component in components)
				Remove(component);
		}

		public int Count => _components.Count;

		public Component this[int index]
		{
			get
			{
				System.Diagnostics.Debug.Assert(index >= 0 && index < _components.Count);
				return _components[index].Component;
			}
		}

		public ComponentEnumerator GetEnumerator() => ComponentEnumerator(_components);

		public struct ComponentEnumerator : IEnumerator<Component>
		{
			private int index = 0;
			private List<ComponentState> _items;

			public this(List<ComponentState> items)
			{
				_items = items;
			}

			public Result<Component> GetNext() mut
			{
				if (index >= _items.Count)
					return .Err;

				return .Ok(_items[index++].Component);
			}
		}

		internal void Update() mut
		{
			_renderBounds = null;
			var bounds = default(aabb2);

			SetLockMode(.Locked);
			for (var it in ref _components)
			{
				let component = it.Component;
				switch (it.Mode)
				{
				case .Adding:
					InternalAdd(ref it);
					fallthrough;//Allow a component added to run the same frame, bad?
				case .Added:
					if (component.Active)
					{
						component.Update();
					}

					if (it.Renderable?.Visible == true)
					{
						let other = it.Renderable.LocalBounds;
						if (bounds.Volume == 0)
							bounds = other;
						else
							bounds.Merge(other);
					}
				case .Removing:
					InternalRemove(ref it);
				case .Removed:
					@it.Remove();
				}
			}

			if (bounds.Volume != 0)
				_renderBounds = bounds;

			SetLockMode(.Open);
		}

		internal void Render(List<IRenderable> renderList)
		{
			for (var it in ref _components)
			{
				switch (it.Mode)
				{
				case .Adding:
				case .Removing:
				case .Removed:
				case .Added:
					if (it.Renderable?.Visible == true)
						renderList.Add(it.Renderable);
				}
			}
		}

		internal void FixedUpdate() mut
		{
			SetLockMode(.Locked);
			for (var it in ref _components)
			{
				let component = it.Component;
				switch (it.Mode)
				{
				case .Adding:
					InternalAdd(ref it);
					fallthrough;//Allow a component added to run the same frame, bad?
				case .Added:
					if (component.Active)
						component.FixedUpdate();
				case .Removing:
					InternalRemove(ref it);
				case .Removed:
					@it.Remove();
				}
			}
			SetLockMode(.Open);
		}

		public T Get<T>() where T : Component
		{
			for (var item in _components)
				if (var c = item.Component as T)
					return c;

			return null;
		}

		public void GetAll<T>(List<T> list) where T : Component
		{
			for (var item in _components)
				if (var it = item.Component as T)
					list.Add(it);
		}

		public void Destroying() mut
		{
			if (_components != null)
			{
				for (var it in ref _components)
				{
					if (it.Mode == .Added)
					{
						it.Mode = .Removing;
						InternalRemove(ref it);
					}

					it.Component.Destroying();
					delete it.Component;
				}

				delete _components;
				_components = null;
			}
		}

		public void Inspect()
		{
			for (var i < _components.Count)
			{
				let name = scope String();
				let type = _components[i].GetType();
				type.GetName(name);

				ImGui.PushID(&_components[i]);
				if (ImGui.CollapsingHeader(name))
				{
					_components[i].Component.Inspect();
				}
				ImGui.PopID();
			}
		}
	}
}
