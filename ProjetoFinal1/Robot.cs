using System;


namespace ProjetoFinal1
{
	public class Robot : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }

		public string Type { get; set; }
		private int qntJewels;
		public int QntJewels { get { return qntJewels; } set { foreach(IElement i in Bag) if (i.Type == "JR" || i.Type == "JG" || i.Type == "JB" ) qntJewels++;} }
		public int ValorJewels { get; set; }
		public int Energy { get; set; }
		List<IElement>Bag = new List<IElement>();
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
					AddItem(map, (X - 1), Y);
					AddItem(map, (X + 1), Y);
					AddItem(map, X, (Y - 1));
					AddItem(map, X, (Y + 1));
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
			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0) && (map.Positions[tempX, tempY].Type == "--"))
			{
				map.Positions[X, Y] = new EmptySpace(X, Y, "--");
				X = tempX;
				Y = tempY;
				map.Positions[X, Y] = new Robot(map);
				Energy--; 
			}

		}
		public void AddItem(Map map, int tempX, int tempY)
		{
			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0))
			{
				switch (map.Positions[tempX, tempY].Type)
				{
					case "JR":
						Bag.Add(map.Positions[tempX, tempY]); 
						QntJewels++;
						ValorJewels += 100;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JG":
						Bag.Add(map.Positions[tempX, tempY]); 
						QntJewels++;
						ValorJewels += 50;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JB":
						Bag.Add(map.Positions[tempX, tempY]); 
						QntJewels++;
						ValorJewels += 10;
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						Energy += 5;
						break;

					case "$$":
						Bag.Add(map.Positions[tempX, tempY]); 
						Energy += 3;
						break;
				}
			}
		}

	
			


		public override string ToString()
		{
			Console.BackgroundColor = ConsoleColor.Magenta;
			return (this.Type);


		}
	}
}
