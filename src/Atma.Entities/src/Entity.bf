using System.Collections;
using System;
using internal Atma;

namespace Atma
{
	public class Entity
	{
		private static uint64 _nextid = 0;
		public readonly uint64 ID = ++_nextid;

		public enum WorldSpace
		{
			case Local = 0;
			case World = 1;
		}

		public enum PositionLock
		{
			case Unlocked;
			case Locked;
		}

		public float Depth;

		private List<Entity> _entities = new .() ~ DeleteContainerAndItems!(_);
		private List<Type> _registeredInterfaces ~ delete _;
		protected IntegratorList Integrations = .();

		internal EntityList _entityList;
		public EntityList EntityList => _entityList;

		private String _name = new .() ~ delete _;
		private Entity _parent;
		public Entity Parent => _parent;
		public bool HasParent => _parent != null;

		private ComponentList _components ~ Release(_);

		public ref ComponentList Components => ref _components;

		private float2* _localPosition;
		private float2 _worldPosition = float2.Zero;
		private PositionLock _positionLock = .Unlocked;

		private float* _localRotation;
		private float _worldRotation = 0;

		private bool _destroying = false;
		public bool IsDestroying => _destroying;

		private bool _registered = false;
		public WorldSpace WorldSpace = .Local;

		public bool Visible = true;

		public float2 Forward => Calc.Turn(WorldRotation);
		public float2 Right => -Forward.Perpendicular;
		public float2 Left => Forward.Perpendicular;
		public float2 Backward => -Forward;

		public ref float2 Position => ref *_localPosition;

		public float2 WorldPosition => Position + _worldPosition;

		public ref float Rotation
		{
			get => ref *_localRotation;
			set
			{
				/*if (Math.Abs(Rotation - value) > 0.5f)
					_localRotation = 1f - value;
				else*/
				*_localRotation = value;
			}
		}

		public float WorldRotation => (Rotation + _worldRotation);

		public ~this()
		{
			Destroy();
		}

		public this() : this(scope $"Entity {ID}") { }
		public this(StringView name)
		{
			_name.Set(name);
			_components = .(this);

			let types = scope List<Type>();
			types.Add(this.GetType());

			while (types.Count > 0)
			{
				let type = types.PopBack();
				if (type == null || type == typeof(Object))
					continue;

				types.Add(type.BaseType);
				for (var it in type.Interfaces)
				{
					if (_registeredInterfaces == null)
						_registeredInterfaces = new .();
					_registeredInterfaces.Add(it);
					let interfaceName = scope String();
					it.GetName(interfaceName);
					Log.Debug("Registering type [{0}]", interfaceName);
				}
			}

			Integrations.Add(out _localPosition);
			Integrations.AddTurn(out _localRotation);
		}

		private void UpdateFromParent()
		{
			if (_parent != null && WorldSpace == .Local)
			{
				_worldPosition = _parent.WorldPosition;
				_worldRotation = _parent.WorldRotation;
			}
		}

		public void FixedUpdate()
		{
			if (!Enabled)
				return;

			UpdateFromParent();

			_components.FixedUpdate();

			OnFixedUpdate();

			_positionLock = .Locked;
			for (var it in _entities)
				it.FixedUpdate();
			_positionLock = .Unlocked;
		}

		protected virtual void OnFixedUpdate() { }

		public T AddRoot<T>(T entity)
			where T : Entity
		{
			_entityList.Root.Add(entity);
			return entity;
		}

		public T Add<T>(T entity)
			where T : Entity
		{
			System.Diagnostics.Debug.Assert(entity._parent == null);
			entity._parent = this;

			if (_entityList != null)
			{
				entity._entityList = _entityList;
				_entityList.[Friend]Add(entity);
			}
			else
			{
				_entities.Add(entity);
			}

			return entity;
		}

		internal void AddInternal(Entity entity)
		{
			_entities.Add(entity);
			entity.Register();
			Added(entity);
		}

		private void Register()
		{
			if (_registeredInterfaces != null && !_registered)
			{
				_registered = true;
				for (var it in _registeredInterfaces)
					_entityList.RegisterInterface(it, this);
			}
		}

		private void Unregister()
		{
			if (_registeredInterfaces != null && _registered)
			{
				_registered = false;
				for (var it in _registeredInterfaces)
					_entityList.UnRegisterInterface(it, this);
			}
		}

		internal void AddSelfInternal()
		{
			_parent.AddInternal(this);

			//We need to walk all our children and update them
			//this can happen when child entities are added in the ctor
			SetEntityList(_entityList);
		}

		private void SetEntityList(EntityList entityList)
		{
			_entityList = entityList;
			for (var it in _entities)
				it.SetEntityList(entityList);
		}

		public virtual void Remove(Entity entity)
		{
			Unregister();

			_entityList.Remove(entity);
		}

		internal void RemoveInternal(Entity entity)
		{
			Removed(entity);
			_entities.Remove(entity);
			entity._parent = null;

			if (_registeredInterfaces != null)
				for (var it in _registeredInterfaces)
					_entityList.UnRegisterInterface(it, this);
		}

		internal void RemoveSelfInternal()
		{
			_parent?.RemoveInternal(this);
		}

		public void RemoveSelf()
		{
			System.Diagnostics.Debug.Assert(_parent != null);
			_parent.Remove(this);
		}

		protected virtual void Added(Entity entity) { }
		protected virtual void Removed(Entity entity) { }


		public void Destroy()
		{
			if (!_destroying)
			{
				_destroying = true;

				Integrations.Dispose();

				Unregister();
				_entityList.[Friend]Destroy(this);
				Destroying();

				Components.Destroying();
			}
		}

		protected virtual void Destroying() { }

		protected virtual void Destroyed() { }

