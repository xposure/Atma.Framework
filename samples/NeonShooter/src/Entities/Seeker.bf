using Atma;
namespace NeonShooter.Entities
{
	public class Seeker : Enemy
	{
		private Player player;

		public this(float2 position) : base(Core.Atlas["main/Seeker"], position, 10)
		{
		}

		protected override void OnReady()
		{
			base.OnReady();
			player = Scene.Entities.FindFirstByType<Player>();
		}

		public override void Logic()
		{
			Velocity += (player.WorldPosition - WorldPosition).Limit(1f);
			if (Velocity.LengthSqr > 0)
				Rotation = Calc.Turn(Velocity);
		}
	}
}
