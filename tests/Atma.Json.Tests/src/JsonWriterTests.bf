using System;
using System.IO;
namespace Atma
{
	public class JsonWriterTests
	{
		[Test]
		public static void Test()
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
	}
}
