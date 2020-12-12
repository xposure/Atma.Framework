using System;
using System.IO;
using System.Text;
using System.Collections;

namespace Atma
{
	/// <summary>
	/// Foster Log system
	/// </summary>
	public static class Log
	{
		public enum Types
		{
			Debug,
			Message,
			Warning,
			Error
		}

		public struct LogLine
		{
			public Types Type;
			public String Text;

			public this(Types type, StringView val)
			{
				Text = new .();
				Text.Set(val);
				Type = type;
			}
		}

		private static readonly String log = new .() ~ delete _;
		public static readonly List<LogLine> Lines = new List<LogLine>();

		public static bool PrintToConsole = true;

		static ~this()
		{
			for (var it in Lines)
				delete it.Text;

			Lines.Clear();
			delete Lines;
		}


		public static void Message(StringView message, params Object[] args)
		{
			let msg = scope String();
			msg.AppendF(message, params args);

			Line("INFO", ConsoleColor.White, msg);
			Lines.Add(.(Types.Message, msg));
		}

		public static void Message(StringView message)
		{
			Line("INFO", ConsoleColor.White, message);
			Lines.Add(.(Types.Message, message));
		}

		public static void Warning(StringView warning)
		{
			Line("WARN", ConsoleColor.Yellow, warning);
			Lines.Add(.(Types.Warning, warning));
		}

		public static void Warning(StringView warning, params Object[] args)
		{
			let msg = scope String();
			msg.AppendF(warning, params args);
			Warning(msg);
		}

		public static void Error(StringView error)
		{
			Line("FAIL", ConsoleColor.Red, error);
			Lines.Add(.(Types.Error, error));
		}

		public static void Error(StringView error, params Object[] args)
		{
			let msg = scope String();
			msg.AppendF(error, params args);
			Error(msg);
		}

		public static void Debug(StringView debug)
		{
			//System.Diagnostics.Debug.WriteLine(debug);
			Line("DEBG", ConsoleColor.Cyan, debug);
			Lines.Add(.(Types.Debug, debug));
		}

		public static void Debug(StringView debug, params Object[] args)
		{
			let msg = scope String();
			msg.AppendF(debug, params args);

			Debug(msg);
		}

		public static void Todo(StringView todo)
		{
			System.Diagnostics.Debug.WriteLine(todo);
			Line("DEBG", ConsoleColor.Cyan, todo);
			Lines.Add(.(Types.Debug, todo));
			System.Diagnostics.Debug.SafeBreak();
		}

		public static void Todo(StringView todo, params Object[] args)
		{
			let msg = scope String();
			msg.AppendF(todo, params args);

			Todo(msg);
		}


		public static void AppendToFile(StringView title, StringView file)
		{
			let index = file.LastIndexOf('\\');
			let directory = scope String(file, 0, index);
			if (directory != null && !Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			var builder = new String();

			builder.AppendF("{0} ERROR LOG{1}", title, Environment.NewLine);
			builder.AppendF("{0}{1}", DateTime.Now, Environment.NewLine);
			builder.Append(log);
			builder.Append(Environment.NewLine);
			builder.Append(Environment.NewLine);

			if (File.Exists(file))
				File.ReadAllText(file, builder);

			File.WriteAllText(file, builder);

			delete builder;
		}

		private static void Line(StringView subtitle, ConsoleColor subtitleFg, StringView message)
		{
			Append("ATMA", ConsoleColor.DarkCyan, true);

			Append(":", subtitleFg, true);
			Append(subtitle, subtitleFg);

			Append(": ", ConsoleColor.DarkGray);
			Append(message);
			AppendLine();
		}

		private static void Append(StringView text, ConsoleColor fg = ConsoleColor.White, bool consoleOnly = false)
		{
			if (PrintToConsole)
			{
				Console.ForegroundColor = fg;
				Console.Write(text);
			}

			if (!consoleOnly)
				log.Append(text);
		}

		private static void AppendLine()
		{
			if (PrintToConsole)
				Console.WriteLine();

			log.Append(System.Environment.NewLine);
		}

	}
}

