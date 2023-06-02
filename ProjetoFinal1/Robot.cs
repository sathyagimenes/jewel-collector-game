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

		//Faz a contagem do número de pontos obtidos com as jóias já coletadas
		private int countJewelsValue()
		{
			int value = 0;
			foreach (Jewel j in Bag)
			{
				value += j.JewelValue;
			}
			return value;
		}

		//Faz a leitura da tecla pressionada pelo usuário e realiza seu comando de acordo com as especificações
		public void Move(char command, Map map)
		{
			switch (command)
			{
				//Sai do jogo
				case 'q':
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nGAME OVER: Você desistiu do jogo\nPressione qualquer tecla para sair");
					Console.ResetColor();
					Console.ReadKey();
					JewelCollector.Running = false;
					break;

				//Movimenta-se para o Norte (cima)
				case 'w':
					MoveRobot(map, 0, -1);
					break;

				//Movimenta-se para o Sul (baixo)
				case 's':
					MoveRobot(map, 0, 1);
					break;

				//Movimenta-se para o Leste (esquerda)
				case 'a':
					MoveRobot(map, -1, 0);
					break;

				//Movimenta-se para o Oeste (direita)
				case 'd':
					MoveRobot(map, 1, 0);
					break;

				//Realiza a coleta de energia e/ou de jóias
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

		//Faz a varredura das consequências de cada movimentação do Robô
		public void MoveRobot(Map map, int dx, int dy)
		{
			int tempX = X;
			int tempY = Y;
			tempX += dx;
			tempY += dy;

			try
			{
				//Delimita a movimentação do Robô para apenas os limites do mapa e objetos transponiveis
				if (!(map.Positions[tempX, tempY].Type == "--" || map.Positions[tempX, tempY].Type == "!!"))
					throw new Exception();
				//Desconta 30 de energia caso o robô passe por cima do elemento radioativo e faz com que o elemento radioativo suma
				if (map.Positions[tempX, tempY].Type.Equals("!!"))
				{
					Energy -= 30;

				}
				map.Positions[X, Y] = new EmptySpace(X, Y, "--");
				X = tempX;
				Y = tempY;
				map.Positions[X, Y] = this;
				Energy--;//Subtrai 1 de energia para cada passo dado pelo robô

			}
			catch (IndexOutOfRangeException)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\nNão é possível sair dos limites do mapa!");
				Console.ResetColor();
			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\nCaminho bloqueado!");
				Console.ResetColor();
			}

			//Esses 4 ifs seguintes são para descontar 10 de energia do robô caso ele passe pelas adjacencias do elemento radioativo
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
			if (((X) < map.Width && (X >= 0)) && ((Y - 1) < map.Height && (Y - 1) >= 0))
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

		//Realiza as funções do botão "g" como recuperar energia e coletar jóias
		public void AddItem(Map map, int tempX, int tempY)
		{
			//Verifica se o robô encontra-se nas adjacencias do mapa
			if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0))
			{
				switch (map.Positions[tempX, tempY].Type)
				{

					//Coleta a jóia vermelha e coloca um "--" no lugar
					case "JR":
						Bag.Add(map.Positions[tempX, tempY]);
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					//Coleta a jóia verde e coloca um "--" no lugar
					case "JG":
						Bag.Add(map.Positions[tempX, tempY]);
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						break;

					//Coleta a jóia azul, assim como recarrega 5 de energia e coloca um "--" no lugar
					case "JB":
						Bag.Add(map.Positions[tempX, tempY]);
						map.Positions[tempX, tempY] = new EmptySpace(tempX, tempY, "--");
						Energy += 5;
						break;

					//Aumenta 3 de energia nas adjacencias de uma árvore ao pressionar o "g"
					case "$$":
						Energy += 3;
						break;


				}
			}
		}
		//Integrando cor ao robô
		public override string ToString()
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			return (this.Type);
		}
	}
}
