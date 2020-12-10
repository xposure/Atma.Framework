using System.Collections;

namespace Atma
{
	public static class Sort
	{
		public static void SortByDepthThenY<T>(List<T> self) where T : var
		{
			//dst sqr is probably going to skew the depth bias?
			self.Sort(scope (a, b) =>
				{
					let d = a.Depth - b.Depth;
					if (d == 0)
					{
						let y = a.SortKey - b.SortKey;

						if (y < 0)
							return -1;
						else if (y > 0)
							return 1;

						return 0;
					}
					else if (d < 0)
						return -1;

					return 1;
				});
		}

		public static void SortByY<T>(List<T> self) where T : var
		{
			//dst sqr is probably going to skew the depth bias?
			self.Sort(scope (a, b) =>
				{
					let y = a.SortKey - b.SortKey;

					if (y < 0)
						return -1;
					else if (y > 0)
						return 1;

					return 0;
				});
		}

		public static void SortByClosest<T>(List<T> self, float2 worldPosition) where T : var
		{
			//dst sqr is probably going to skew the depth bias?
			self.Sort(scope (a, b) =>
				{
					var ad = float2.DistanceSqr(worldPosition, a.WorldPosition);
					var bd = float2.DistanceSqr(worldPosition, b.WorldPosition);
					if (ad < bd)
						return -1;
					else if (ad > bd)
						return 1;

					return 0;
				});
		}

		/*public static void SortBy<T, K, L>(List<T> self,  K dlg)
			where T : var
			where K: delegate int (T t)
		{
			self.Sort(scope (a, b) =>
				{
					let av = dlg(a);
					let bv = dlg(b);
					if(av < bv) return -1;
					if(av > bv) return 1;
					return 0;
				});
		}*/
	}
}
