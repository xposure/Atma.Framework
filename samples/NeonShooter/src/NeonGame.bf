using Atma;
using NeonShooter.Entities;
using NeonShooter.Components;
using System;
using NeonShooter.PostProcessors;
using NeonShooter.PostEffects;
using System.Collections;
namespace NeonShooter
{
	public class NeonGame : Scene
	{
		public ParticleManager<ParticleState> Particles;
		public GridComponent Grid;

		private Texture texture;
		private Sprite sprite;
		public Player player;

		public Music Music;

		private List<SoundEffect> explosions = new .() ~ delete _;
		// return a random explosion sound
		public SoundEffect Explosion { get { return explosions[Core.Random.Next(explosions.Count)]; } }

		private List<SoundEffect> shots = new .() ~ delete _;
		public SoundEffect Shot { get { return shots[Core.Random.Next(shots.Count)]; } }

		private List<SoundEffect> spawns = new .() ~ delete _;
		public SoundEffect Spawn { get { return spawns[Core.Random.Next(spawns.Count)]; } }

		public this() : base(.ExactFit, Screen.Size)
		{
			Music = Core.Assets.LoadMusic("music/music.mp3");
			Music.Play();

			for (var i < 8) explosions.Add(Core.Assets.LoadSoundEffect(scope $"sounds/explosion-0{i+1}.wav"));
			for (var i < 4) shots.Add(Core.Assets.LoadSoundEffect(scope $"sounds/shoot-0{i+1}.wav"));
			for (var i < 8) spawns.Add(Core.Assets.LoadSoundEffect(scope $"sounds/spawn-0{i+1}.wav"));

			Time.SetTargetFramerate(60);

			Particles = new .(new => ParticleState.UpdateParticle);

			const int maxGridPoints = 1600;
			let gridSpacing = float2((float)Math.Sqrt(Screen.Width * Screen.Height / maxGridPoints));
			Grid = new .(.(0, 0, Screen.Width, Screen.Height), gridSpacing);
			//Grid.Visible = false;

			CreateEntity("grid").Components.Add(Grid);
			CreateEntity("particles").Components.Add(Particles);

			this.Camera.AddRenderer(new SceneRenderer(this) { BlendMode = .Add });
			Core.Atlas.AddDirectory("main", "textures");
			Core.Atlas.Finalize();

			Core.Graphics.ClearColor = .Black;
			Camera.ClearColor = .(0, 0, 0, 255);

			Camera.AddPostProcessor(new Bloom());
			Camera.AddPostProcessor(new Vignette());

			player = AddEntity(new Player());
			player.Components.Add(new PlayerCamera());
			player.Position = Screen.Size / 2;
		}

		public override void FixedUpdate()
		{
			ImGui.ShowDemoWindow();

			HandleCollisions();
			HandleEnemySpawn();

			base.FixedUpdate();

			//Camera.Inspect();
		}

		float inverseSpawnChance = 60;
		float inverseBlackHoleChance = 600;
		int blackHoleCount = 0;

		private void HandleEnemySpawn()
		{
			if (!player.IsDead && Entities.Count < 200)
			{
				if (gRand.Next((int)inverseSpawnChance) == 0)
				{
					AddEntity(new Seeker(GetSpawnPosition()));
					let spawn = Spawn;
					spawn.Play(0.5f, Core.Random.nextFloat(-0.2f, 0.2f), 0);
				}

				if (gRand.Next((int)inverseSpawnChance) == 0)
				{
					AddEntity(new Wanderer(GetSpawnPosition()));
					let spawn = Spawn;
					spawn.Play(0.5f, Core.Random.nextFloat(-0.2f, 0.2f), 0);
				}


				if (blackHoleCount < 2 && gRand.Next((int)inverseBlackHoleChance) == 0)
				{
					AddEntity(new BlackHole(GetSpawnPosition()));
					let spawn = Spawn;
					spawn.Play(0.5f, Core.Random.nextFloat(-0.2f, 0.2f), 0);
				}
				// // slowly increase the spawn rate as time progresses
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

		public override void Render()
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
				DrawRightAlignedString(scope $"Next Life: {status.scoreForExtraLife}", 65);
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
					{
						enemies[j].PointValue = 0;
						enemies[j].WasShot();
					}

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
