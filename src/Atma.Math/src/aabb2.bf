namespace Atma
{
	using System;
	using System.Diagnostics;

	/// <summary>
	///		A 2D box aligned with the x/y axes.
	/// </summary>
	/// <remarks>
	///		This class represents a simple box which is aligned with the
	///	    axes. This class is typically used
	///	    for an axis-aligned bounding box (AABB) for collision and
	///	    visibility determination.
	/// </remarks>
	public struct aabb2 : IHashable
	{
		#region Fields

		public float2 Min;
		public float2 Max;

		#endregion Fields

		#region Constructors

		public this(float x0, float y0, float x1, float y1) : this(.(x0, y0), .(x1, y1))
		{
		}

		public this(float2 min, float2 max)
		{
			Min = min;
			Max = max;
		}

		public this(aabb2 other)
		{
			Min = other.Min;
			Max = other.Max;
		}

		#endregion Constructors

		#region Public methods

		public float Height
		{
			get { return Max.y - Min.y; }
		}

		public float Width
		{
			get { return Max.x - Min.x; }
		}

		public float2 this[int index]
		{
			get
			{
				switch (index) {
				case 0: return TopLeft;
				case 1: return TopRight;
				case 2: return BottomRight;
				case 3: return BottomLeft;
				default:
					Runtime.FatalError("Index out of range.");
				}
			}
		}

		public float x0 { get { return Min.x; } }

		public float x1 { get { return Max.x; } }

		public float y0 { get { return Min.y; } }

		public float y1 { get { return Max.y; } }

		public float2 xy => Min.xy;

		public float2 TopLeft => .(x0, y0);
		public float2 TopRight => .(x1, y0);
		public float2 BottomLeft => .(x0, y1);
		public float2 BottomRight => .(x1, y1);

		/// <summary>
		///     Return new bounding box from the supplied dimensions.
		/// </summary>
		/// <param name="center">Center of the new box</param>
		/// <param name="size">Entire size of the new box</param>
		/// <returns>New bounding box</returns>
		public static aabb2 FromDimensions(float2 center, float2 size)
		{
			float2 halfSize = 0.5f * size;

			return .(center - halfSize, center + halfSize);
		}

		// public static AxisAlignedBox2 FromRect(Rectangle rect)
		// {
		//     var min = .(rect.x, rect.y);
		//     var max = .(rect.Width, rect.Height) + min;
		//     return .(min, max);
		// }

		public static aabb2 FromRect(float x, float y, float w, float h)
		{
			var min = float2(x, y);
			var max = float2(w, h) + min;
			return .(min, max);
		}

		public static aabb2 FromRect(float2 min, float w, float h)
		{
			var max = float2(w, h) + min;
			return .(min, max);
		}

		public static aabb2 FromRect(float2 min, float2 size)
		{
			return .(min, min + size);
		}

		public aabb2 Inflate(float x, float y) => Inflate(.(x, y));

		public aabb2 Inflate(float2 size)
		{
			let half = size / 2f;
			return .(Min - half, Max + half);
		}

		/// <summary>
		///		Allows for merging two boxes together (combining).
		/// </summary>
		/// <param name="box">Source box.</param>
		public void Merge(aabb2 other) mut
		{
			if (other.Min.x < Min.x)
				Min.x = other.Min.x;
			if (other.Max.x > Max.x)
				Max.x = other.Max.x;

			if (other.Min.y < Min.y)
				Min.y = other.Min.y;
			if (other.Max.y > Max.y)
				Max.y = other.Max.y;
		}

		/// <summary>
		///		Extends the box to encompass the specified point (if needed).
		/// </summary>
		/// <param name="point"></param>
		public void Merge(float2 point) mut
		{
			if (point.x > Max.x)
				Max.x = point.x;
			else if (point.x < Min.x)
				Min.x = point.x;

			if (point.y > Max.y)
				Max.y = point.y;
			else if (point.y < Min.y)
				Min.y = point.y;
		}

		/// <summary>
		///    Scales the size of the box by the supplied factor.
		/// </summary>
		/// <param name="factor">Factor of scaling to apply to the box.</param>
		public void Scale(float2 factor) mut
		{
			SetExtents(Min * factor, Max * factor);
		}

		/// <summary>
		///		Sets both Minimum and Maximum at once, so that UpdateCorners only
		///		needs to be called once as well.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public void SetExtents(float2 min, float2 max) mut
		{
			Min = min;
			Max = max;
		}

		public aabb2 Offset(float2 offset) => .(Min + offset, Max + offset);

		#endregion Public methods

		#region Contain methods

		/// <summary>
		/// Tests whether the given point contained by this box.
		/// </summary>
		/// <param name="v"></param>
		/// <returns>True if the vector is contained inside the box.</returns>
		public bool Contains(float2 v)
		{
			return Min.x <= v.x && v.x <= Max.x &&
				Min.y <= v.y && v.y <= Max.y;
		}

		public bool Contains(aabb2 other)
		{
			return Contains(other.Min) && Contains(other.Max);
		}

		#endregion Contain methods

		#region Intersection Methods

		public mtv Collide(aabb2 box2)
		{
			if (Intersection(box2, let overlap))
			{
				var axis = axis();
				var minOverlap = 0.0;
				let adjust = overlap.Size;

				if (adjust.x < adjust.y)
				{
					minOverlap = adjust.x;
					if (overlap.Center.x < box2.Center.x)
						axis.edge = .(overlap.x0, overlap.y0) - .(overlap.x0, overlap.y1);
					else
						axis.edge = .(overlap.x1, overlap.y1) - .(overlap.x1, overlap.y0);
				}
				else
				{
					minOverlap = adjust.y;
					if (overlap.Center.y > box2.Center.y)
						axis.edge = .(overlap.x0, overlap.y0) - .(overlap.x1, overlap.y0);
					else
						axis.edge = .(overlap.x1, overlap.y1) - .(overlap.x0, overlap.y1);
				}

				axis.unit = axis.edge.Perpendicular;
				//axis.unit = axis.edge.PerpendicularRight;
				axis.normal = axis.unit.Normalized;
				return .(axis, minOverlap);
			}
			return .Zero;
		}

		public mtv CollideX(aabb2 box2)
		{
			//var overlap = Intersection(box2);
			if (Intersection(box2, let overlap))
			{
				var axis = axis();
				var minOverlap = 0.0;
				var adjust = overlap.Size;

				minOverlap = adjust.x;
				if (overlap.Center.x < box2.Center.x)
					axis.edge = .(overlap.x0, overlap.y0) - .(overlap.x0, overlap.y1);
				else
					axis.edge = .(overlap.x1, overlap.y1) - .(overlap.x1, overlap.y0);

				//axis.unit = axis.edge.PerpendicularRight;
				axis.unit = axis.edge.Perpendicular;
				axis.normal = axis.unit.Normalized;
				return .(axis, minOverlap);
			}
			return .Zero;
		}

		public mtv CollideY(aabb2 box2)
		{
			//var overlap = Intersection(box2);
			if (Intersection(box2, let overlap))
			{
				var axis = axis();
				var minOverlap = 0.0;
				var adjust = overlap.Size;

				minOverlap = adjust.y;
				if (overlap.Center.y > box2.Center.y)
					axis.edge = .(overlap.x0, overlap.y0) - .(overlap.x1, overlap.y0);
				else
					axis.edge = .(overlap.x1, overlap.y1) - .(overlap.x0, overlap.y1);

				//axis.unit = axis.edge.PerpendicularRight;
				axis.unit = axis.edge.Perpendicular;
				axis.normal = axis.unit.Normalized;
				return .(axis, minOverlap);
			}
			return .Zero;
		}

		public aabb2 Intersection(aabb2 b2)
		{
			if (Intersection(b2, let result))
				return result;

			return .(float2.Zero, float2.Zero);
		}

		/// <summary>
		///		Calculate the area of intersection of this box and another
		/// </summary>
		public bool Intersection(aabb2 b2, out aabb2 intersection)
		{
			if (!Intersects(b2))
			{
				intersection = .(float2.Zero, float2.Zero);
				return false;
			}

			float2 intMin = float2.Zero;
			float2 intMax = float2.Zero;

			float2 b2max = b2.Max;
			float2 b2min = b2.Min;

			if (b2max.x > Max.x && Max.x > b2min.x)
				intMax.x = Max.x;
			else
				intMax.x = b2max.x;
			if (b2max.y > Max.y && Max.y > b2min.y)
				intMax.y = Max.y;
			else
				intMax.y = b2max.y;

			if (b2min.x < Min.x && Min.x < b2max.x)
				intMin.x = Min.x;
			else
				intMin.x = b2min.x;
			if (b2min.y < Min.y && Min.y < b2max.y)
				intMin.y = Min.y;
			else
				intMin.y = b2min.y;

			intersection = .(intMin, intMax);
			return true;
		}

		/// <summary>
		///		Returns whether or not this box intersects another.
		/// </summary>
		/// <param name="box2"></param>
		/// <returns>True if the 2 boxes intersect, false otherwise.</returns>
		public bool Intersects(aabb2 box2)
		{
			// Use up to 6 separating planes
			if (this.Max.x <= box2.Min.x)
				return false;
			if (this.Max.y <= box2.Min.y)
				return false;

			if (this.Min.x >= box2.Max.x)
				return false;
			if (this.Min.y >= box2.Max.y)
				return false;

			// otherwise, must be intersecting
			return true;
		}

		/// <summary>
		///		Returns whether or not this box intersects another.
		/// </summary>
		/// <param name="box2"></param>
		/// <returns>True if the 2 boxes intersect, false otherwise.</returns>
		public bool Intersects(Span<aabb2> boxes, out int index)
		{
			index = -1;
			for (var i = 0; i < boxes.Length; i++)
			{
				if (this.Intersects(boxes[i]))
				{
					index = i;
					return true;
				}
			}
			return false;
		}

		[Inline]
		public bool Intersects(Line2f line) => line.Intersects(this);


		//
		//
		//
		//
		//
		//
		// //https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-box-intersection
		/*class Ray 
		{ 
		public: 
			Ray(const Vec3f &orig, const Vec3f &dir) : orig(orig), dir(dir) 
			{ 
				invdir = 1 / dir; 
				sign[0] = (invdir.x < 0); 
				sign[1] = (invdir.y < 0); 
				sign[2] = (invdir.z < 0); 
			} 
			Vec3 orig, dir;       // ray orig and dir 
			Vec3 invdir; 
			int sign[3]; 
		}; 
		 
		bool intersect(const Ray &r) const 
		{ 
			float tmin, tmax, tymin, tymax, tzmin, tzmax; 
		 
			tmin = (bounds[r.sign[0]].x - r.orig.x) * r.invdir.x; 
			tmax = (bounds[1-r.sign[0]].x - r.orig.x) * r.invdir.x; 
			tymin = (bounds[r.sign[1]].y - r.orig.y) * r.invdir.y; 
			tymax = (bounds[1-r.sign[1]].y - r.orig.y) * r.invdir.y; 
		 
			if ((tmin > tymax) || (tymin > tmax)) 
				return false; 
			if (tymin > tmin) 
				tmin = tymin; 
			if (tymax < tmax) 
				tmax = tymax; 
		 
			tzmin = (bounds[r.sign[2]].z - r.orig.z) * r.invdir.z; 
			tzmax = (bounds[1-r.sign[2]].z - r.orig.z) * r.invdir.z; 
		 
			if ((tmin > tzmax) || (tzmin > tmax)) 
				return false; 
			if (tzmin > tmin) 
				tmin = tzmin; 
			if (tzmax < tmax) 
				tmax = tzmax; 
		 
			return true; 
		}*/

		// public bool Intersects(Circle circle)
		// {
		//     return Intersects(circle.Center) ||
		//         circle.Intersects(corners[0]) ||
		//         circle.Intersects(corners[1]) ||
		//         circle.Intersects(corners[2]) ||
		//         circle.Intersects(corners[3]);
		// }

		/// <summary>
		///		Tests whether this box intersects a sphere.
		/// </summary>
		/// <param name="sphere"></param>
		/// <returns>True if the sphere intersects, false otherwise.</returns>
		//public bool Intersects(Sphere sphere)
		//{
		//    return Utility.Intersects(sphere, this);
		//}

		/// <summary>
		///
		/// </summary>
		/// <param name="plane"></param>
		/// <returns>True if the plane intersects, false otherwise.</returns>
		//public bool Intersects(Plane plane)
		//{
		//    return Utility.Intersects(plane, this);
		//}

		/// <summary>
		///		Tests whether the vector point is within this box.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns>True if the vector is within this box, false otherwise.</returns>
		public bool Intersects(float2 vector)
		{
			return (vector.x >= Min.x && vector.x <= Max.x &&
				vector.y >= Min.y && vector.y <= Max.y);
		}

		#endregion Intersection Methods

		#region Properties

		/// <summary>
		///    Get/set the center point of this bounding box.
		/// </summary>
		public float2 Center
		{
			get
			{
				return (Min + Max) * 0.5f;
			}
			set mut
			{
				float2 halfSize = 0.5f * Size;
				Min = value - halfSize;
				Max = value + halfSize;
			}
		}

		public float2 HalfSize
		{
			get
			{
				return (Max - Min) * 0.5f;
			}
		}

		/// <summary>
		///     Get/set the size of this bounding box.
		/// </summary>
		public float2 Size
		{
			get
			{
				return Max - Min;
			}
			set mut
			{
				float2 center = Center;
				float2 halfSize = 0.5f * value;
				Min = center - halfSize;
				Max = center + halfSize;
			}
		}

		/// <summary>
		///     Calculate the volume of this box
		/// </summary>
		public float Volume
		{
			get
			{
				float2 diff = Max - Min;
				return diff.x * diff.y;
			}
		}

		#endregion Properties

		#region Operator Overloads

		public static bool operator!=(aabb2 left, aabb2 right)
		{
			return left.Min != right.Min || left.Max != right.Max;
		}

		public static bool operator==(aabb2 left, aabb2 right)
		{
			return left.Min == right.Min && left.Max == right.Max;
		}

		[Unchecked]
		public int GetHashCode()
		{
			return (Min.GetHashCode() * 397) + Max.GetHashCode();
		}

		public override void ToString(String output)
		{
			output.AppendF("{0}:{1}", this.Min, this.Max);
		}

		#endregion Operator Overloads

		// public AxisAlignedBox2[] fromRectOffset(RectOffset offset)
		// {
		//     var inner = .(m_minVector + offset.min, m_maxVector - offset.max);

		//     var rects = .[9];

		//     rects[0] = .(corners[0], inner.corners[0]);
		//     rects[2] = .(Utility.Min(corners[1], inner.corners[1]), Utility.Max(corners[1], inner.corners[1]));
		//     rects[6] = .(Utility.Min(corners[3], inner.corners[3]), Utility.Max(corners[3], inner.corners[3]));
		//     rects[8] = .(inner.corners[2], corners[2]);

		//     rects[1] = .(rects[0].corners[1], inner.corners[1]);
		//     rects[3] = .(rects[0].corners[3], inner.corners[3]);
		//     rects[4] = inner;
		//     rects[5] = .(rects[2].corners[3], rects[8].corners[1]);
		//     rects[7] = .(rects[6].corners[1], rects[8].corners[3]);
		//     return rects;
		// }



		//public void RotateAndContain(float2 pivot, float r)
		//{
		//    if (!isNull && !isInfinite && r != 0)
		//    {
		//        var rotatedCorners = this.ToOBB(pivot, r);
		//        var center = (rotatedCorners[0] + rotatedCorners[1] + rotatedCorners[2] + rotatedCorners[3]) / 4f;
		//        this.m_minVector = center;
		//        this.m_maxVector = center;
		////        UpdateCorners();

		//        this.Merge(rotatedCorners[0]);
		//        this.Merge(rotatedCorners[1]);
		//        this.Merge(rotatedCorners[2]);
		//        this.Merge(rotatedCorners[3]);
		//    }
		//}

		// public Rectangle ToRect()
		// {
		//     return new Rectangle((int)minVector.x, (int)minVector.y, (int)Width, (int)Height);
		// }

		//public float2[] ToOBB(float2 pivot, float r)
		//{
		//    if (!isNull && !isInfinite && r != 0)
		//    {
		//        var rotatedCorners = .[4];
		//        for (var i = 0; i < corners.Length; i++)
		//        {
		//            rotatedCorners[i] = corners[i].Rotate(pivot, r);
		//        }
		//        return rotatedCorners;
		//    }
		//    return corners;
		//}

		//public Rectangle ToRect()
		//{
		//    if (IsNull)
		//        throw new NullReferenceException();

		//    return new Rectangle((int)m_minVector.x, (int)m_minVector.y, (int)(m_maxVector.x- m_minVector.x),
	// (int)(m_maxVector.y- m_minVector.y)); }

		public void Rotate(float2 point, float angleInTurns, out float2[4] rotatedPoints)
		{
			rotatedPoints = default;

			rotatedPoints[0] = float2.Rotate(this.TopLeft, point, angleInTurns);
			rotatedPoints[1] = float2.Rotate(this.TopRight, point, angleInTurns);
			rotatedPoints[2] = float2.Rotate(this.BottomRight, point, angleInTurns);
			rotatedPoints[3] = float2.Rotate(this.BottomLeft, point, angleInTurns);
		}

		public rect ToRect()
		{
			return rect((.)x0, (.)y0, (.)Size);
		}
	}
}