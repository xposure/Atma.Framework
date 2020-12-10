using Atma;
using System.Collections;

namespace NeonShooter
{
	static
	{
		public static SpriteFont DefaultFont;

		public static Input PlatformInput;
		public static Atlas2 Atlas;

		public static Scene Scene;
		//public static GameCommandInput GameCommands;


	}

	public enum TileLayers : int
	{
		case DEFAULT = 0;
		case FRINGE = 1;
	}

	static class DebugOptions
	{
		public static bool Pathfinding = false;
		public static float PathfindingDuration = 1f;
		public static uint8 PathfindingTransparency = 100;

		private static bool DebugWindowOpen = true;

		public static void ShowDebugOptions()
		{
			//TODO IMGUI ImGui.OpenPopup("Debug Options");
			DebugWindowOpen = true;
		}

		public static void Draw()
		{
			//TODO IMGUI
			/*if (ImGui.BeginPopupModal("Debug Options", &DebugWindowOpen))
			{
				//ig.Checkbox("Hitbox", &Pathfinding);
				ImGui.EndPopup();
			}*/
		}
	}
}
