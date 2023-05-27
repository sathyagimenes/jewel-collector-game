using System;


namespace ProjetoFinal1
{
	public class Robot : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }
		public int QntJewels { get; set; }
		public int ValorJewels { get; set; }
		public int Energy { get; set; }
		

		public Robot(int x, int y, string type)
		{
			X = x;
			Y = y;
			Type = type;
			QntJewels = 0;
			ValorJewels = 0;
			

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
				case 'g':
					Bag(map, (X - 1), Y);
					Bag(map, (X + 1), Y);
					Bag(map, X, (Y - 1));
					Bag(map, X, (Y + 1));
					break;
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

			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0) && ((map.Positions[tempX, tempY].Type == "--") || (map.Positions[tempX, tempY].Type == "!!")))
			{
                if (map.Positions[X, Y].Type == "!!")
                {
                    Energy -= 30;
                }
                map.Positions[X, Y] = new EmptySpace(X, Y, "--");
				X = tempX;
				Y = tempY;
				map.Positions[X, Y] = new Robot(map);
				Energy--;
				if (((X - 1) < map.Width && (X - 1 >= 0)) && (Y < map.Height && Y >= 0))
				{
					if (map.Positions[X - 1, Y].Type == "!!")
					{
						Energy -= 10;
					}
				}
				if (((X + 1) < map.Width && (X + 1 >= 0)) && (Y < map.Height && Y >= 0))
				{
					if (map.Positions[X + 1, Y].Type == "!!")
					{
						Energy -= 10;
					}
				}
				if (((X ) < map.Width && (X >= 0)) && ((Y - 1) < map.Height && (Y - 1) >= 0))
				{
					if (map.Positions[X, Y - 1].Type == "!!")
					{
						Energy -= 10;
					}
				}
				if (((X) < map.Width && (X >= 0)) && ((Y + 1) < map.Height && (Y + 1) >= 0))
				{
					if (map.Positions[X, Y + 1].Type == "!!")
					{
						Energy -= 10;
					}
				}				
            }
		}
		public void Bag(Map map, int tempX, int tempY)
		{
			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0))
			{
				switch (map.Positions[tempX, tempY].Type)
				{
					case "JR":
						QntJewels++;
						ValorJewels += 100;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JG":
						QntJewels++;
						ValorJewels += 50;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JB":
						QntJewels++;
						ValorJewels += 10;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						Energy += 5;
						break;

					case "$$":
						Energy += 3;
						break;
				}
			}
		}
		public override string ToString()
		{
            if (Type == "ME")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
			return (this.Type);
		}
	}
}
