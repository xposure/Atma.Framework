namespace Atma
{
	using System;
	using System.Collections;

	public class EntitySpecTests
	{
		public struct Valid
		{
			public int X, Y;
			public override void ToString(String output)
			{
				output.Append(scope $"X: {X}, Y: {Y}");
			}
		}

		public struct Valid2
		{
			public int Z;
			public override void ToString(String output)
			{
				output.Append(scope $"Z: {Z}");
			}
		}

		public struct Valid3
		{
			public int W;
			public override void ToString(String output)
			{
				output.Append(scope $"W: {W}");
			}
		}

		public struct Valid4
		{
			public int _;

			public override void ToString(String output)
			{
				output.Append(scope $"_: {_}");
			}
		}

		public struct Valid5
		{
			public int _;
			public override void ToString(String output)
			{
				output.Append(scope $"_: {_}");
			}

		}

		public struct Valid6
		{
			public int _;
			public override void ToString(String output)
			{
				output.Append(scope $"_: {_}");
			}

		}

		public struct Invalid
		{
			public Object obj;
			public override void ToString(String output)
			{
				output.Append(scope $"*");
			}
		}

		public struct GroupA : IHashable
		{
			public int HashCode;

			public int GetHashCode() => HashCode;
		}

		public struct GroupB : IHashable
		{
			public int HashCode;

			public int GetHashCode() => HashCode;
		}


		public static void ShouldGenerateSameHashcode()
		{
			var specs = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type),
				scope EntitySpec(ComponentType<Valid2>.Type, ComponentType<Valid>.Type, ComponentType<Valid3>.Type),
				scope EntitySpec(ComponentType<Valid3>.Type, ComponentType<Valid>.Type, ComponentType<Valid2>.Type)
				);

			for (var x = 0; x < specs.Count - 1; x++)
			{
				var a1 = specs[x];
				for (var y = x + 1; y < specs.Count; y++)
				{
					var a2 = specs[y];
					Contract.EqualTo(a1.EntitySize, a2.EntitySize);
					Contract.EqualTo(a1.ID, a2.ID);
				}
			}
		}

		public static void ShouldHaveAll()
		{
			var spec = scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid4>.Type);

			var valid = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type),
				scope EntitySpec(ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid>.Type),
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid4>.Type)
				);

			for (var i = 0; i < valid.Count; i++)
				Assert.IsTrue(spec.HasAll(valid[i]));

			var invalid = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid6>.Type),
				scope EntitySpec(ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid6>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid5>.Type, ComponentType<Valid>.Type, ComponentType<Valid4>.Type, ComponentType<Valid6>.Type),
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid5>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid6>.Type)
				);

			for (var i = 0; i < invalid.Count; i++)
				Assert.IsFalse(spec.HasAll(invalid[i]));

			var spec0 = scope EntitySpec(ComponentType<Valid6>.Type);
			var spec1 = scope EntitySpec(ComponentType<Valid>.Type);
			Assert.IsFalse(spec0.HasAll(spec1));
		}

		[Test]
		public static void ShouldHaveAny()
		{
			var spec = scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid4>.Type
				);

			var valid = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type),
				scope EntitySpec(ComponentType<Valid2>.Type, ComponentType<Valid6>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid4>.Type),
				scope EntitySpec(ComponentType<Valid>.Type),
				scope EntitySpec(ComponentType<Valid5>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid4>.Type)
				);

			for (var i = 0; i < valid.Count; i++)
				Assert.IsTrue(spec.HasAll(valid[i]));

			var invalid = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid6>.Type),
				scope EntitySpec(ComponentType<Valid5>.Type),
				scope EntitySpec(ComponentType<Valid6>.Type, ComponentType<Valid5>.Type)
				);

			for (var i = 0; i < invalid.Count; i++)
				Assert.IsFalse(spec.HasAll(invalid[i]));
		}


		[Test]
		public static void SpecShouldFindMatches()
		{
			var specs = scope EntitySpec[]
				(
				scope EntitySpec(ComponentType<Valid>.Type, ComponentType<Valid2>.Type, ComponentType<Valid6>.Type, ComponentType<Valid5>.Type),
				scope EntitySpec(ComponentType<Valid4>.Type, ComponentType<Valid2>.Type, ComponentType<Valid3>.Type, ComponentType<Valid5>.Type),
				scope EntitySpec(ComponentType<Valid6>.Type, ComponentType<Valid3>.Type, ComponentType<Valid>.Type, ComponentType<Valid4>.Type)
				);

			Span<ComponentType> componentTypes0 = scope ComponentType[8];
			var c0 = specs[0].FindMatches(specs[1], componentTypes0);
			var m0 = scope List<ComponentType>(componentTypes0.Slice(0, c0));
			var c1 = specs[1].FindMatches(specs[2], componentTypes0);
			var m1 = scope List<ComponentType>(componentTypes0.Slice(0, c1));
			var c2 = specs[2].FindMatches(specs[0], componentTypes0);
			var m2 = scope List<ComponentType>(componentTypes0.Slice(0, c2));


			Assert.EqualTo(m0.Any( (x) => x.ID == ComponentType<Valid2>.Type.ID), true);
			Assert.EqualTo(m0.Any( (x) => x.ID == ComponentType<Valid5>.Type.ID), true);
			Assert.EqualTo(m0.Any( (x) => x.ID == ComponentType<Valid>.Type.ID), false);
			Assert.EqualTo(m0.Any( (x) => x.ID == ComponentType<Valid3>.Type.ID), false);
			Assert.EqualTo(m0.Any( (x) => x.ID == ComponentType<Valid6>.Type.ID), false);

			Assert.EqualTo(m1.Any( (x) => x.ID == ComponentType<Valid4>.Type.ID), true);
			Assert.EqualTo(m1.Any( (x) => x.ID == ComponentType<Valid3>.Type.ID), true);
			Assert.EqualTo(m1.Any( (x) => x.ID == ComponentType<Valid>.Type.ID), false);
			Assert.EqualTo(m1.Any( (x) => x.ID == ComponentType<Valid6>.Type.ID), false);
			Assert.EqualTo(m1.Any( (x) => x.ID == ComponentType<Valid2>.Type.ID), false);

			Assert.EqualTo(m2.Any( (x) => x.ID == ComponentType<Valid6>.Type.ID), true);
			Assert.EqualTo(m2.Any( (x) => x.ID == ComponentType<Valid>.Type.ID), true);
			Assert.EqualTo(m2.Any( (x) => x.ID == ComponentType<Valid3>.Type.ID), false);
			Assert.EqualTo(m2.Any( (x) => x.ID == ComponentType<Valid4>.Type.ID), false);
			Assert.EqualTo(m2.Any( (x) => x.ID == ComponentType<Valid2>.Type.ID), false);
		}

		[Test]
		public static void EntitySpecGroupShouldMatch()
		{
			var a = scope EntitySpec(
				scope IHashable[](scope GroupA() { HashCode = 1 }), ComponentType<Valid>.Type, ComponentType<Valid2>.Type);

			var b = scope EntitySpec(
				scope IHashable[](scope GroupA() { HashCode = 1 }), ComponentType<Valid2>.Type, ComponentType<Valid>.Type);

			Assert.EqualTo(a.ID, b.ID);
			Assert.EqualTo(a.GetGroupData<GroupA>().HashCode, 1);
			Assert.EqualTo(b.GetGroupData<GroupA>().HashCode, 1);
		}

		[Test]
		public static void EntitySpecGroupShouldMatchAll()
		{
			var a = scope EntitySpec(
				scope IHashable[](
				scope GroupA() { HashCode = 1 },
				scope GroupB() { HashCode = 2 }), ComponentType<Valid>.Type, ComponentType<Valid2>.Type);

			var b = scope EntitySpec(
				scope IHashable[](
				scope GroupB() { HashCode = 2 },
				scope GroupA() { HashCode = 1 }), ComponentType<Valid2>.Type, ComponentType<Valid>.Type);

			Assert.EqualTo(a.ID, b.ID);
			Assert.EqualTo(a.GetGroupData<GroupA>().HashCode, 1);
			Assert.EqualTo(b.GetGroupData<GroupA>().HashCode, 1);
			Assert.EqualTo(a.GetGroupData<GroupB>().HashCode, 2);
			Assert.EqualTo(b.GetGroupData<GroupB>().HashCode, 2);
		}

		[Test]
		public static void EntitySpecGroupShouldNotMatchHash()
		{
			var a = scope EntitySpec(
				scope IHashable[](
				scope GroupA() { HashCode = 1 }), ComponentType<Valid>.Type, ComponentType<Valid2>.Type);
			var b = scope EntitySpec(
				scope IHashable[](
				scope
				GroupA() { HashCode = 2 }), ComponentType<Valid2>.Type, ComponentType<Valid>.Type);

			Assert.EqualTo(a.ID, b.ID);
			Assert.EqualTo(a.GetGroupData<GroupA>().HashCode, 1);
			Assert.EqualTo(b.GetGroupData<GroupA>().HashCode, 2);
		}

		[Test]
		public static void EntitySpecGroupShouldNotMatchDifferentGroup()
		{
			var a = scope EntitySpec(
				scope IHashable[](
				scope GroupA() { HashCode = 1 }), ComponentType<Valid>.Type, ComponentType<Valid2>.Type);
			var b = scope EntitySpec(
				scope IHashable[](scope
				GroupB() { HashCode = 1 }), ComponentType<Valid2>.Type, ComponentType<Valid>.Type);

			Assert.EqualTo(a.ID, b.ID);
			Assert.EqualTo(a.GetGroupData<GroupA>().HashCode, 1);
			Assert.EqualTo(b.GetGroupData<GroupB>().HashCode, 1);
		}
	}
}