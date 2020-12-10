using System;
namespace Atma
{
	public static class Assert
	{

#if !DEBUG
		[SkipCall]
#endif
		public static void IsTrue(bool expr, StringView msg = default)
		{
			if (!expr) Fatal(msg);
		}

#if !DEBUG
		[SkipCall]
#endif
		public static void IsFalse(bool expr, StringView msg = default)
		{
			if (expr) Fatal(msg);
		}


		public static void Fatal(StringView msg = default)
		{
			if(msg == default)
				Runtime.FatalError("Fatal error!");
			else
				Runtime.FatalError(scope String(msg));
		}

		public static void NotImplemented()
		{
			Runtime.FatalError("Not implemented");
		}
	}
}
