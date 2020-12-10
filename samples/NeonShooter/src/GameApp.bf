/*using Atma.Math;
using Atma;
using System;
using System.Collections;
using Atma.Framework.Graphics.Images;
using System.Diagnostics;
using GameSim.Scenes;

namespace GameSim
{
	public class PlatformLayer
	{
		private PlatformLayer _instance;
		public PlatformLayer Instance => _instance;
		public this()
		{
			_instance = this;
		}

		public ~this()
		{
			_instance = null;
		}
	}

	public class GameApp : App
	{
		private Batch2D _defaultLayer ~ delete _;
		private Batch2D _uiLayer ~ delete _;
		private Camera2D _mainCamera ~ delete _;
		private Camera2D _uiCamera ~ delete _;
		private SpriteFont _font ~ delete _;
		private Atlas2 _atlas2 ~ delete _;
		private float[] _animationPlay ~ delete _;
		private bool _simulateGame = true;

		//private Screen _screen ~ delete _;

		private Scene2 _scene ~ delete _;


		public this(Platform platform, String title, int width, int height, WindowFlags flags = .None) : base(platform, title, width, height, flags)
		{
			Game = this;
			this.ForceFixedTimestep = false;
			this.Throttling = false;

			Game.Window.OnResize.Add(new (window) => _scene?.Resize(Window.RenderSize));
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			Shaders.[Friend]Init(Assets);

			DrawOld = _defaultLayer = new .(Graphics);
			UI = _uiLayer = new .(Graphics);

			Atlas = _atlas2 = new .(Assets);
			_atlas2.Add("main", "textures/shadow.aseprite");
			_atlas2.Add("tiles", "aseprite/edge/shadow.aseprite");
			_atlas2.Add("main", "aseprite/blob/dirtgrass.aseprite");
			_atlas2.Add("main", "aseprite/blob/hidden.aseprite");
			_atlas2.Add("tiles", "aseprite/dirt.aseprite");
			_atlas2.Add("tiles", "aseprite/dirtbase.aseprite");
			_atlas2.Add("tiles", "aseprite/sandbase.aseprite");
			_atlas2.Add("main", "aseprite/blob/zone.aseprite");

			// //_atlas2.Add("main", "aseprite/sprite/npc.aseprite");
			_atlas2.Add("main", "aseprite/item/workbench.aseprite");
			_atlas2.Add("main", "aseprite/bush.aseprite");
			_atlas2.Add("main", "aseprite/cherry.aseprite");
			_atlas2.Add("main", "aseprite/tree.aseprite");
			_atlas2.Add("tiles", "aseprite/water.aseprite");
			_atlas2.Add("tiles", "aseprite/test2.aseprite");
			_atlas2.Add("tiles", "aseprite/grass.aseprite");
			_atlas2.Add("tiles", "aseprite/wall.aseprite");
			_atlas2.Add("main", "textures/dust_run_strip8.aseprite");
			_atlas2.Add("main", "textures/dust_land_strip6.aseprite");
			_atlas2.Add("main", "textures/skeleton.aseprite");
			_atlas2.Add("main", "textures/sword.aseprite");
			_atlas2.Add("main", "textures/sword2.aseprite");
			_atlas2.Add("main", "textures/fade.aseprite");
			_atlas2.Add("main", "textures/cursor.aseprite");
			_atlas2.Add("main", "textures/dust_general_strip9.aseprite");
			_atlas2.Add("main", "textures/speck.aseprite");
			_atlas2.Add("main", "textures/grass.aseprite");
			_atlas2.Add("main", "textures/rocks.aseprite");
			_atlas2.Add("main", "textures/flowers.aseprite");
			_atlas2.Add("main", "textures/stumps.aseprite");

			_atlas2.Finalize();

			//_screen = new .(128, 128);

			_animationPlay = new float[_atlas2.Animations.Count];

			Log.Message("World gen started");
			var sw = scope Stopwatch();
			sw.Start();
			sw.Stop();
			Log.Message("World gen completed in {0}", sw.Elapsed);

			MainCamera = _mainCamera = new .(Window.RenderSize);

			UICamera = _uiCamera = new .(Window.RenderSize);
			UICamera.Viewport = .(40, 40, UICamera.Viewport.Width - 80, UICamera.Viewport.Height - 80);

			DefaultFont = _font = Assets.Load<SpriteFont>(@"fonts/PressStart2P.ttf");


			//_scene = new CameraTestScene(320, 180);
			//_scene = new DungeonGenScene(Window.RenderSize);
			//_scene = new WFCScene();
			//_scene = new MapGenScene();
			Scene = _scene= new GameScene();

			_scene.Init();

			_resolutions.Add(.(320, 180));
			_resolutions.Add(.(320, 320));
			_resolutions.Add(.(480, 270));
			_resolutions.Add(.(640, 480));
			_resolutions.Add(.(640, 640));
			_resolutions.Add(.(1024, 768));
			_resolutions.Add(.(1152, 864));
			_resolutions.Add(.(1176, 664));
			_resolutions.Add(.(1280, 960));
			_resolutions.Add(.(1280, 1280));
			_resolutions.Add(.(1360, 768));
			_resolutions.Add(.(1366, 768));
			_resolutions.Add(.(1440, 900));
			_resolutions.Add(.(1600, 900));
			_resolutions.Add(.(1600, 1024));
			_resolutions.Add(.(1680, 1050));
			_resolutions.Add(.(1920, 1080));

			let e = scope Emitter();
			e.AddObserver<CoreEvent.WindowResize>(new (window) => Log.Debug($"{window}"));
			e.Emit(CoreEvent.WindowResize(1,1));
			Log.Debug($"{CoreEvent.WindowResize(1,1)}");

			e.Signal();
		}

		protected override void Update()
		{
			/*Tile.tickCount++;
			_level.tick();*/

			_scene.Update();

			MainCamera.Update();

			base.Update();
		}

		private bool _inspectWindow = true;
		private float2 _position = float2.Zero;
		private float2 _targetPosition = float2.Zero;

		private List<int2> _resolutions = new .() ~ delete _;
		private bool fullScreen = false;
		private int2 currentSize = .(320, 180);

		protected override void Render()
		{
			DrawOld.Clear();
			_defaultLayer.Clear();
			_uiLayer.Clear();
			_defaultLayer.Rect(rect(0, 0, 1, 1), Color.Red);

			/*_screen.Clear();
			_screen.Render(Window, MainCamera, .Tiles, .TileFringe);*/

			UICamera.Render(Window, _uiLayer);

			Graphics.Clear(Window, Color.Black, 0, 0);

			_defaultLayer.Clear();

			if (ig.BeginCombo("Window Size", StackStringFormat!("{0}x{1}", Window.Size.x, Window.Size.y)))
			{
				for (var it in _resolutions)
					if (ig.Selectable(StackStringFormat!("{0}x{1}", it.x, it.y), Window.Size == it))
					{
						if (Window.Size != it)
						{
							Window.Size = it;
							currentSize = it;
							fullScreen = false;
						}
					}

				ig.EndCombo();
			}

			if (ig.Checkbox("Fullscreen", &fullScreen))
			{
				if (fullScreen)
				{
					Window.Fullscreen = true;
				}
				else
				{
					Window.Size = currentSize;
				}
			}

			_scene.Render();
			_scene.FinalizeRenderTarget(Window);
			_scene.Debug();

			ig.Text(StackStringFormat!("FPS: {0}", Time.FPS));
			ig.Text(StackStringFormat!("DrawCalls: {0}", this.Graphics.Metrics.DrawCalls));
			ig.Text(StackStringFormat!("Triangles: {0}", this.Graphics.Metrics.Triangles));

			if (ig.TreeNode("Atlas"))
			{
				if (ig.TreeNode("Textures"))
				{
					for (var kvp in Atlas.Subtextures)
					{
						if (kvp.key != null && kvp.value.Texture != null)
						{
							ig.Text(kvp.key);
							ig.Image(kvp.value);
						}
					}
					ig.TreePop();
				}

				if (ig.TreeNode("Animations"))
				{
					var i = 0;
					for (var kvp in Atlas.Animations)
					{
						_animationPlay[i] += Time.Delta;

						if (_animationPlay[i] > kvp.value.Duration)
							_animationPlay[i] -= kvp.value.Duration;

						ig.Text(kvp.key);
						ig.Image(kvp.value.GetTexture(_animationPlay[i]));
						i++;
					}
					ig.TreePop();
				}
				ig.TreePop();
			}

			DebugOptions.Draw();
		}
	}
}*/
