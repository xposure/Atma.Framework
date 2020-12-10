using System;
using System.IO;
namespace Atma
{
	public class FileWatcher
	{
		private readonly String _path = new .() ~ delete _;
		private readonly FileSystemWatcher _watcher ~ delete _;

		private double _changed = 0f;

		public this(StringView path)
		{
			let filename = scope String();
			let dir = scope String();

			System.IO.Path.GetFileName(path, filename);
			System.IO.Path.GetDirectoryPath(path, dir);

			_watcher = new .(dir, filename);
			_watcher.StartRaisingEvents();
			_watcher.OnChanged.Add(new (fileName) =>
				{
					_changed = Time.Elapsed + 100;
				});

			_path.Set(path);
		}

		public bool IsChanged
		{
			get
			{
				if (_changed > 0 && _changed < Time.Elapsed)
				{
					_changed = 0;
					return true;
				}
				return false;
			}
		}
	}
}
