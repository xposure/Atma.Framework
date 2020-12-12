using System;
using System.Collections;
namespace Atma
{
	public extension RenderTexture
	{
		protected extern void Platform_Resize(int width, int height);
		protected extern void Platform_Destroy();
		protected extern void Platform_Init(TextureFormat[] attachments);
		protected extern void Platform_Bind();
	}

	public extension GraphicsManager
	{
		protected extern void ClearInternal(RenderTarget target, Clear flags, Color color, float depth, int stencil);
		protected extern void RenderInternal(RenderPass pass);
		protected extern Shader CreateShaderForBatch2D();
	}

	public extension IndexBuffer
	{
		protected extern void Platform_SetData(void* indices, int count);
		protected extern void Platform_Bind(GraphicsContext context, Material material);
		protected extern void Platform_Resize(uint elements);
		protected extern void Platform_Init();
		protected extern void Platform_Destroy();
	}

	public extension VertexBuffer
	{
		protected extern void Platform_SetData(void* vertices, int count);
		protected extern void Platform_Bind(GraphicsContext context, Material material);
		protected extern void Platform_Resize(uint elements);
		protected extern void Platform_Init();
		protected extern void Platform_Destroy();
	}

	public extension Texture
	{
		protected extern void Platform_Destroy();
		protected extern void Platform_Init();
		protected extern void Platform_SetFilter(TextureFilter filter);
		protected extern void Platform_SetWrap(TextureWrap x, TextureWrap y);
		protected extern void Platform_Resize(int width, int height);
		protected extern void Platform_SetData(void* buffer, int x, int y, int w, int h);
		protected extern void Platform_GetData(void* buffer);
	}

	public extension Shader
	{
		protected extern void Platform_Init(ShaderSource source, bool log);
		protected extern void Platform_Destroy();
		protected extern void Platform_Bind(GraphicsContext context, Material material);
	}

	public extension Core
	{
		protected extern static void Platform_BeginFrame();
		protected extern static void Platform_Initialize(Window.WindowArgs windowArgs);
		protected extern static void Platform_Destroy();
		protected extern static void Platform_GetDisplays(List<Display> displays);
		protected extern static void Platform_Exit();
		protected extern static bool Platform_OnBattery();
		protected extern static void Platform_Update();
		protected extern static void Platform_Present();
	}

	public extension Assets
	{
		protected static extern SpriteFont PlatformLoadFont(StringView path, int size);
		protected static extern Image PlatformLoadImage(StringView path);
	}

	public extension Input
	{
		protected extern bool Platform_PollKeyboard(Keys key);
		protected extern bool Platform_PollMouse(MouseButtons button);
		protected extern bool Platform_HasGamepad(int gamepadID);
		protected extern bool Platform_PollGamepadButton(int gamepadID, Buttons button);
		protected extern float Platform_PollGamepadAxis(int gamepadID, Axes axis);
		protected extern void Platform_SetMouseCursor(Cursors cursors);
		protected extern bool Platform_GetClipboardString(String output);
		protected extern void Platform_SetClipboardString(String value);
		protected extern void Platform_Update();
	}

	public extension Window
	{
		protected extern int2 PlatformPosition { get; set; }
		protected extern int2 PlatformSize { get; set; }
		protected extern int2 PlatformRenderSize { get; }
		protected extern float2 PlatformContentScale { get; }
		protected extern bool PlatformOpened { get; }

		protected extern StringView PlatformTitle { get; set; }
		protected extern bool PlatformBordered { get; set; }
		protected extern bool PlatformResizable { get; set; }
		protected extern bool PlatformFullscreen { get; set; }
		protected extern bool PlatformVisible { get; set; }
		protected extern bool PlatformVSync { get; set; }

		protected extern bool PlatformFocused { get; }
		protected extern int2 PlatformMouse { get; }
		protected extern int2 PlatformScreenMouse { get; }
		protected extern bool PlatformMouseOver { get; }

		protected extern void PlatformInitialize(Window.WindowArgs windowArgs);
		protected extern void PlatformDestroy();
		protected extern void PlatformFocus();
		protected extern void PlatformPresent();
		protected extern void PlatformClose();
		protected extern void PlatformResize(int2 size);
		protected extern GraphicsContext PlatformGraphicsContext { get; }
	}
}
