namespace Atma.Entities
{
	using System;
	using internal Atma;

	public class ComponentArrayTests
	{
		private struct Position
		{
			public int X;
			public int Y;

			public this(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		private struct Velocity
		{
			public int VX;
			public int VY;

			public this(int vx, int vy)
			{
				VX = vx;
				VY = vy;
			}
		}

		[Test]
		public static void ShouldGetIndex()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			//act
			var span = data.AsSpan<Position>();
			var p = ref span[0];

			//assert
			Assert.EqualTo(p.X, 0);
			Assert.EqualTo(p.Y, 0);
		}



		[Test]
		public static void ShouldSetIndex()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			//act
			var span = data.AsSpan<Position>();
			var p0 = ref span[0];
			p0.X = 10;
			p0.Y = 20;

			var p1 = ref span[0];

			//assert
			Assert.EqualTo(p0.X, 10);
			Assert.EqualTo(p0.Y, 20);
			Assert.EqualTo(p0.X, p1.X);
			Assert.EqualTo(p0.Y, p1.Y);
		}

		[Test]
		public static void ShouldCopyToAnotherArray()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data0 = scope ComponentDataArray(componentType, 32);
			var data1 = scope ComponentDataArray(componentType, 32);

			//act
			var span0 = data0.AsSpan<Position>();
			var p0 = ref span0[0];
			p0.X = 10;
			p0.Y = 20;

			ComponentDataArray.CopyTo(data0, 0, data1, 1);

			//assert
			var span1 = data1.AsSpan<Position>();
			var p1 = ref span1[1];
			Assert.EqualTo(p1.X, 10);
			Assert.EqualTo(p1.Y, 20);
		}

		[Test]
		public static void ShouldReset()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			//act
			var span = data.AsSpan<Position>();
			{
				var p0 = ref span[0];
				p0.X = 10;
				p0.Y = 20;
			}

			data.Reset(0);

			//assert
			var readspan = data.AsSpan<Position>();
			{
				var p0 = ref readspan[0];
				Assert.EqualTo(p0.X, 0);
				Assert.EqualTo(p0.Y, 0);
			}
		}

		[Test(ShouldFail = true)]
		public static void ShouldThrowOnWrongType()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			//act

			//assert
			#unwarn
			var span = data.AsSpan<Velocity>();
		}

		[Test]
		public static void ShouldMoveData()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			//act
			var span = data.AsSpan<Position>();
			{
				var p0 = ref span[1];
				p0.X = 10;
				p0.Y = 20;
			}

			data.Move(1, 0);

			var readspan = data.AsSpan<Position>();
			var p1 = ref readspan[0];

			//assert
			Assert.EqualTo(p1.X, 10);
			Assert.EqualTo(p1.Y, 20);
		}


		[Test]
		public static void ShouldCopyVoidPtrWithArray()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			var span = data.AsSpan<Position>();
			var ptr = scope Position[4]* (Position(100, 100), Position(200, 200), Position(400, 100), Position(100,
				400)); var src = (void*)ptr;

			//act
			data.Copy(ref src, 0, 4, true);

			//assert

			Assert.EqualTo(span[0].X, 100);
			Assert.EqualTo(span[0].Y, 100);

			Assert.EqualTo(span[1].X, 200);
			Assert.EqualTo(span[1].Y, 200);

			Assert.EqualTo(span[2].X, 400);
			Assert.EqualTo(span[2].Y, 100);

			Assert.EqualTo(span[3].X, 100);
			Assert.EqualTo(span[3].Y, 400);
		}

		[Test]
		public static void ShouldCopyVoidPtrWithSingle()
		{
			//arrange
			var componentType = ComponentType<Position>.Type;
			var data = scope ComponentDataArray(componentType, 32);

			var span = data.AsSpan<Position>();
			var ptr = scope Position[1]* (Position(100, 100));
			var src = (void*)ptr;

			//act
			data.Copy(ref src, 0, 4, false);

			//assert
			Assert.EqualTo(span[0].X, 100);
			Assert.EqualTo(span[0].Y, 100);

			Assert.EqualTo(span[1].X, 100);
			Assert.EqualTo(span[1].Y, 100);

			Assert.EqualTo(span[2].X, 100);
			Assert.EqualTo(span[2].Y, 100);

			Assert.EqualTo(span[3].X, 100);
			Assert.EqualTo(span[3].Y, 100);
		}

		// private ref struct SpanHack
		// {
		//     public Span<Position> positions;
		//     public Span<Velocity> velocities;
		//     public static void Execute(int length)
		//     {
		//         positions.Length.ShouldBe(2);
		//         velocities.Length.ShouldBe(2);
		//         positions[0].X.ShouldBe(10);
		//         positions[0].Y.ShouldBe(10);
		//         positions[1].X.ShouldBe(20);
		//         positions[1].Y.ShouldBe(20);
		//         positions[1].X.ShouldBe(10);
		//         positions[1].Y.ShouldBe(10);
		//         positions[0].X.ShouldBe(20);
		//         positions[0].Y.ShouldBe(20);
		//     }
		// }

		// [Test]
		// public static void SpanHackTest()
		// {
		//     using IAllocator allocator = new DynamicAllocator(_logFactory);
		//     var data0 = stackalloc[] { new Position(10, 10), new Position(20, 20) };
		//     var data1 = stackalloc[] { new Velocity(20, 20), new Velocity(10, 10) };
		//     var size = Marshal.SizeOf(typeof(SpanHack));
		//     using var memory = allocator.TakeScoped(size);

		//     var hack = (byte*)memory.Address;
		//     var offset0 = Marshal.OffsetOf(typeof(SpanHack), "positions");
		//     var offset1 = Marshal.OffsetOf(typeof(SpanHack), "velocities");

		//     var ptr = (IntPtr*)(hack + offset0.ToInt32());
		//     *ptr = new IntPtr(data0);
		//     ptr++;

		//     var length = (int*)ptr;
		//     *length = 2;

		//     ptr = (IntPtr*)(hack + offset1.ToInt32());
		//     *ptr = new IntPtr(data1);
		//     ptr++;

		//     length = (int*)ptr;
		//     *length = 2;

		//     var x = stackalloc[] { Span<int>.Empty };
		// }
	}
}