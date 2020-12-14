using Atma;
using System;
using System.Collections;
using Game.Scenes;
namespace Game.Scenes
{
	struct Actor
	{
		public int2 tile;
		public Color color;
		public int move;
		public int atb;
		public int speed;
	}


	public struct Command
	{
		public enum CommandType
		{
			case Move = 1;
			case Attack = 2;

			public int Cost(Actor actor)
			{
				switch (this) {
				case .Attack: return 5;
				case .Move: return actor.move;
				}
			}
		}

		public CommandType Type;
		public int2 Target;

		public this(CommandType commandType, int2 target)
		{
			Type = commandType;
			Target = target;
		}

		public void Advance(ref Actor actor)
		{
			switch (Type) {
			case .Move: actor.tile = Target;
			case .Attack:// do nothing
			}

			actor.atb -= Type.Cost(actor);
		}

		public void Render(Actor actor, Actor future)
		{
			switch (Type) {
			case .Attack: Core.Draw.HollowRect(rect.FromXY(Target, TILESIZE), 1f, .Yellow);
			case .Move:
				if (actor.tile != future.tile)
					Core.Draw.Rect(rect.FromXY(actor.tile, TILESIZE), actor.color.ToAlpha(0.5f).Premultiplied);

				Core.Draw.Line(actor.tile * TILESIZE + (TILESIZE / 2), Target * TILESIZE + (TILESIZE / 2), 1f, .Blue);
			}
		}
	}

	public class TurnTestScene : Scene
	{
		private int2 _mouseTile = .(-1, -1);

		private List<Actor> _actors = new .() ~ delete _;
		private List<Command> _commands = new .() ~ delete _;

		private VirtualButton _move = new .() ~ delete _;

		public override void Initialize()
		{
			base.Initialize();
			Core.DefaultFont = Core.Assets.LoadFont(@"fonts/PressStart2P.ttf", 8);

			this.Camera.RenderTexture.ColorAttachment.Filter = .Nearest;
			this.Camera.SetDesignResolution(GRIDSIZE, GRIDSIZE, .ShowAllPixelPerfect);

			_actors.Add(Actor() { tile = .(2, 2), color = .Green, speed = 1, move = 2 });
			_actors.Add(Actor() { tile = .(3, 3), color = .Red, speed = 2, move = 1 });

			_move.AddMouseButton(.Left);
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();

			_actors.Sort(scope (a, b) => a.atb <=> b.atb);
			if (_actors.Back.atb > 10)
			{
				_mouseTile = .(-1, -1);

				let mp = Core.Input.MousePosition;
				let wp = this.Camera.ScreenToWorld(mp);

				/*Core.Draw.Text(Core.DefaultFont, .Zero, scope $"{wp}", .Red);*/
				let gridArea = rect(0, 0, GRIDSIZE, GRIDSIZE);
				if (gridArea.Contains(wp))
				{
					_mouseTile = (int2)(wp / TILESIZE);

					if (_move.Released)
					{
						var actor = ref _actors.Back;
						var futureActor = actor;
						AdvanceToEnd(ref futureActor);

						let atb = CalculateAtb(actor);
						let ratb = actor.atb - atb;

						let target = _actors.IndexOf( (it) => it.tile == _mouseTile);
						//check if something is already at our tile
						if (target == -1)
						{
							let moveTiles = scope List<int2>();

							CalculateTiles(actor.tile, ratb / actor.move, moveTiles);
							if (moveTiles.Count > 0)
							{
								if (moveTiles.Contains(_mouseTile))
								{
									_commands.Add(.(.Move, _mouseTile));
								} else
								{
									Log.Debug(scope $"Move out of range {_mouseTile}");
								}
							} else
							{
								Log.Debug("You do not have enough atb to move there");
							}
						}
						else if (_actors[target].tile != actor.tile)
						{
							//attack
							if ((actor.tile - _actors[target].tile).LengthSqr == 1)
							{
								Log.Debug(scope $"Attack {target}");
								actor.atb = 0;
							}
							else
								Log.Debug(scope $"Target was out of range {target}");
						}
					}
				}
			}
			else
			{
				for (var it in ref _actors)
					it.atb += it.speed;
			}
		}

