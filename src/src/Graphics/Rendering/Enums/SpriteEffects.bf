namespace Atma
{
	public enum SpriteEffects
	{
		case None = 0;
		case Vert = 1;
		case Hort = 2;

		public static SpriteEffects Flip(bool flipX, bool flipY) => (flipX ? .Hort : .None) | (flipY ? .Vert : .None);

		public void Apply(ref float2[4] texCoordsIn, float2 t0, float2 t1, float2 t2, float2 t3)
		{
			/*switch(this){
			case .None:
				texCoordsIn = texCoordsOut;
			case .Vert:
				texCo
			}*/
			if (this == .None)
			{
				texCoordsIn[0] = t0;
				texCoordsIn[1] = t1;
				texCoordsIn[2] = t2;
				texCoordsIn[3] = t3;
			}
			else
			{
				if ((this & .Vert) == .Vert)
				{
					texCoordsIn[0].y = t3.y;
					texCoordsIn[1].y = t2.y;
					texCoordsIn[2].y = t1.y;
					texCoordsIn[3].y = t0.y;
				}
				else
				{
					texCoordsIn[0].y = t0.y;
					texCoordsIn[1].y = t1.y;
					texCoordsIn[2].y = t2.y;
					texCoordsIn[3].y = t3.y;
				}

				if ((this & .Hort) == .Hort)
				{
					texCoordsIn[0].x = t1.x;
					texCoordsIn[1].x = t0.x;
					texCoordsIn[2].x = t3.x;
					texCoordsIn[3].x = t2.x;
				}
				else
				{
					texCoordsIn[0].x = t0.x;
					texCoordsIn[1].x = t1.x;
					texCoordsIn[2].x = t2.x;
					texCoordsIn[3].x = t3.x;
				}
			}
		}
	}
}
