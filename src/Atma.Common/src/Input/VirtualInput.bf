namespace Atma
{
	public abstract class VirtualInput
	{
		public enum OverlapBehaviors { TakeNewer, TakeOlder, CancelOut }
		public enum ThresholdConditions { GreaterThan, LessThan }

		protected bool fromGamepad = false;
		public bool FromGamepad => fromGamepad;

		public this()
		{
			Core.Input.VirtualInputs.Add(this);
		}

		public ~this()
		{
			Core.Input.VirtualInputs.Remove(this);
		}

		public virtual void Update()
		{
			fromGamepad = false;
		}
	}
}
