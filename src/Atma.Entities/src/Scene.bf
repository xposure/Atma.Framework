using System;
using System.Collections;
using internal Atma;

namespace Atma
{
	public class Scene
	{
		typealias FastList<T> = System.Collections.List<T>;

		public Assets Assets ~ delete _;

		/// <summary>
		/// default scene Camera
		/// </summary>
		public Camera Camera;

		/// <summary>
		/// SamplerState used for the final draw of the RenderTarget to the framebuffer
		/// </summary>
		public TextureFilter SamplerState = Core.DefaultTextureFilter;

		/// <summary>
		/// Scene-specific ContentManager. Use it to load up any resources that are needed only by this scene. If you
		// have global/multi-scene resources you can use Core.contentManager to load them since Nez will not ever unload
		// them. </summary>
		//public readonly NezContentManager Content;

		/// <summary>
		/// Manages a list of all the RenderableComponents that are currently on scene Entitys
		/// </summary>
		public readonly RenderableComponentList RenderableComponents = new .() ~ delete _;

		/// <summary>
		/// The list of entities within this Scene
		/// </summary>
		public readonly EntityList Entities ~ delete _;

		/*/// <summary>
		/// the final render to the screen can be deferred to this delegate if set. This is really only useful for cases
		// where the final render might need a full screen size effect even though a small back buffer is used. 
		// </summary> <value>The final render delegate.</value>
		public IFinalRenderDelegate FinalRenderDelegate
		{
			set
			{
				if (_finalRenderDelegate != null)
					_finalRenderDelegate.Unload();

				_finalRenderDelegate = value;

				if (_finalRenderDelegate != null)
					_finalRenderDelegate.OnAddedToScene(this);
			}
			get => _finalRenderDelegate;
		}

		IFinalRenderDelegate _finalRenderDelegate;*/



		bool _didSceneBegin;


		/*/// <summary>
		/// sets the default design size and resolution policy that new scenes will use. horizontal/verticalBleed are
		// only relevant for BestFit. </summary> <param name="width">Width.</param> <param name="height">Height.</param>
		//  <param name="sceneResolutionPolicy">Scene resolution policy.</param> <param
		// name="horizontalBleed">Horizontal bleed size. Used only if resolution policy is set to <see
		// cref="SceneResolutionPolicy.BestFit"/>.</param>  <param name="verticalBleed">Vertical bleed size. Used only
		// if resolution policy is set to <see cref="SceneResolutionPolicy.BestFit"/>.</param>
		public static void SetDefaultDesignResolution(int width, int height,
			SceneResolutionPolicy sceneResolutionPolicy,
			int horizontalBleed = 0, int verticalBleed = 0)
		{
			_defaultDesignResolutionSize = int2(width, height);
			_defaultSceneResolutionPolicy = sceneResolutionPolicy;
			if (_defaultSceneResolutionPolicy == SceneResolutionPolicy.BestFit)
				_defaultDesignBleedSize = int2(horizontalBleed, verticalBleed);
		}*/


		/*#region Scene creation helpers

		/// <summary>
		/// helper that creates a scene with the DefaultRenderer attached and ready for use
		/// </summary>
		/// <returns>The with default renderer.</returns>
		public static Scene CreateWithDefaultRenderer(Color? clearColor = null)
		{
			var scene = new Scene();

			if (clearColor.HasValue)
				scene.ClearColor = clearColor.Value;
			scene.AddRenderer(new DefaultRenderer());
			return scene;
		}


		#endregion*/


		public this()
		{
			Entities = new EntityList(this);
			Assets = new .(Core.Assets);
			//TODO: Content = new NezContentManager();

			var cameraEntity = CreateEntity("camera");
			Camera = cameraEntity.Components.Add(new Camera(.ExactFit, .(Screen.Width, Screen.Height), .Zero));

			/*// setup our resolution policy. we'll commit it in begin
			_resolutionPolicy = _defaultSceneResolutionPolicy;
			_designResolutionSize = _defaultDesignResolutionSize;
			_designBleedSize = _defaultDesignBleedSize;*/
		}


		#region Scene lifecycle

		/// <summary>	
		/// override this in Scene subclasses and do your loading here. This is called from the contructor after the
		// scene sets itself up but before begin is ever called. </summary>
		public virtual void Initialize()
		{
		}

		/// <summary>
		/// override this in Scene subclasses. this will be called when Core sets this scene as the active scene.
		/// </summary>
		public virtual void OnStart()
		{
		}

		/// <summary>
		/// override this in Scene subclasses and do any unloading necessary here. this is called when Core removes this
		// scene from the active slot. </summary>
		public virtual void Unload()
		{
		}

		internal void Begin()
		{
			//Physics.Reset();
			_didSceneBegin = true;
			OnStart();
		}

		internal void End()
		{
			_didSceneBegin = false;


			//Physics.Clear();

			Unload();
		}

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

		protected internal virtual void Render()
		{
			Core.Graphics.Clear(Core.Window, Core.Graphics.ClearColor);

			for (var it in Entities.Components<Camera>())
				it.Render(this);
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

	/*public abstract class Scene2
	{
		public EntityList Entities = new .(this) ~ delete _;

		public abstract void Init();
		public abstract void Update();
		public abstract void Render();
		public abstract bool HandleInput();
		public abstract void FinalizeRenderTarget(RenderTarget window);
		public virtual bool TransitionOut() => true;
		public virtual bool TransitionIn() => true;
		public virtual void Resize(int2 size) { }
		public virtual void Debug() { }
	}*/
}
