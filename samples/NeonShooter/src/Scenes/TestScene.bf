using Atma;
using NeonShooter.Entities;
using NeonShooter.Components;
using System;
using NeonShooter.PostProcessors;
using NeonShooter.PostEffects;
using System.Collections;
namespace NeonShooter.Scenes
{
	public class TestScene : Scene
	{
		public ParticleManager<ParticleState> Particles;
		public GridComponent Grid;

		private Texture texture;
		private Sprite sprite;
		private Player player;

		public override void Initialize()
		{
			base.Initialize();
			Time.SetTargetFramerate(60);

			Particles = new .(new => ParticleState.UpdateParticle);

			const int maxGridPoints = 1600;
			let gridSpacing = float2((float)Math.Sqrt(Screen.Width * Screen.Height / maxGridPoints));
			Grid = new .(.(0, 0, Screen.Width, Screen.Height), gridSpacing);

			CreateEntity("grid").Components.Add(Grid);
			CreateEntity("particles").Components.Add(Particles);

			Core.DefaultFont = Core.Assets.LoadFont(@"fonts/PressStart2P.ttf", 16);

			this.Camera.AddRenderer(new DefaultRenderer() { BlendMode = .Add });
			Core.Atlas.AddDirectory("main", "textures");
			Core.Atlas.Finalize();

			Core.Graphics.ClearColor = .Black;
			Camera.ClearColor = .(0, 0, 0, 255);
			//Camera.Origin = .(0.5f, 0.5f);

			/*Camera.AddPostProcessor(new PostProcessor<BloomExtractEffect>());
			Camera.AddPostProcessor(new PostProcessor<GaussianBlurEffect>());*/
			Camera.AddPostProcessor(new Bloom());
			Camera.AddPostProcessor(new Vignette());

			//AddEntity(new Entity("test")).Components.Add(new RectComponent());


			player = AddEntity(new Player());
			player.Components.Add(new PlayerCamera());
			player.Position = Screen.Size / 2;


			//hdrMaterial = new .(Shaders.HDR);
			/*let minimap = CreateEntity("Minimap");
			let minimapCamera = minimap.Components.Add(new Camera(.ExactFit, .(100, 100), .Zero));
			minimapCamera.RenderLayer1 = 1;
			minimapCamera.Viewport = .FromDimensions(.(400,400), .(100,100));

			let entity2 = CreateEntity("Test2");
			let sprite2 = entity2.Components.Add(new Sprite(.(texture)));
			sprite2.SetRenderLayer(1);*/
			Camera.SetDesignResolution(Screen.Width, Screen.Height, .ExactFit, 0, 0);
		}

		public override void FixedUpdate()
		{
			HandleCollisions();
			HandleEnemySpawn();

			base.FixedUpdate();
		}

		float inverseSpawnChance = 60;
		float inverseBlackHoleChance = 600;
		int blackHoleCount = 0;

		private void HandleEnemySpawn()
		{
			if (!player.IsDead && Entities.Count < 200)
			{
				if (gRand.Next((int)inverseSpawnChance) == 0)
					AddEntity(new Seeker(GetSpawnPosition()));

				if (gRand.Next((int)inverseSpawnChance) == 0)
					AddEntity(new Wanderer(GetSpawnPosition()));

				if (blackHoleCount < 2 && gRand.Next((int)inverseBlackHoleChance) == 0)
					AddEntity(new BlackHole(GetSpawnPosition()));

			// slowly increase the spawn rate as time progresses
				if (inverseSpawnChance > 20)
					inverseSpawnChance -= 0.005f;
			}
		}

		private float2 GetSpawnPosition()
		{
			float2 pos = ?;
			repeat
			{
				pos = float2(gRand.Next((int)Screen.Size.width), gRand.Next((int)Screen.Size.height));
			}
			while (glm.LengthSqr(pos - player.WorldPosition) < 250 * 250);

			return pos;
		}

		public void Reset()
		{
			inverseSpawnChance = 60;
		}

		protected override void Render()
		{
			base.Render();

			let status = player.status;
			if (status.IsGameOver)
			{
				let text = scope $"Game Over\nYour Score: {status.Score}\nHigh Score: {status.HighScore}";

				float2 textSize = Core.DefaultFont.MeasureString(text);
				Core.Draw.Text(Core.DefaultFont, Screen.Size / 2 - textSize / 2, text, Color.White);
			}
			else
			{
				Core.Draw.Text(Core.DefaultFont, float2(5), scope $"Lives: {status.Lives}", Color.White);
				DrawRightAlignedString(scope $"Score: {status.Score}", 5);
				DrawRightAlignedString(scope $"Multiplier: {status.Multiplier}", 35);
			}

			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		private void DrawRightAlignedString(StringView text, float y)
		{
			var textWidth = Core.DefaultFont.MeasureString(text).x;
			Core.Draw.Text(Core.DefaultFont, float2(Screen.Size.width - textWidth - 5, y), text, Color.White);
		}


		void HandleCollisions()
		{
			let enemies = scope List<Enemy>();
			let bullets = scope List<Bullet>();
			let blackHoles = scope List<BlackHole>();

			Entities.FindByType(enemies);
			Entities.FindByType(bullets);
			Entities.FindByType(blackHoles);

			for (int i = 0; i < enemies.Count; i++)
				for (int j = i + 1; j < enemies.Count; j++)
				{
					if (Entity.IsColliding(enemies[i], enemies[j]))
					{
						enemies[i].HandleCollision(enemies[j]);
						enemies[j].HandleCollision(enemies[i]);
					}
				}

			// handle collisions between bullets and enemies
			for (int i = 0; i < enemies.Count; i++)
				for (int j = 0; j < bullets.Count; j++)
				{
					if (Entity.IsColliding(enemies[i], bullets[j]))
					{
						enemies[i].WasShot();
						bullets[j].Destroy();
					}
				}

			// handle collisions between the player and enemies
			for (int i = 0; i < enemies.Count; i++)
			{
				if (enemies[i].IsActive && Entity.IsColliding(player, enemies[i]))
				{
					player.Kill();
					enemies.ForEach( (x) => x.WasShot());
					bullets.ForEach( (x) => x.Destroy());
					blackHoles.ForEach( (x) => x.Kill());
					blackHoles.Clear();
					break;
				}
			}

			// handle collisions with black holes
			for (int i = 0; i < blackHoles.Count; i++)
			{
				for (int j = 0; j < enemies.Count; j++)
					if (enemies[j].IsActive && Entity.IsColliding(blackHoles[i], enemies[j]))
						enemies[j].WasShot();

				for (int j = 0; j < bullets.Count; j++)
				{
					if (Entity.IsColliding(blackHoles[i], bullets[j]))
					{
						bullets[j].Destroy();
						blackHoles[i].WasShot();
					}
				}

				if (Entity.IsColliding(player, blackHoles[i]))
				{
					player.Kill();
					break;
				}
			}

			blackHoleCount = blackHoles.Count;
		}
	}
}
