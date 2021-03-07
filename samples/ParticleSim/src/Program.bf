using System;
using Atma;

namespace ParticleSim
{
	class Program : Core
	{
		public const int ChunkSize = 128;

		public struct Particle
		{
			public bool solid;
			public Color color;
		}

		public class Chunk
		{
			public readonly int2 WorldPosition;

			public Particle[ChunkSize * ChunkSize] _particles;

			public this()
			{
			}

			public void Update()
			{
				/*//clear out bottom row
				for (var x < ChunkSize)
				{
					var idx = GetIndex(x, ChunkSize - 1);
					var p = ref _particles[idx ];
					p.color = Color.Transparent;
					p.solid = false;
				}*/


				var sx = 0;
				var dx = 1;

				if ((Core.Random.nextInt(255) & 1) == 1)
				{
					sx = ChunkSize - 1;
					dx = -1;
				}

				var tx = sx;


				for (var y = ChunkSize - 1; --y >= 0;)
				{
					sx = tx;
					while (sx >= 0 && sx < ChunkSize)
					//for (var x < ChunkSize)
					{
						var x = sx;
						sx += dx;
						var idx = GetIndex(x, y);
						var p0 = ref _particles[idx];
						var p1 = ref _particles[idx + ChunkSize];
						if (!p1.solid)
						{
							p1 = p0;
							p0.color = Color.Transparent;
							p0.solid = false;
						}
						else
						{
							var test = (Core.Random.nextInt(255) & 3);
							if (test < 3)
							{
								var dir = (test & 1) == 1;
								for (var i < 2)
								{
									if (dir && x > 0)
									{
										var left = ref _particles[idx + ChunkSize - 1];
										if (!left.solid)
										{
											left = p0;
											p0.color = Color.Transparent;
											p0.solid = false;
											break;
										}
									} else if (!dir && x < ChunkSize - 1)
									{
										var right = ref _particles[idx + ChunkSize + 1];
										if (!right.solid)
										{
											right = p0;
											p0.color = Color.Transparent;
											p0.solid = false;
											break;
										}
									}

									dir ^= true;
								}
							}
						}
					}
				}

				for (var i < 10)
				//if (Core.Random.nextFloat() > 0.15f)
				{
					//var x = Core.Random.nextInt(ChunkSize / 2) + ChunkSize / 4;

					var x = (int)(ChunkSize / 2 + (ChunkSize / 8) * Calc.Sin(Time.Elapsedf / 2f) + Core.Random.nextInt(8) - 4);
					var p = ref _particles[x];
					//p.color = .(Core.Random.nextInt(0xffffff) + 0xff000000);
					p.color = Color.Yellow;
					p.solid = true;
				}
			}

			public void Render()
			{
				for (var y < ChunkSize)
				{
					for (var x < ChunkSize)
					{
						var idx = GetIndex(x, y);
						var p = ref _particles[idx];
						if (p.solid)
							Core.Draw.Rect(rect(x * 2, y * 2, 2, 2), p.color);
					}
				}
			}


			[Inline]
			public static int GetIndex(int x, int y) => y * ChunkSize + x;

			[Inline]
			public static int GetIndex(int2 position) => (ChunkSize - position.y - 1) * ChunkSize + position.x;

			[Inline]
			public static int2 WorldToChunk(int2 worldPos) => .(worldPos.x % ChunkSize, worldPos.y % ChunkSize);
		}

		private Chunk chunk ~ delete _;

		protected override void Initialize()
		{
			chunk = new .();
		}

		private aabb2i test = aabb2i(100 ,100, 1, 1);



		protected override void Render()
		{
			var min = int2(57,57);
			var max = int2(0,0);

			test = .(min, max);

			Core.Draw.Text(Core.DefaultFont, .(0,0), scope $"min: {min}, max: {max}", Color.White);


			chunk.Render();
			
			test = aabb2i(100, 100,0,0);
			test.Merge(Input.MousePosition);

			Core.Draw.Rect(test, .White);

			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		protected override void Update()
		{
		}

		public bool isRunning = false;
		protected override void FixedUpdate()
		{
			if (Core.Input.KeyCheck(.Space))
				isRunning = true;

			if (isRunning)
			{
			//if (Time.OnInterval(0.01f))
				chunk.Update();
				chunk.Update();
				chunk.Update();
				chunk.Update();
			}
		}

		protected override void Unload()
		{
		}

		public static int Main(String[] args)
		{
			let game = scope Program("Hello World", 400, 300);
			return game.Run();
		}

		public this(StringView title, int width, int height, Window.WindowFlags windowFlags = .Hidden) : base(title, width, height, windowFlags)
		{
		}
	}
}