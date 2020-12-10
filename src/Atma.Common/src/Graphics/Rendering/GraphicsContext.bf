using System.Threading;
using System;
namespace Atma
{
	/// <summary>
	/// An Implementation of the Graphics Module that supports the OpenGL Graphics API
	/// </summary>
	public abstract class GraphicsContext//: IGraphicsContext
	{
		private static int _mainContextThread = -1;
		public static int MainContextThread => _mainContextThread;

		private bool _isMainContext = false;

		public this()
		{
			if (MainContextThread == -1)
			{
				_isMainContext = true;
				_mainContextThread = Thread.CurrentThread.Id;
				MakeActiveInternal();
			}
		}

		public virtual void MakeActive()
		{
			Runtime.Assert(
				(IsMainContext && _mainContextThread == Thread.CurrentThread.Id) ||
				(IsBackgroundContext && _mainContextThread != Thread.CurrentThread.Id),
				"MainContext can only be used on the main thread and background context on off threads");

			if (!_isMainContext)
				MakeActiveInternal();
		}

		protected bool IsMainContext => _isMainContext;
		protected bool IsBackgroundContext => !_isMainContext;

		protected abstract void MakeActiveInternal();

		public readonly Monitor Lock = new .() ~ delete _;
	}
}

