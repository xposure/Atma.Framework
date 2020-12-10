using Atma;
using System;
using NeonShooter.Entities;
namespace NeonShooter.Components
{
	public class PlayerStatus : Component
	{
		// amount of time it takes, in seconds, for a multiplier to expire.
		private const float multiplierExpiryTime = 0.8f;
		private const int maxMultiplier = 20;

		public int Lives { get; private set; }
		public int Score { get; private set; }
		public int Multiplier { get; private set; }

		private float multiplierTimeLeft;// time until the current multiplier expires
		private int scoreForExtraLife;// score required to gain an extra life

		public override bool Track => true;

		public bool IsGameOver => Lives <= 0;

		public int HighScore = 0;

		// Static constructor
		public this() : base(true)
		{
			Reset();
		}

		public void Reset()
		{
			if (Score > HighScore)
				HighScore = Score;

			Score = 0;
			Multiplier = 1;
			Lives = 4;
			scoreForExtraLife = 20000;
			multiplierTimeLeft = 0;
		}

		public override void FixedUpdate()
		{
			if (Multiplier > 1)
			{
				// update the multiplier timer
				if ((multiplierTimeLeft -= Time.Delta) <= 0)
				{
					multiplierTimeLeft = multiplierExpiryTime;
					ResetMultiplier();
				}
			}
		}

		public void AddPoints(int basePoints)
		{
			let player = Entity as Player;
			if (player?.IsDead == true)
				return;

			Score += basePoints * Multiplier;
			while (Score >= scoreForExtraLife)
			{
				scoreForExtraLife += 2000;
				Lives++;
			}
		}

		public void IncreaseMultiplier()
		{
			let player = Entity as Player;
			if (player.IsDead == true)
				return;

			multiplierTimeLeft = multiplierExpiryTime;
			if (Multiplier < maxMultiplier)
				Multiplier++;
		}

		public void ResetMultiplier()
		{
			Multiplier = 1;
		}

		public void RemoveLife()
		{
			Lives--;
		}
	}
}
