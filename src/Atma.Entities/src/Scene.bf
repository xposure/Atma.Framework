using System;
using System.Collections;
using internal Atma;

namespace Atma
{
	public class Scene
	{
		typealias FastList<T> = System.Collections.List<T>;

		public readonly Assets Assets ~ delete _;

		/// <summary>
		/// default scene Camera
		/// </summary>
		public readonly Camera2D Camera ~ delete _;

		/// <summary>
		/// SamplerState used for the final draw of the RenderTarget to the framebuffer
		/// </summary>
		public TextureFilter SamplerState = Core.DefaultTextureFilter;

		/// <summary>
		/// Manages a list of all the RenderableComponents that are currently on scene Entitys
		/// </summary>
		public readonly RenderableComponentList RenderableComponents = new .() ~ delete _;

		/// <summary>
		/// The list of entities within this Scene
		/// </summary>
		public readonly EntityList Entities ~ delete _;


		public this(Camera2D.ResolutionPolicy resolutionPolicy, int2 designSize, int2 bleedSize = .Zero)
		{
			Entities = new EntityList(this);
			Assets = new .(Core.Assets);
			//TODO: Content = new NezContentManager();

			Camera = new .(resolutionPolicy, designSize, bleedSize);

			let mainCamera = CreateEntity("mainCamera");
			mainCamera.Components.Add(new Camera2DComponent(Camera));
			/*// setup our resolution policy. we'll commit it in begin
			_resolutionPolicy = _defaultSceneResolutionPolicy;
			_designResolutionSize = _defaultDesignResolutionSize;
			_designBleedSize = _defaultDesignBleedSize;*/
		}

		#region Scene lifecycle

		internal void InternalFixedUpdate()
		{
			// update our Entities
			Entities.FixedUpdate();

			// we update our renderables after entity.update in case any new Renderables were added
			RenderableComponents.UpdateLists();

			FixedUpdate();
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void Render()
		{
			Core.Graphics.Clear(Core.Window, Core.Graphics.ClearColor);

			for (var it in Entities.Components<Camera2DComponent>())
				it.Render();
		}
		#endregion


		#region Entity Management

		/// <summary>
		/// add the Entity to this Scene, and return it
		/// </summary>
		/// <returns></returns>
		public Entity CreateEntity(StringView name)
		{
			var entity = new Entity(name);
			return AddEntity(entity);
		}

		/// <summary>
		/// add the Entity to this Scene at position, and return it
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="name">Name.</param>
		/// <param name="position">Position.</param>
		public Entity CreateEntity(StringView name, float2 position)
		{
			var entity = new Entity(name);
			entity.Position = position;
			return AddEntity(entity);
		}

		/*/// <summary>
		/// adds an Entity to the Scene's Entities list
		/// </summary>
		/// <param name="entity">The Entity to add</param>
		public Entity AddEntity(Entity entity)
		{
			//Insist.IsFalse(Entities.Contains(entity), "You are attempting to add the same entity to a scene twice:
		{0}", entity); Entities.Add(entity); entity.Scene = this;

			for (var i = 0; i < entity.Transform.ChildCount; i++)
				AddEntity(entity.Transform.GetChild(i).Entity);

			return entity;
		}*/

		/// <summary>
		/// adds an Entity to the Scene's Entities list
		/// </summary>
		/// <param name="entity">The Entity to add</param>
		public T AddEntity<T>(T entity) where T : Entity
		{
			//Insist.IsFalse(Entities.Contains(entity), "You are attempting to add the same entity to a scene twice:
			// {0}", entity);
			Entities.Root.Add(entity);
			entity._entityList = Entities;
			//entity.[Friend]Scene = this;
			return entity;
		}

		/*/// <summary>
		/// removes all entities from the scene
		/// </summary>
		public void DestroyAllEntities()
		{
			for (var i = 0; i < Entities.Count; i++)
				Entities[i].Destroy();
		}*/

		/// <summary>
		/// searches for and returns the first Entity with name
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="name">Name.</param>
		public Entity FindEntity(StringView name) => Entities.Find(name);

		/*/// <summary>
		/// returns all entities with the given tag
		/// </summary>
		/// <returns>The entities by tag.</returns>
		/// <param name="tag">Tag.</param>
		public List<Entity> FindEntitiesWithTag(int tag) => Entities.EntitiesWithTag(tag);*/

		/// <summary>
		/// returns all entities of Type T
		/// </summary>
		/// <returns>The of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void EntitiesOfType<T>(List<T> list) where T : Entity
		{
			for (var it in Entities.FindByType<T>())
				list.Add(it);
		}

		/// <summary>
		/// returns the first enabled loaded component of Type T
		/// </summary>
		/// <returns>The component of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T FindComponentOfType<T>() where T : Component
		{
			for (var it in Entities.Components<T>())
				return it;

			return null;
		}

		/// <summary>
		/// returns a list of all enabled loaded components of Type T
		/// </summary>
		/// <returns>The components of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void FindComponentsOfType<T>(List<T> items) where T : Component
		{
			for (var it in Entities.Components<T>())
				items.Add(it);
		}

		#endregion


	}
}
