using System;


namespace ProjetoFinal1
{
	public class Robot : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }

		public string Type { get; set; }

		public Robot(int x, int y, string type)
		{
            //talvez remover esse construtor
			X = x;
			Y = y;
			Type = type;
		}

		public Robot(Map map)
		{
			X = 0;
			Y = 0;
			Type = "ME";
		}

		public void Move(char command, Map map)
		{
			switch (command)
			{
				case 'w':
					MoveRobot(map, 0, -1);
					break;
				case 's':
					MoveRobot(map, 0, 1);
					break;
				case 'a':
					MoveRobot(map, -1, 0);
					break;
				case 'd':
					MoveRobot(map, 1, 0);
					break;
				// case 'g':
				//     //verificar as 4 posições e coletar todas as joias de acordo com o tipo
				// 	CollectJewel(map);
				// 	break;
				default:
					Console.WriteLine("Comando inválido. Tente novamente.");
					break;
			}
		}

		public void MoveRobot(Map map, int dx, int dy)
		{
			int tempX = X;
			int tempY = Y;
			tempX += dx;
			tempY += dy;
			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0) && (map.Positions[tempX, tempY].Type == "--"))
			{
				map.Positions[X, Y] = new EmptySpace(X, Y, "--");
				X = tempX;
				Y = tempY;
				map.Positions[X, Y] = new Robot(map);
			}
		}

		// public void CollectJewel(Map map) {
            //chama o metodo da classe map para remover joia do mapa
            //add joia na bag
		//     Console.WriteLine("+1 " + jewel.Type + "!\nParabéns! Continue assim!");
		// }

		// public void PrintRobotPosition() {
		//     Console.WriteLine("Position: (" + X + ", " + Y + ")");
		// }
		public override string ToString()
		{
			return (this.Type + " ");
		}
	}
}
