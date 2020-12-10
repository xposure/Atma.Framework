/*using Atma;
using Atma.Math;
using System;
using System.Collections;
using System.Diagnostics;

namespace GameSim
{
	public class DungeonGenScene : Scene
	{
		private Surface surface ~ delete _;
		private Batch2D _batch = new .() ~ delete _;

		private int width = 32;
		private int height = 32;

		private FastNoise _noise = new .(321331123) ~ delete _;
		private int tileSize = 16;
		private float3 noiseScale1 = float3.Ones * 8;
		private float z = 0f;
		private bool reset = true;

		private HashSet<int2> _floor = new .() ~ delete _;
		private List<Walker> _walkers = new .() ~ delete _;

		private float stepSpeed = 0.01f;
		private float stepTimer = 0.01f;

		private int _seed = 1337;
		private Random _random = new Random() ~ delete _;

		public int2 padding = .(10, 10);

		private LevelGen2 levelGen ~ delete _;


		private struct Walker
		{
			public int2 dir;
			public int2 pos;
			public int life;

			public void PickDir(Random random) mut
			{
				dir = .Zero;
				switch (random.Next(0, 4))
				{
				case 0: dir.x = -1;
				case 1: dir.y = 1;
				case 2: dir.x = 1;
				case 3: dir.y = -1;
				}
			}

			public void ChangeDir(Random random) mut
			{
				let x = dir.x;
				dir.x = dir.y;
				dir.y = x;

				if (random.Next(100) < 50)
					dir = -dir;
			}
		}

		public override void Init()
		{
			levelGen = new .(.(100, 100));
			levelGen.AddStep(new LevelGenStepWalker(levelGen, "Walker"));
		}

		private int fixedHeight = 360;
		public override void Update()
		{
			/*let input = Game.Input.GetState();
			if (input.Keyboard.IsDown(.A)) surface.Offset += .(1, 0);
			if (input.Keyboard.IsDown(.D)) surface.Offset -= .(1, 0);
			if (input.Keyboard.IsDown(.W)) surface.Offset += .(0, 1);
			if (input.Keyboard.IsDown(.S)) surface.Offset -= .(0, 1);*/

			if (ig.SliderInt("Fixed Height", &fixedHeight, 320, 1024))
				surface.Stretch = .FixedHeight(fixedHeight);

			/*reset |= ig.SliderInt("Width", &width, 8, 128);
			reset |= ig.SliderInt("Height", &height, 8, 128);
			reset |= ig.SliderFloat("Z", &z, 0.1f, 100f);
			reset |= ig.SliderFloat3("Scale 1", noiseScale1.values, 0.1f, 10f);*/

			reset |= ig.SliderFloat("Step Speed", &stepSpeed, 0.01f, 1f);
			reset |= ig.SliderInt("Walkers Min", &_walkCount.values[0], 1, 100);
			reset |= ig.SliderInt("Walkers Max", &_walkCount.values[1], 1, 100);
			reset |= ig.SliderInt("Life Min", &_walkLife.values[0], 1, 100);
			reset |= ig.SliderInt("Life Max", &_walkLife.values[1], 1, 200);
			reset |= ig.SliderInt("Change Min", &_walkChangeDir.values[0], 5, 20);
			reset |= ig.SliderInt("Change Max", &_walkChangeDir.values[1], 5, 20);
			reset |= ig.SliderFloat("Double", &_doubleChance, 0f, 1f);
			reset |= ig.SliderFloat("Split", &_splitChance, 0f, 0.1f);
			reset |= ig.SliderInt("Size", &_maxSize, 10, 2000);
			reset |= ig.SliderInt("Seed", &_seed, 0, (.)int.MaxValue);

			_walkCount.y = Math.Max(_walkCount.x, _walkCount.y);
			_walkCount.x = Math.Min(_walkCount.x, _walkCount.y);
			_walkLife.y = Math.Max(_walkLife.x, _walkLife.y);
			_walkLife.x = Math.Min(_walkLife.x, _walkLife.y);
			_walkChangeDir.y = Math.Max(_walkChangeDir.x, _walkChangeDir.y);
			_walkChangeDir.x = Math.Min(_walkChangeDir.x, _walkChangeDir.y);


			if (ig.Button("Cell")) celluar();
			if (ig.Button("Reset")) Reset();

			if (reset)
			{
				Reset();
				reset = false;
			}

			stepTimer -= Time.Delta;
			if (stepTimer <= 0)
			{
				stepTimer += stepSpeed;
				Step();
			}
		}

		private int2 _walkCount = .(25, 60);
		private int2 _walkLife = .(50, 100);
		private int2 _walkChangeDir = .(18, 20);
		private float _doubleChance = 0.25f;
		private float _splitChance = 0.05f;
		private int _maxSize = 50;
		private int _size = 0;

		public void Reset()
		{
			_floor.Clear();
			_walkers.Clear();
			_size = 1;
			_floor.Add(.(0, 0));

			delete _random;
			_random = new .(_seed);

			for (var i < _random.Next(_walkCount.x, _walkCount.y))
			{
				var w = Walker();
				w.PickDir(_random);
				/*w.pos.x = _random.Next(-10, 10);
				w.pos.y = _random.Next(-10, 10);*/
				w.life = _random.Next(_walkLife.x, _walkLife.y);
				_walkers.Add(w);
			}
			Type.Types.GetNext();
		}

		public this(int2 size)
		{
			surface = new .(.FixedHeight(fixedHeight), size, 1);
		}

		public override void Resize(int2 size)
		{
			surface.TargetSize = size;
		}


		/*public bool InBounds(int2 pos)
		{
			return pos.x >= 0 && pos.y >= 0 && pos.x < width && pos.y < height;
		}*/

		private int countNeighbors4(int2 pos)
		{
			var count = 0;

			count += _floor.Contains(pos + .(-1, 0)) ? 1 : 0;
			count += _floor.Contains(pos + .(1, 0)) ? 1 : 0;
			count += _floor.Contains(pos + .(0, -1)) ? 1 : 0;
			count += _floor.Contains(pos + .(0, 1)) ? 1 : 0;

			return count;
		}

		private int countNeighbors8(int2 pos)
		{
			var count = 0;

			count += _floor.Contains(pos + .(-1, -1)) ? 1 : 0;
			count += _floor.Contains(pos + .(0, -1)) ? 1 : 0;
			count += _floor.Contains(pos + .(1, -1)) ? 1 : 0;

			count += _floor.Contains(pos + .(-1, 0)) ? 1 : 0;
			count += _floor.Contains(pos + .(1, 0)) ? 1 : 0;

			count += _floor.Contains(pos + .(-1, 1)) ? 1 : 0;
			count += _floor.Contains(pos + .(0, 1)) ? 1 : 0;
			count += _floor.Contains(pos + .(1, 1)) ? 1 : 0;

			return count;
		}


		private void celluar()
		{
			let list = scope List<int2>(_floor.Count);
			for (var it in _floor)
				list.Add(it);

			for (var it in list)
				if (countNeighbors8(it) < 2)
					_floor.Remove(it);
		}

		public bool Step()
		{
			if (_size > _maxSize)
				_walkers.Clear();
			else if (_walkers.Count == 0)
			{
				var w = Walker();
				w.pos = .(0, 0);
				w.PickDir(_random);
				/*w.pos.x = _random.Next(-10, 10);
				w.pos.y = _random.Next(-10, 10);*/
				w.life = _random.Next(_walkLife.x, _walkLife.y);


				var i = _random.Next(_floor.Count);
				for (var it in _floor)
				{
					if (--i == 0)
					{
						w.pos = it;
						break;
					}
				}
				_walkers.Add(w);
			}

			for (var it in ref _walkers)
			{
				if (_size > _maxSize)
					break;

				it.pos += it.dir;
				if (_floor.Add(it.pos))
					_size++;

				it.life--;

				if (_random.nextFloat() < _doubleChance)
				{
					for (var y = -1; y <= 1; y++)
						for (var x = -1; x <= 1; x++)
							if (_floor.Add(it.pos + .(x, y)))
								_size++;
				}

				if (_random.nextFloat() < _splitChance)
				{
					var w = Walker();
					w.pos = it.pos;
					w.PickDir(_random);
					/*w.pos.x = _random.Next(-10, 10);
					w.pos.y = _random.Next(-10, 10);*/
					w.life = _random.Next(_walkLife.x, _walkLife.y);
					_walkers.Add(w);
				}

				if (((_noise.GetSimplex(it.pos.x, it.pos.y) + 1) / 2) * (_walkChangeDir.y) < _walkChangeDir.x)
					//it.PickDir(_random);
					it.ChangeDir(_random);

				if (it.life == 0)
					@it.RemoveFast();
			}

			return _walkers.Count == 0;
		}

		public void GetSize(out int2 min, out int2 max)
		{
			min = int2.MaxValue;
			max = int2.MinValue;

			for (var it in _floor)
			{
				if (it.x < min.x) min.x = it.x;
				if (it.y < min.y) min.y = it.y;
				if (it.x > max.x) max.x = it.x;
				if (it.y > max.y) max.y = it.y;
			}
		}

		private int2 min, max;
		public void Build()
		{
			Reset();
			while (_walkers.Count > 0)
				Step();

			GetSize(out min, out max);
		}

		public int2 Size => max - min;

		public bool this[int2 pos] => _floor.Contains(pos + min);

		public override void Render()
		{
			levelGen.Debug();

			//_batch.Clear();
			//_screen.Clear();
			GetSize(out min, out max);
			let size = max - min + padding * 2;
			let level = scope Level(size.x, size.y, 0, null);

			for (var y < size.y)
			{
				for (var x < size.x)
				{
					if (x < padding.x || y < padding.y || x > size.x - padding.x || y > size.y - padding.y)
						level.setTile(x, y, Tile.water, 0, false);
					else
					{
						let p = int2(x, y) - padding;
						level.setTile(x, y, _floor.Contains(p + min) ? Tile.grass : Tile.water, 0, false);
					}
				}
			}

			level.floodFill(0, 0, Tile.hardRock);

			level.renderBackground(surface);

			//level.renderSprites(_screen, 0, 0);
			//level.renderLight(_screen, 0, 0);

			/*for (var it in _floor)
				_batch.Rect(rect(it.x * tileSize, it.y * tileSize, tileSize, tileSize), .White);*/

			for (var it in _walkers)
			{
				let p = it.pos - min + padding;
				surface.Rect(rect(p.x * tileSize, p.y * tileSize, tileSize, tileSize), Color.White.ToAlpha(64));
			}

			//_screen.Render(Game.Window, MainCamera);
			//MainCamera.Render(_batch);
		}

		public override bool HandleInput()
		{
			let io = ig.GetIO();
			if (io.WantCaptureKeyboard || io.WantCaptureMouse)
				return true;
			return false;
		}

		public override void FinalizeRenderTarget(RenderTarget window)
		{
			surface.Render();
			surface.RenderTo(window);
		}

		public override void Debug()
		{
			surface.Debug();
		}
	}
}*/
