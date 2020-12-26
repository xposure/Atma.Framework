using System;
namespace Atma.Entities
{
	using internal Atma;

	public class EntityChunkTests
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

			public this(int vx, int vy)
			{
				VX = vx;
				VY = vy;
			}
		}

		[Test]
		public static void ShouldCreateOneEntity()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var entityChunk = scope EntityChunk(specification, 0, 0);
			var entityPool = scope EntityPool();

			var id0 = entityPool.TakeRef();

			//act
			var free = entityChunk.Free;
			entityChunk.Create(id0);

			//assert
			Assert.EqualTo(id0.Index, 0);
			Assert.EqualTo(entityChunk.Entities[0], id0);
			Assert.EqualTo(entityChunk.Count, 1);
			Assert.EqualTo(entityChunk.Free, free - 1);
		}

		/*[Test]
		public static void ShouldCreateManyEntities()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type, ComponentType<Velocity>.Type
				);

			var entityChunk = scope EntityChunk(specification, 0, 0);
			var entityPool = scope EntityPool();

			Span<EntityRef> ids = scope EntityRef[entityChunk.Free + 1];
			entityPool.Take(ids);

			//act
			var created = entityChunk.Create(ids);

			//assert
			entityChunk.Entities[0].ShouldBe(ids[0]);
			entityChunk.Entities[created - 1].ShouldBe(ids[created - 1]);
			entityChunk.Count.ShouldBe(created);
			entityChunk.Free.ShouldBe(0);
			created.ShouldBe(Entity.ENTITY_MAX);
		}

		[Test]
		public static void ShouldDeleteOneEntity()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type);

			var entityChunk = scope EntityChunk(specification, 0, 0);
			var span = entityChunk.PackedArray.GetComponentData<Position>(0);

			var entityPool = scope EntityPool();

			//act
			span[0] = Position(1);
			span[1] = Position(2);

			var id0 = entityPool.TakeRef();
			var id1 = entityPool.TakeRef();

			var free = entityChunk.Free;
			entityChunk.Create(id0);
			entityChunk.Create(id1);
			entityChunk.Delete(id0);

			//assert
			entityChunk.Count.ShouldBe(1);
			entityChunk.Free.ShouldBe(free - 1);
			//entityChunk.Get(id0).ShouldBe(id1);
			span[0].ShouldBe(scope Position(2));
		}

		[Test]
		public static void ShouldDeleteManyEntities()
		{
			//arrange
			var specification = scope EntitySpec(ComponentType<Position>.Type);

			var entityChunk = scope EntityChunk(specification, 0, 0);
			var entityPool = scope EntityPool();

			var ids = scope EntityRef[entityChunk.Free + 1];
			entityPool.Take(ids);

			var created = entityChunk.Create(ids);
			var span = entityChunk.PackedArray.GetComponentData<Position>();
			for (var i = 0; i < span.Length; i++)
				span[i] = Position(i + 1);

			//act
			Span<EntityRef> deleteIndicies = scope EntityRef[128];
			for (var i = 0; i < deleteIndicies.Length; i++)
				deleteIndicies[i] = ids[i + 128];

			entityChunk.Delete(deleteIndicies);

			//assert
			var first = Enumerable.Range(0, 128).Select(x => ids[x]) .ToArray();
			var second = Enumerable.Range(0, 128).Select(x => ids[Entity.ENTITY_MAX - x - 1]) .ToArray();
			var third = Enumerable.Range(256, Entity.ENTITY_MAX - 256 - 128).Select(x => ids[x]) .ToArray();
			var fourth = Enumerable.Range(0, 128).Select(x => 0) .Select(x => 0u) .ToArray();

			var firstSet = entityChunk.Entities.Slice(0, 128).ToArray();
			var secondSet = entityChunk.Entities.Slice(128, 128).ToArray();
			var thirdSet = entityChunk.Entities.Slice(256, Entity.ENTITY_MAX - 256 - 128).ToArray();

			//var fourthSet = entityChunk.Entities.Slice(Entity.ENTITY_MAX - 128, 128).ToArray();

			firstSet.ShouldBe(first);
			secondSet.ShouldBe(second);
			thirdSet.ShouldBe(third);
			//fourthSet.ShouldBe(fourth);
			entityChunk.Entities.Length.ShouldBe(Entity.ENTITY_MAX - 128);

			var firstPosition = Enumerable.Range(0, 128).Select(x => Position(x + 1)) .ToArray();
			var secondPosition = Enumerable.Range(0, 128).Select(x => Position(Entity.ENTITY_MAX - x)) .ToArray();
			var thirdPosition = Enumerable.Range(256, Entity.ENTITY_MAX - 256 - 128).Select(x => Position(x + 1))
	.ToArray();

			var firstSetPosition = span.Slice(0, 128).ToArray();
			var secondSetPosition = span.Slice(128, 128).ToArray();
			var thirdSetPosition = span.Slice(256, Entity.ENTITY_MAX - 256 - 128).ToArray();

			firstSetPosition.ShouldBe(firstPosition);
			secondSetPosition.ShouldBe(secondPosition);
			thirdSetPosition.ShouldBe(thirdPosition);

	#if DEBUG
			//we only reset the data in debug mode for performance reasons
			var fourthPosition = Enumerable.Range(0, 128).Select(x =>   Position(0)).ToArray();
			var fourthSetPosition = span.Slice(Entity.ENTITY_MAX - 128, 128).ToArray();
			fourthSetPosition.ShouldBe(fourthPosition);
	#endif

			entityChunk.Count.ShouldBe(Entity.ENTITY_MAX - 128);
			entityChunk.Free.ShouldBe(128);
		}*/

	}
}