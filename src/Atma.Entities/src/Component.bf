using System;
namespace Atma
{
	public class Component
	{
		internal Entity _entity;
		internal bool _inComponentList = false;

		public Entity Entity => _entity;
		public Scene Scene => _entity?.Scene;

		protected IntegratorList Integrations = .();

		private bool _active;
		internal bool _track;

		public bool Active
		{
			get => _active == true;
			set => _active = value;
		}

		protected float2 Position => _entity.Position;
		protected float2 WorldPosition => _entity.WorldPosition;

		protected float Rotation => _entity.Rotation;
		protected float WorldRotation => _entity.WorldRotation;

		protected float2 Direction => float2.FromAngle(_entity.Rotation);
		protected float2 WorldDirection => float2.FromAngle(_entity.WorldRotation);

		protected this(bool active, bool track = false)
		{
			_active = active;
			_track = track;
		}

		public virtual void Added(Entity entity)
		{
			System.Diagnostics.Debug.Assert(_entity == null);
			_entity = entity;
		}

		public virtual void Removed(Entity entity)
		{
			System.Diagnostics.Debug.Assert(_entity == entity);
			_entity = null;
		}


		public virtual void Update() { }

		public virtual void FixedUpdate() { }

		public virtual void Inspect() { }

		public virtual void DebugRender() { }

		public virtual void Destroying() { }

		public virtual void Ready() { }

		public ~this()
		{
			Integrations.Dispose();
		}


	}
}
