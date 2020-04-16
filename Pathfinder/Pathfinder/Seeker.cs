using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
	class Seeker
	{
		private const char sign = '□';
		private Point position;
		private readonly ConsoleMap map;
		private readonly int wallId;

		public Seeker(ConsoleMap map)
		{
			this.map = map;
			this.position = map.StartPoint;
			this.wallId = map.WallId;
		}

		public void Move()
		{
			Random random = new Random();
			int direction = random.Next(0, 4);
			Point moveVector = new Point(0, 0);

			switch(direction)
			{
				case 0:
					moveVector = new Point(0, 1);
					break;
				case 1:
					moveVector = new Point(1, 0);
					break;
				case 2:
					moveVector = new Point(0, -1);
					break;
				case 3:
					moveVector = new Point(-1, 0);
					break;
			}

			Point check = position + moveVector;

			if (map.map[check.y][check.x] != wallId)
			{
				position = check;
			}
		}

		public void Draw()
		{
			Console.SetCursorPosition(position.x, position.y);
			Console.Write(sign);
		}
	}
}
