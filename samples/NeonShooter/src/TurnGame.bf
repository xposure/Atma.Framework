/*using Atma;
namespace NeonShooter
{
	/*static
	{
		public const int tiles = 5;
		public const int tileSize = 32;
		public const int gridSize = tiles * tileSize;

		public static void ForXY<T>(T dlg)
			where T : delegate void(Tile tile)
		{
			for (var y < tiles)
				for (var x < tiles)
					dlg(Tile()
						{
							x = x,
							y = y,
							DrawRect = rect(x * tileSize, y * tileSize, tileSize, tileSize)
						});
		}
	}*/

	public struct Tile
	{
		public int x, y;
		public rect DrawRect;
	}

	
}*/
using Atma
namespace TurnGame
{
	class TurnGame : Scene
	{
		private override void Initialize()
		{
			/*Core.Graphics.ClearColor = .(51, 51, 51, 255);
			base.Initialize();
			this.Camera.SetDesignResolution(gridSize, gridSize, .ShowAllPixelPerfect);
			this.Camera.Origin = .(0.5f, 0.5f);*/
		} protected internal override void Render()
		{
			//RenderGround();
			base.Render();
		}


		private void RenderGround()
		{
			//ForXY( (tile) => Core.Draw.Rect(tile.DrawRect, .White));
			//ForXY( (tile) => Core.Draw.HollowRect(tile.DrawRect, 1f, .Gray));
		}
	}
}