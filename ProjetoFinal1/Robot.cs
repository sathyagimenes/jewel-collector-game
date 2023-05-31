using System;


namespace ProjetoFinal1
{
	public class Robot : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }
		public int Energy { get; set; }
		public List<IElement> Bag;
		public int QntJewels
		{
			get { return Bag.Count(); }
			private set { }
		}
		public int ValorJewels
		{
			get { return countJewelsValue(); }
			private set { }
		}
		public Robot(int x, int y, string type)
		{
			X = x;
			Y = y;
			Type = type;
			Bag = new List<IElement>();
		}

		public Robot(Map map)
		{
			X = 0;
			Y = 0;
			Type = "ME";
			Bag = new List<IElement>();
		}

		private int countJewelsValue()
		{
			int value = 0;
			foreach (Jewel j in Bag)
			{
				value += j.JewelValue;
			}
			return value;
		}
		public void Move(char command, Map map)
		{
			switch (command)
			{
				case 'q':
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nGAME OVER: Você desistiu do jogo\n");
					Console.ResetColor();
					JewelCollector.Running = false;
					break;
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
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\nComando inválido. Tente novamente.");
					Console.ResetColor();
					break;
			}
		}

		public void MoveRobot(Map map, int dx, int dy)
		{
			int tempX = X;
			int tempY = Y;
			tempX += dx;
			tempY += dy;
			try
			{
				if (!(map.Positions[tempX, tempY].Type == "--" || map.Positions[tempX, tempY].Type == "!!"))
					throw new Exception();
				map.Positions[X, Y] = new EmptySpace(X, Y, "--");
				X = tempX;
				Y = tempY;
				map.Positions[X, Y] = new Robot(map);
				Energy--;

			}
			catch(IndexOutOfRangeException)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\nNão é possível sair dos limites do mapa!");
				Console.ResetColor();
			}
			catch(Exception)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\nCaminho bloqueado!");
				Console.ResetColor();
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
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JG":
						Bag.Add(map.Positions[tempX, tempY]);
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					case "JB":
						Bag.Add(map.Positions[tempX, tempY]);
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
			Console.BackgroundColor = ConsoleColor.Magenta;
			return (this.Type);
		}
	}
}
