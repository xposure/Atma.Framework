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

		public int Lives;
		public int Score;
		public int Multiplier;

		private float multiplierTimeLeft;// time until the current multiplier expires
		public int scoreForExtraLife;// score required to gain an extra life


		public bool IsGameOver => Lives <= 0;

		public int HighScore = 0;

		// Static constructor
		public this() : base(true, true)
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
				scoreForExtraLife += scoreForExtraLife * 3 / 2;
				Lives++;
			}
		}

		public void IncreaseMultiplier(int amount = 1)
		{
			let player = Entity as Player;
			if (player.IsDead == true)
				return;

			multiplierTimeLeft = multiplierExpiryTime;
			Multiplier = Math.Min(Multiplier + amount, maxMultiplier);
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
