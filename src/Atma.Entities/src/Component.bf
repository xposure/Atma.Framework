using System;
namespace Atma
{
	public class Component
	{
		internal Entity _entity;
		public Entity Entity => _entity;

		protected IntegratorList Integrations = .();

		public Scene Scene => _entity?.Scene;

		internal bool _inComponentList = false;

		private bool _active;

		public virtual bool Track => false;

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

		protected this(bool active)
		{
			Active = active;
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


		public virtual void Update()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void Inspect()
		{
		}

		public virtual void DebugRender()
		{
		}

		/*public virtual void Ready()
		{
		}*/

		public virtual void Destroying()
		{
		}

		public ~this()
		{
			Integrations.Dispose();
		}

		public virtual void Ready()
		{
		}


	}
}