		protected internal override void Render()
		{
			for (var y < TILES)
				for (var x < TILES)
					Core.Draw.Rect(rect.FromXY(x, y, TILESIZE), .White);

			for (var y < TILES)
				for (var x < TILES)
					Core.Draw.HollowRect(rect.FromXY(x, y, TILESIZE), 1f, .Gray);

			if (_mouseTile != .(-1, -1))
				Core.Draw.Rect(rect.FromXY(_mouseTile, TILESIZE), .Blue);

			for (var i < _actors.Count)
			{
				let it = ref _actors[i];
				Core.Draw.Rect(rect.FromXY(it.tile, TILESIZE).Inflate(-8), it.color);
			}

			if (_actors.Back.atb > 10)
			{
				let actor = ref _actors.Back;
				var startActor = actor;
				var futureActor = actor;
				AdvanceToEnd(ref futureActor);

				for (var it in ref _commands)
				{
					it.Render(startActor, futureActor);
					it.Advance(ref startActor);
				}

				Core.Draw.HollowRect(rect.FromXY(actor.tile, TILESIZE).Inflate(-8), 1f, .Magenta);
				let moveTiles = scope List<int2>();
				CalculateTiles(actor.tile, futureActor.atb / futureActor.move, moveTiles);

				for (var moveTile in ref moveTiles)
					Core.Draw.HollowRect(rect.FromXY(moveTile, TILESIZE).Inflate(-8), 1f, .Magenta);

				let atb_t = 1f - (futureActor.atb / (float)actor.atb);
				Core.Draw.Rect(rect(0, 0, .((int)(GRIDSIZE * atb_t), 10)), .Yellow);
				Core.Draw.HollowRect(rect(0, 0, .(GRIDSIZE, 10)), 1f, .Yellow);
			}

			base.Render();
		}

		private void AdvanceToEnd(ref Actor actor)
		{
			for (var it in ref _commands)
				it.Advance(ref actor);
		}

		private int CalculateAtb(Actor actor)
		{
			var atb = 0;
			for (var it in ref _commands)
				atb += it.Type.Cost(actor);

			return atb;
		}

		private void CalculateTiles(int2 start, int distance, List<int2> tiles, bool includeStart = false)
		{
			if (distance == 0)
				return;

			let hash = scope HashSet<int2>();
			let items = scope List<(int2 position, int distance)>();
			items.Add((start, distance));

			while (items.Count > 0)
			{
				let next = items.PopBack();
				if (hash.Add(next.position))
				{
					if (!InBounds(next.position))
						continue;

					if (includeStart || next.position != start)
						tiles.Add(next.position);

					if (next.distance > 0)
					{
						AdjacentTile(next.position, (p) =>
							{
								if (InBounds(p) && !hash.Contains(p) && !_actors.Any( (other) => other.tile == p))
									items.Add((p, next.distance - 1));
							});
					}
				}
			}
		}

		private void AdjacentTile<T>(int2 p, T dlg) where T : Action<int2>
		{
			dlg(p + .(-1, 0));
			dlg(p + .(0, -1));
			dlg(p + .(1, 0));
			dlg(p + .(0, 1));
		}

		private bool InBounds(int2 position) => position.x >= 0 && position.y >= 0 && position.x < TILES && position.y < TILES;
	}
}

namespace Game
{
	static
	{
		public const int TILES = 5;
		public const int TILESIZE = 32;
		public const int GRIDSIZE = TILES * TILESIZE;

	}
}

class Program
{
	public static int Main(String[] args)
	{
		return Atma.Game.RunInitialScene<TurnTestScene>("TurnGame", 1280, 768);
	}
}