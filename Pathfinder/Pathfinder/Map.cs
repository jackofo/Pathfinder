using System;
using System.IO;

namespace Pathfinder
{
	class ConsoleMap
	{
		private const int startId = 3;
		private const int endId = 4;
		private const int floorId = 0;
		private const int wallId = 1;
		private char floorTile = ' ';
		private char wallTile = '█';
		private readonly char startTile = ' ';
		private readonly char finishTile = '░';
		public int[][] map;
		private Point startPoint;
		private Point endPoint;
		public Point StartPoint { get { return startPoint; } set { startPoint = value; } }
		public Point EndPoint { get { return endPoint; } set { endPoint = value; } }
		public int WallId { get { return wallId; } }

		public ConsoleMap(string path)
		{
			this.map = new int[0][];

			using StreamReader sr = new StreamReader(path);
			int linesNumebr = 0;
			string line;
			char[] charsInLine;

			while ((line = sr.ReadLine()) != null)
			{
				charsInLine = line.ToCharArray();
				Array.Resize(ref map, map.Length + 1);
				map[linesNumebr] = new int[charsInLine.Length];

				for (int i = 0; i < charsInLine.Length; i++)
				{
					this.map[linesNumebr][i] = int.Parse(charsInLine[i].ToString());

					if (this.map[linesNumebr][i] == startId)
					{
						startPoint = new Point(linesNumebr, i);
					}
					else if (this.map[linesNumebr][i] == endId)
					{
						endPoint = new Point(linesNumebr, i);
					}
				}

				linesNumebr++;
			}
		}

		public void SetWallChar(char w)
		{
			this.wallTile = w;
		}

		public void SetFloorChar(char f)
		{
			this.floorTile = f;
		}

		public void Draw()
		{
			for(int i = 0; i < this.map.Length; i++) 
			{
				for (int j = 0; j < this.map[i].Length; j++)
				{
					char c = '?';
					
					switch(map[i][j])
					{
						case floorId:
							c = floorTile;
							break;
						case wallId:
							c = wallTile;
							break;
						case startId:
							c = startTile;
							break;
						case endId:
							c = finishTile;
							break;
						default:
							break;
					}

					Console.Write(c);
				}
				Console.Write('\n');
			}
		}
	}
}
