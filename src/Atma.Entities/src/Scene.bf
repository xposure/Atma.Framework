using System;
using System.Collections;
using internal Atma;

namespace Atma
{
	public class Scene
	{
		typealias FastList<T> = System.Collections.List<T>;


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

		public virtual void FixedUpdate()
		{
			// update our Entities
			Entities.FixedUpdate();

			// we update our renderables after entity.update in case any new Renderables were added
			RenderableComponents.UpdateLists();
		} protected internal virtual void Render()
		{
			Core.Graphics.Clear(Core.Window, Core.Graphics.ClearColor);

			//	Core.Graphics.Clear(Core.Window, .CornflowerBlue);
			for (var it in Entities.Components<Camera>())
				it.Render(this);

			/*if (_renderers.Count == 0)
			{
				Log.Debug("There are no Renderers in the Scene!");
				return;
			}*/

			/*// Renderers should always have those that require a RenderTarget first. They clear themselves and set
			// themselves as the current RenderTarget when they render. If the first Renderer wants the
			// sceneRenderTarget we set and clear it now.
			if (_renderers[0].WantsToRenderToSceneRenderTarget)
			{
				Core.GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
				Core.GraphicsDevice.Clear(ClearColor);
			}*/


			/*var lastRendererHadRenderTarget = false;
			for (var i = 0; i < _renderers.Count; i++)
			{
				// MonoGame follows the XNA implementation so it will clear the entire buffer if we change the render
				// target even if null. Because of that, we track when we are done with our RenderTargets and clear the
				// scene at that time.
				if (lastRendererHadRenderTarget && _renderers.Ptr[i].WantsToRenderToSceneRenderTarget)
				{
					Core.GraphicsDevice.SetRenderTarget(_sceneRenderTarget);
					Core.GraphicsDevice.Clear(ClearColor);

					// force a Camera matrix update to account for the new Viewport size
					if (_renderers.Ptr[i].Camera != null)
						_renderers.Ptr[i].Camera.ForceMatrixUpdate();
					Camera.ForceMatrixUpdate();
				}

				_renderers.Ptr[i].Render(this);
				lastRendererHadRenderTarget = _renderers.Ptr[i].RenderTexture != null;
			}*/
		}

		/*/// <summary>
		/// any PostProcessors present get to do their processing then we do the final render of the RenderTarget to the
		// screen. In almost all cases finalRenderTarget will be null. The only time it will have a value is the first
		// frame of a SceneTransition if the transition is requesting the render. </summary> <returns>The
		// render.</returns>
		internal void PostRender(RenderTarget finalRenderTarget = null)
		{
			/*var enabledCounter = 0;
			if (EnablePostProcessing)
			{
				for (var i = 0; i < _postProcessors.Count; i++)
				{
					if (_postProcessors.Ptr[i].Enabled)
					{
						var isEven = Mathf.IsEven(enabledCounter);
						enabledCounter++;

						var source = isEven ? _sceneRenderTarget : _destinationRenderTarget;
						var destination = !isEven ? _sceneRenderTarget : _destinationRenderTarget;
						_postProcessors.Ptr[i].Process(source, destination);
					}
				}
			}

			// deal with our Renderers that want to render after PostProcessors if we have any
			for (var i = 0; i < _afterPostProcessorRenderers.Length; i++)
			{
				if (i == 0)
				{
					// we need to set the proper RenderTarget here. We want the last one that was the destination of our
					// PostProcessors
					var currentRenderTarget = Mathf.IsEven(enabledCounter) ? _sceneRenderTarget :
		_destinationRenderTarget; Core.GraphicsDevice.SetRenderTarget(currentRenderTarget);
				}

				// force a Camera matrix update to account for the new Viewport size
				if (_afterPostProcessorRenderers.Ptr[i].Camera != null)
					_afterPostProcessorRenderers.Ptr[i].Camera.ForceMatrixUpdate();
				_afterPostProcessorRenderers.Ptr[i].Render(this);
			}

			// if we have a screenshot request deal with it before the final render to the backbuffer
			if (_screenshotRequestCallback != null)
			{
				var tex = new Texture2D(Core.GraphicsDevice, _sceneRenderTarget.Width, _sceneRenderTarget.Height);
				var data = new int[tex.Bounds.Width * tex.Bounds.Height];

				var currentRenderTarget = Mathf.IsEven(enabledCounter) ? _sceneRenderTarget : _destinationRenderTarget;
				currentRenderTarget.GetData(data);
				tex.SetData(data);
				_screenshotRequestCallback(tex);

				_screenshotRequestCallback = null;
			}

			// render our final result to the backbuffer or let our delegate do so
			if (_finalRenderDelegate != null)
			{
				var currentRenderTarget = Mathf.IsEven(enabledCounter) ? _sceneRenderTarget : _destinationRenderTarget;
				_finalRenderDelegate.HandleFinalRender(finalRenderTarget, LetterboxColor, currentRenderTarget,
		_finalRenderDestinationRect, SamplerState);
			}
			else
			{
				var currentRenderTarget = Mathf.IsEven(enabledCounter) ? _sceneRenderTarget : _destinationRenderTarget;
				Core.GraphicsDevice.SetRenderTarget(finalRenderTarget);
				Core.GraphicsDevice.Clear(LetterboxColor);

				Graphics.Instance.Batcher.Begin(BlendState.Opaque, SamplerState, null, null);
				Graphics.Instance.Batcher.Draw(currentRenderTarget, _finalRenderDestinationRect, Color.White);
				Graphics.Instance.Batcher.End();
			}*/
		}*/


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