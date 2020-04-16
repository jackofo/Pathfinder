using System;
using System.Threading;

namespace Pathfinder
{
	class Engine
	{
		const int sleepTime = 120; //milliseconds
		const string defaultMapFilePath = "Test.map";
		public bool isRunning;
		readonly ConsoleMap map;
		readonly Seeker seeker;

		public Engine()
		{
			this.isRunning = true;
			Console.CursorVisible = false;
			map = new ConsoleMap(defaultMapFilePath);
			seeker = new Seeker(map);
		}

		public void Run()
		{
			while (isRunning)
			{
				seeker.Move();
				UpdateScene();
				Thread.Sleep(sleepTime);
			}
		}

		private void UpdateScene()
		{
			map.Draw();
			seeker.Draw();
			Debug.Draw();
			Console.SetCursorPosition(0, 0);
		}
	}
}