		public virtual void DebugRender()
		{
			for (var it in _components)
				it.DebugRender();
		}

		public bool Enabled = true;
		public Scene Scene => _entityList.Scene;

		public List<Entity>.Enumerator Children => _entities.GetEnumerator();

		[Inline]
		public void Find<T>(T dlg) where T : delegate bool(Entity e)
		{
			FindInternal<T>(dlg);
		}

		[Inline]
		private bool FindInternal<T>(T dlg) where T : delegate bool(Entity e)
		{
			for (var it in _entities)
				if (dlg(it))
					return true;

			return false;
		}


		[Inline]
		public void FindAll<T>(T dlg) where T : delegate bool(Entity e)
		{
			if (FindInternal<T>(dlg))
				return;

			for (var it in _entities)
				if (it.FindInternal<T>(dlg))
					return;
		}

		public void Find<T>(List<T> list) where T : Entity
		{
			for (var it in _entities)
				if (let e = it as T)
					list.Add(e);
		}

		public void FindAll<T>(List<T> list) where T : Entity
		{
			Find(list);

			for (var it in _entities)
				it.FindAll(list);
		}

		protected virtual void OnInspect() { }

		protected virtual void OnReady() { }

		public void Ready()
		{
			for (var it in _components)
				it.Ready();

			//We need to walk the child entities and ready them
			//this can happen when child entities are added in a ctor
			for (var it in _entities)
				it.Ready();

			OnReady();
		}

		public void MoveRelative(float2 amount)
		{
			Position += amount;
		}

		public void Inspect()
		{
			UpdateFromParent();

			if (!Core.DebugRenderEnabled)
				DebugRender();

			if (ImGui.Begin(_name))
			{
				if (ImGui.CollapsingHeader("Transform"))
				{
					ImGui.SliderFloat2("Position", _localPosition.values, -1000, 1000);
					ImGui.SliderFloat("Rotation", _localRotation, -1, 1);
				}

				Components.Inspect();
				ImGui.End();
			}
		}

		private bool _inspectComponents = false;
	}
}




/*using GameSim.Levels;
using System;
namespace GameSim.Entities
{
	public class Entity
	{
		protected readonly Random random = new Random();
		public int x, y;
		public int xr = 6;
		public int yr = 6;
		public bool removed;
		public Level level;

		public virtual void render(Screen screen)
		{
		}

		public virtual void tick()
		{
		}

		public virtual void remove()
		{
			removed = true;
		}

		public virtual void init(Level level)
		{
			this.level = level;
		}

		public virtual bool intersects(int x0, int y0, int x1, int y1)
		{
			return !(x + xr < x0 || y + yr < y0 || x - xr > x1 || y - yr > y1);
		}

		public virtual bool blocks(Entity e)
		{
			return false;
		}

		public virtual void hurt(Mob mob, int dmg, int attackDir)
		{
		}

		public virtual void hurt(Tile tile, int x, int y, int dmg)
		{
		}

		public virtual bool move(int xa, int ya)
		{
			if (xa != 0 || ya != 0)
			{
				bool stopped = true;
				if (xa != 0 && move2(xa, 0)) stopped = false;
				if (ya != 0 && move2(0, ya)) stopped = false;
				if (!stopped)
				{
					int xt = x >> 4;
					int yt = y >> 4;
					level.getTile(xt, yt).steppedOn(level, xt, yt, this);
				}
				return !stopped;
			}
			return true;
		}

		protected virtual bool move2(int xa, int ya)
		{
			if (xa != 0 && ya != 0) throw new InvalidOperationException("Move2 can only move along one axis at a
time!");

			int xto0 = ((x) - xr) >> 4;
			int yto0 = ((y) - yr) >> 4;
			int xto1 = ((x) + xr) >> 4;
			int yto1 = ((y) + yr) >> 4;

			int xt0 = ((x + xa) - xr) >> 4;
			int yt0 = ((y + ya) - yr) >> 4;
			int xt1 = ((x + xa) + xr) >> 4;
			int yt1 = ((y + ya) + yr) >> 4;
			bool blocked = false;
			for (int yt = yt0; yt <= yt1; yt++)
				for (int xt = xt0; xt <= xt1; xt++)
				{
					if (xt >= xto0 && xt <= xto1 && yt >= yto0 && yt <= yto1) continue;
					level.getTile(xt, yt).bumpedInto(level, xt, yt, this);
					if (!level.getTile(xt, yt).mayPass(level, xt, yt, this))
					{
						blocked = true;
						return false;
					}
				}
			if (blocked) return false;

			List<Entity> wasInside = level.getEntities(x - xr, y - yr, x + xr, y + yr);
			List<Entity> isInside = level.getEntities(x + xa - xr, y + ya - yr, x + xa + xr, y + ya + yr);
			for (int i = 0; i < isInside.Count; i++)
			{
				Entity e = isInside[i];
				if (e == this) continue;

				e.touchedBy(this);
			}
			isInside.removeAll(wasInside);
			for (int i = 0; i < isInside.Count; i++)
			{
				Entity e = isInside.get(i);
				if (e == this) continue;

				if (e.blocks(this))
				{
					return false;
				}
			}

			x += xa;
			y += ya;
			return true;
		}

		//TODO: was protected
		public virtual void touchedBy(Entity entity)
		{
		}

		public virtual bool isBlockableBy(Mob mob)
		{
			return true;
		}

		public virtual void touchItem(ItemEntity itemEntity)
		{
		}

		public virtual bool canSwim()
		{
			return false;
		}

		public virtual bool interact(Player player, Item item, int attackDir)
		{
			return item.interact(player, this, attackDir);
		}

		public virtual bool use(Player player, int attackDir)
		{
			return false;
		}

		public virtual int getLightRadius()
		{
			return 0;
		}
	}
}*/
