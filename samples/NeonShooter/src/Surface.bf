/*using Atma;
using Atma.Math;
using System;
using GameSim.Materials;
namespace GameSim
{
	public enum SurfaceStretch
	{
		case Fixed(int width, int height);
		case FixedHeight(int height);
		case FixedWidth(int width);

		public void Calculate(int2 targetSize, float maxAspectRatio, out int2 size, out float2 renderOffset, out float2 renderSize, out float pixelSize)
		{
			switch (this) {
			case .Fixed(let width, let height):
				size = .(width, height);
				renderOffset = .(0, 0);
				pixelSize = 1;
				renderSize = size;
			case .FixedHeight(var ideal_height):
				//var aspect_ratio = targetSize.x / (float)targetSize.y;
				pixelSize = targetSize.y / (float)ideal_height;

				var target_width = (int)(targetSize.x / pixelSize);
				//var target_width = (int)(ideal_height * aspect_ratio);

				/*if ((target_width & 1) == 1) target_width++;
				if ((ideal_height & 1) == 1) ideal_height++;*/

				var ideal_width = Math.Min(target_width, (int)(ideal_height * maxAspectRatio));
				size = .(ideal_width, ideal_height);
				pixelSize = targetSize.y / (float)size.y;

				let scaledWidth = size.x * pixelSize;
				renderOffset = float2(targetSize.x - scaledWidth, 0) / 2;
				renderSize = (float2)size * pixelSize;

			case .FixedWidth(var ideal_width):
				//var aspect_ratio = targetSize.x / (float)targetSize.y;

				pixelSize = targetSize.x / (float)ideal_width;

				var target_height = (int)(targetSize.y / pixelSize);

				/*if ((target_height & 1) == 1) target_height++;
				if ((ideal_width & 1) == 1) ideal_width++;*/

				var ideal_height = Math.Min(target_height, (int)(ideal_width * maxAspectRatio));
				size = .(ideal_width, ideal_height);

				let scaledHeight = size.y * pixelSize;
				renderOffset = float2(0, targetSize.y - scaledHeight) / 2;
				renderSize = (float2)size * pixelSize;
			}
		}
	}

	public class Surface
	{
		private static int NextId;

		private Batch2D batch ~ delete _;
		private ScaleToTargetMaterial scaleToTarget ~ delete _;
		private RenderTexture renderTarget ~ delete _;
		private Camera camera ~ delete _;
		private DynamicMesh<float2> renderMesh ~ delete _;
		private VertexFormat vertexFormat ~ delete _;
		private String name = new .() ~ delete _;

		private int2 size;
		private int2 targetSize;
		private float2 renderOffset;
		private float2 renderSize;
		private float pixelSize;

		private SurfaceStretch stretch;

		public int2 Size => size;

		public float2 Offset;
		public int32 Scale;

		public float2 ScaledOffset => Offset * Scale;

		public Texture Texture => renderTarget.ColorAttachment;

		public Camera Camera => camera;

		public int2 ScaledSize => size * Scale;

		public readonly float MaxAspectRatio = 2;
		public float2 Center => Offset + Size / 2;

		public SurfaceStretch Stretch
		{
			get => stretch;
			set => Resize(value, targetSize);
		}

		public int2 TargetSize
		{
			get => targetSize;
			set => Resize(stretch, value);
		}


		public this(StringView name, SurfaceStretch stretch, int2 targetSize, int32 scale = 1, float maxAspectRatio = 2) : this(stretch, targetSize, scale, maxAspectRatio)
		{
			this.name.Set(name);
		}

		public this(SurfaceStretch stretch, int2 targetSize, int32 scale = 1, float maxAspectRatio = 2)
		{
			this.batch = new .();
			this.name.Set(scope $"Surface {NextId++}");

			vertexFormat = new VertexFormat(.("a_position", VertexAttrib.Position, VertexType.Float, VertexComponents.Two, false));
			renderMesh = new DynamicMesh<float2>(vertexFormat, 4, 6);
			scaleToTarget = new .();

			MaxAspectRatio = maxAspectRatio;
			this.Scale = scale;
			this.targetSize = targetSize;
			this.stretch = stretch;

			UpdateCameraAndTargets();
		}

		private void Resize(SurfaceStretch stretch, int2 targetSize)
		{
			if (this.targetSize != targetSize || this.stretch != stretch)
			{
				this.targetSize = targetSize;
				this.stretch = stretch;

				UpdateCameraAndTargets();
			}
		}

		private void UpdateCameraAndTargets()
		{
			this.stretch.Calculate(targetSize, MaxAspectRatio, out size, out renderOffset, out renderSize, out pixelSize);
			if (camera == null)
			{
				camera = new .(ScaledSize);
				camera.Scale = Scale;
			}
			else
			{
				camera.Size = ScaledSize;
				camera.Scale = Scale;
			}

			if (renderTarget == null)
			{
				renderTarget = new .(ScaledSize);
				renderTarget.ColorAttachment.Filter = .Linear;
			}
			else
				renderTarget.Resize(ScaledSize);


			renderMesh.Clear();

			let pixels = renderMesh.Quad();
			let rect = aabb2.FromRect(renderOffset, renderSize);
			for (var i < pixels.Length)
				pixels[i] = rect[i];

			renderMesh.Commit();
		}

		public void SetAndClear()
		{
			batch.Clear();
			Screen = this;
		}

		public void Render()
		{
			GraphicsManager.Current.Clear(renderTarget, .CornflowerBlue);
			camera.Entity.Position = float2.Fract(Offset);
			camera.Render(renderTarget, batch);
			batch.Clear();
		}

		public void RenderTo(RenderTarget target)
		{
			let camera = scope Camera(target.RenderSize);

			scaleToTarget.Matrix = camera.ProjectionViewMatrix;
			scaleToTarget.Resolution = ScaledSize;
			scaleToTarget.PixelSize = pixelSize / Scale;
			scaleToTarget.Offset = renderOffset;
			scaleToTarget.Texture = Texture;

			renderMesh.Render(target, scaleToTarget, camera.Viewport);
		}

		public float2 ScreenToSurface(float2 position)
		{
			var position;
			let scale = ScaledSize / (float2)Core.Window.RenderSize;
			position *= scale;
			//position -= Offset;

			return camera.ScreenToWorld(position) + Offset;
		}

		[Inline]
		public void Image(DrawArgs args) => batch.Image(args, (int2)Offset);

		public void Draw(float2 position, Subtexture texture)
		{
			batch.Image(texture, position - (int2)Offset, Color.White);
		}

		public void Draw(int x, int y, Subtexture texture)
		{
			batch.Image(texture, int2(x, y) - (int2)Offset, Color.White);
		}

		public void Line(float2 start, float2 end, float thickness = 1, Color color = .White)
		{
			batch.Line(start - (int2)Offset, end - (int2)Offset, thickness, color);
		}

		public void Rect(float2 pos, float2 size, Color color = .White)
		{
			batch.Rect(aabb2.FromRect(pos - (int2)Offset, size), color);
		}

		public void HollowRect(aabb2 rect, float t = 1f, Color color = .White)
		{
			batch.HollowRect(aabb2.FromRect(rect.TopLeft - (int2)Offset, rect.Size), t, color);
		}

		public void HollowRect(float2 pos, float2 size, float t = 1f, Color color = .White)
		{
			batch.HollowRect(aabb2.FromRect(pos - (int2)Offset, size), t, color);
		}

		public void Circle(float2 pos, float r, Color color = .White, int segments = 12)
		{
			batch.Circle(pos - (int2)Offset, r, segments, color);
		}

		public void Quad(float2 p0, float2 p1, float2 p2, float2 p3, Color color = .White)
		{
			batch.Quad(
				p0 - (int2)Offset,
				p1 - (int2)Offset,
				p2 - (int2)Offset,
				p3 - (int2)Offset,
				color, color, color, color);
		}

		public void Quad(float2 p0, float2 p1, float2 p2, float2 p3, Color c0, Color c1, Color c2, Color c3)
		{
			batch.Quad(
				p0 - (int2)Offset,
				p1 - (int2)Offset,
				p2 - (int2)Offset,
				p3 - (int2)Offset,
				c0, c1, c2, c3);
		}

		public void Quad(float2 p0, float2 p1, float2 p2, float2 p3, float2 t0, float2 t1, float2 t2, float2 t3, Color color = .White)
		{
			batch.Quad(
				p0 - (int2)Offset,
				p1 - (int2)Offset,
				p2 - (int2)Offset,
				p3 - (int2)Offset,
				t0, t1, t2, t3,
				color, color, color, color);
		}

		public void Quad(float2 p0, float2 p1, float2 p2, float2 p3, float2 t0, float2 t1, float2 t2, float2 t3, Color c0, Color c1, Color c2, Color c3)
		{
			batch.Quad(
				p0 - (int2)Offset,
				p1 - (int2)Offset,
				p2 - (int2)Offset,
				p3 - (int2)Offset,
				t0, t1, t2, t3,
				c0, c1, c2, c3);
		}

		public void DrawText(SpriteFont font, float2 position, StringView text, Color color = Color.White, float2 scale = .Ones)
		{
			batch.Text(font, (int2)(position - Offset), text, color, scale);
		}

		public void DrawText(float2 position, SpriteFont font, StringView text) {
			batch.Text(font, (int2)(position - Offset), text, .White, float2.Ones);
		}

		public void DrawText(int x, int y, SpriteFont font, StringView text)
		{
			batch.Text(font, .(x, y) - (int2)Offset, text, .White, float2.Ones);
		}

		public void Debug()
		{
			if (ig.CollapsingHeader(name))
			{
				if (ig.BeginChild(name, default, true))
				{
					var renderFilter = Texture.Filter;
					if (ig.BeginCombo("Render Filter", StackStringFormat!("{0}", renderFilter)))
					{
						if (ig.Selectable("Nearest", renderFilter == .Nearest)) Texture.Filter = .Nearest;
						if (ig.Selectable("Linear", renderFilter == .Linear)) Texture.Filter = .Linear;

						//surface.Texture.Filter = renderFilter;
						ig.EndCombo();
					}

					if (ig.SliderInt("Render Scale", &Scale, 1, 7))
						UpdateCameraAndTargets();

					ig.Text(scope $"Render Scale: {Scale}");
					ig.Text(scope $"Render Size: {renderSize}");
					ig.Text(scope $"Render Offset: {renderOffset}");
					ig.Text(scope $"Target Size: {targetSize}");
					ig.Text(scope $"Scaled Size: {ScaledSize}");
					ig.Text(scope $"Size: {size}");
					ig.Text(scope $"Pixel Size: {pixelSize}");
					ig.Text(scope $"Draw Offset: {Offset}");

					ig.EndChild();
				}
			}
		}

		public void Rect(rect rect, Color color)
		{
			batch.Rect(rect.Offset(-(int2)Offset), color);
		}

		public void Rect(aabb2 rect, Color color)
		{
			batch.Rect(rect.Offset(-(int2)Offset), color);
		}

		public void Rect(aabb2 rect, float rotation, Color color = .White)
		{
			rect.Rotate(rect.Center, rotation, let points);
			batch.Quad(points[0] - (int2)Offset, points[1] - (int2)Offset, points[2] - (int2)Offset, points[3] - (int2)Offset, color);
		}
	}
}*/

