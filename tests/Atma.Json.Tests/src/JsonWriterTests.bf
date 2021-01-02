using System;
using System.IO;
namespace Atma
{
	public class JsonWriterTests
	{
		[Test]
		public static void WriteObject()
		{
			var vec2 = vec2<int>();
			vec2.x = 1;
			vec2.y = 2;


			let json = scope String();
			let stream = scope StringStream(json, .Reference);
			let writer = scope JsonWriter();
			writer.Write(stream, vec2);

			Assert.EqualTo(json, "{\"x\":1,\"y\":2}");
		}

		[Test]
		public static void WriteObjectWithArray()
		{
			var data = scope ArrayTest(1, 2, 3, 4, 5);

			let json = scope String();
			let stream = scope StringStream(json, .Reference);
			let writer = scope JsonWriter();
			writer.Write(stream, data);

			Assert.EqualTo(json, "{\"data\":[1,2,3,4,5]}");
		}

		[Test]
		public static void WriteObjectWithSizedArray()
		{
			var data = scope SizedArrayTest(1, 2, 3, 4, 5);

			let json = scope String();
			let stream = scope StringStream(json, .Reference);
			let writer = scope JsonWriter();
			writer.Write(stream, data);

			Assert.EqualTo(json, "{\"data\":[1,2,3,4,5]}");
		}
	}
}
