namespace Atma
{
	using internal Atma;
	using System;

	public class ComponentPackedArrayTests
	{
		private struct Position
		{
			public int X;
			public int Y;

			public this(int v)
			{
				X = v;
				Y = v;
			}

			public this(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override void ToString(String output) => output.Append(scope $"[ X: {X}, Y: {Y} ]");
		}


		private struct Velocity
		{
			public int VX;
			public int VY;

			public this(int v)
			{
				VX = v;
				VY = v;
			}

			public this(int vx, int vy)
			{
				VX = vx;
				VY = vy;
			}

			public override void ToString(String output) => output.Append(scope $"[ VX: {VX}, VY: {VY} ]");
		}

		[Test]
		public static void CanCreatePackedArray()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var entityGroup = scope ComponentPackedArray(specification);

			//act
			var positions = entityGroup.GetComponentData<Position>();
			var velocities = entityGroup.GetComponentData<Velocity>();

			//assert
			for (var i = 0; i < entityGroup.Length; i++)
			{
				var p = ref positions[i];
				var v = ref velocities[i];
				Assert.EqualTo(p.X, 0);
				Assert.EqualTo(p.Y, 0);

				Assert.EqualTo(v.VX, 0);
				Assert.EqualTo(v.VY, 0);
			}
		}

		[Test]
		public static void ShouldReset()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var packedArray = scope ComponentPackedArray(specification);

			//act
			var positions = packedArray.GetComponentData<Position>();
			var velocities = packedArray.GetComponentData<Velocity>();
			positions[0] = Position(1);
			velocities[0] = Velocity(2);
			positions[1] = Position(3);
			velocities[1] = Velocity(4);

			packedArray.Reset(0);
			packedArray.Reset<Position>(1);

			//assert
			Assert.EqualTo(positions[0], Position(0));
			Assert.EqualTo(velocities[0], Velocity(0));

			Assert.EqualTo(positions[1], Position(0));
			Assert.EqualTo(velocities[1], Velocity(4));
		}

		[Test(ShouldFail = true)]
		public static void ShouldThrowOnWrongType()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type);

			var packedArray = scope ComponentPackedArray(specification);

			//act

			//assert
	#unwarn
			var velocities = packedArray.GetComponentData<Velocity>();
		}

		[Test]
		public static void ShouldGetComponentIndex()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type);

			var packedArray = scope ComponentPackedArray(specification);

			//act
			var p0 = packedArray.GetComponentIndex<Position>();
			var v0 = packedArray.GetComponentIndex<Velocity>();

			//assert
			Assert.EqualTo(p0, 0);
			Assert.EqualTo(v0, 1);
		}

		//test is probably pointless, its testing Span more than anything else
		[Test]
		public static void ShouldReadAndWriteEntity()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var entityGroup = scope ComponentPackedArray(specification);

			//act
			var positions = entityGroup.GetComponentData<Position>();
			var velocities = entityGroup.GetComponentData<Velocity>();
			{
				for (var i = 0; i < entityGroup.Length; i++)
				{
					var p = ref positions[i];
					var v = ref velocities[i];
					p.X = i;
					p.Y = i + 1;
					v.VX = i + 2;
					v.VY = i + 3;
				}
			}

			//assert
			var positions1 = entityGroup.GetComponentData<Position>();
			var velocities1 = entityGroup.GetComponentData<Velocity>();
			{
				for (var i = 0; i < entityGroup.Length; i++)
				{
					var p = ref positions1[i];
					var v = ref velocities1[i];
					Assert.EqualTo(p.X, i);
					Assert.EqualTo(p.Y, i + 1);

					Assert.EqualTo(v.VX, i + 2);
					Assert.EqualTo(v.VY, i + 3);
				}
			}
		}


		[Test]
		public static void ShouldCopyPtrArrayToComponent()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var packedArray = scope ComponentPackedArray(specification);
			var componentIndex = packedArray.GetComponentIndex<Position>();
			var span = packedArray.GetComponentData<Position>();

			var ptr = scope Position[]* (Position(100, 100), Position(200, 200), Position(400, 100), Position(100,
				400)); var src = (void*)ptr;

			//act
			packedArray.Copy(componentIndex, ref src, 0, 4, true);

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
		public static void ShouldCopyPtrToComponent()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var packedArray = scope ComponentPackedArray(specification);
			var componentIndex = packedArray.GetComponentIndex<Position>();
			var span = packedArray.GetComponentData<Position>();

			var ptr = scope Position[]* (Position(100, 100));
			var src = (void*)ptr;

			//act
			packedArray.Copy(componentIndex, ref src, 0, 4, false);

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

		[Test]
		public static void ShouldMoveEntity()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var entityGroup = scope ComponentPackedArray(specification);

			//act
			var positions = entityGroup.GetComponentData<Position>();
			var velocities = entityGroup.GetComponentData<Velocity>();
			{
				var p = ref positions[1];
				var v = ref velocities[1];
				p.X = 10;
				p.Y = 20;
				v.VX = 30;
				v.VY = 40;
			}

			entityGroup.Move(1, 0);

			//assert
			var positions1 = entityGroup.GetComponentData<Position>();
			var velocities1 = entityGroup.GetComponentData<Velocity>();
			{
				var p = ref positions1[0];
				var v = ref velocities1[0];
				Assert.EqualTo(p.X, 10);
				Assert.EqualTo(p.Y, 20);

				Assert.EqualTo(v.VX, 30);
				Assert.EqualTo(v.VY, 40);
			}
		}
	}
}