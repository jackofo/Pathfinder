using System;
using System.Collections.Generic;

namespace Pathfinder
{
	class Debug
	{
		private static readonly List<string> log = new List<string>();
		private static Point size = new Point(Console.WindowWidth, 4);
		public static Point Size { get { return size; } set { size = value; } }

		public static void Log(object data)
		{
			log.Add(data.ToString());
		}

		public static void Draw()
		{
			if (log.Count != 0)
			{
				ConsoleColor bgColor = Console.BackgroundColor;

				Console.SetCursorPosition(0, Console.WindowHeight - size.y);
				
				for (int i = 0; i < size.x; i++)
				{
					Console.Write("_");
				}

				int lineCounter = 0;

				for (int i = log.Count - 1; i > log.Count - size.y && i > 0; i--)
				{
					Console.BackgroundColor = lineCounter % 2 == 1 ? ConsoleColor.DarkBlue : ConsoleColor.DarkGreen;
					Console.Write(i + ": ");
					Console.WriteLine(log[i]);
					lineCounter++;
				}

				Console.BackgroundColor = bgColor;
			}
		}
	}
}
