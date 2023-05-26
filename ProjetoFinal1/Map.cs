using System;


namespace ProjetoFinal1
{
	public class Map
	{
		public IElement[,] Positions;
		public int Width { get; set; }
		public int Height { get; set; }

		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			Positions = new IElement[Width, Height];
		}

		public void PopulateMap()
		{
			for (int x = 0; x < Height; x++)
			{
				for (int y = 0; y < Width; y++)
				{
					if (y == 0 && x == 0)
					{
						Positions[x, y] = new Robot(x, y, "ME");
					}
					else if ((y == 1 && x == 9) || (y == 8 && x == 8))
					{
						Positions[x, y] = new Jewel(x, y, "JR", 0, 0);
					}
					else if ((y == 9 && x == 1) || (y == 7 && x == 6))
					{
						Positions[x, y] = new Jewel(x, y, "JG", 0, 0);
					}
					else if ((y == 3 && x == 4) || (y == 2 && x == 1))
					{
						Positions[x, y] = new Jewel(x, y, "JB", 0, 0);
					}
					else if ((y == 5 && x <= 6))
					{
						Positions[x, y] = new Obstacle(x, y, "##");
					}
					else if (((y == 5 || y == 3) && x == 9) || (y == 2 && x == 5) || (y == 1 && x == 4))
					{
						Positions[x, y] = new Obstacle(x, y, "$$");
					}
					else
					{
						Positions[x, y] = new EmptySpace(x, y, "--");
					}

				}
			}
		}

		public void PrintMap()
		{
			Console.WriteLine("Mapa:");

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Console.Write(Positions[x, y]);
				}
				Console.Write("\n");
			}
		}

		//  public string ToString() {
		//      Console.Write(this.Type + ' ');
		//  }

		// public void AddJewel(Jewel jewel) {
		//     jewels[jewel.X, jewel.Y] = jewel;
		// }

		// public void AddObstacle(Obstacle obstacle) {
		//     obstacles[obstacle.X, obstacle.Y] = obstacle;
		// }

		// public void SetRobot(Robot robot) {
		//     this.robot = robot;
		// }

		// public void PrintMap() {
		//     Console.WriteLine("Mapa:");

		//     for (int y = 0; y < Height; y++) {
		//         for (int x = 0; x < Width; x++) {
		//             if (robot.X == x && robot.Y == y) {
		//                 Console.Write("ME ");
		//             }
		//             else if (jewels[x,y] != null) {
		//                 string jewelType = jewels[x, y].Type == "JR" ? "JG" : "JB";
		//                 Console.Write(jewels[x, y].Type.Substring(0, 1) + " ");
		//             }
		//             else if (obstacles[x, y] != null) {
		//                 string obstacleType = obstacles[x, y].Type == "Water" ? "$$" : "##";
		//                 Console.Write(obstacleType + " ");
		//             }
		//             else {
		//                 Console.Write("-- ");
		//             }
		//         }
		//         Console.WriteLine();
		//     }
		// }
	}
}
