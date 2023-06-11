using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável pelo Robô.
	/// Essa classe implementa a interface IElement
	/// </summary>
	public class Robot : IElement
	{
		///	<summary>
		/// Posição do elemento no eixo X
		/// </summary>
		public int X { get; set; }
		///	<summary>
		/// Posição do elemento no eixo Y
		/// </summary>
		public int Y { get; set; }
		///	<summary>
		/// Tipo do elemento (robô)
		/// </summary>
		public string Type { get; set; }
		///	<summary>
		/// Propriedade responsável por aramzenar a energia do robô
		/// </summary>
		public int Energy { get; set; }
		///	<summary>
		/// Coleção do tipo List que irá armazenar as jóias coletadas
		/// </summary>
		public List<IElement> Bag;
		///	<summary>
		/// Propriedade responsável por armazenar a quantidade de joias coletadas
		/// </summary>
		public int QntJewels
		{
			get { return Bag.Count(); }
			private set { }
		}
		///	<summary>
		/// Propriedade responsável por armazenar a soma do valores das joias coletadas
		/// </summary>
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

		/// <summary>
		/// Método responsável por somar o valor das joias 
		/// que já foram coletadas e estão armazenadas na Coleção Bag
		/// </summary>
		private int countJewelsValue()
		{
			int value = 0;
			foreach (Jewel j in Bag)
			{
				value += j.JewelValue;
			}
			return value;
		}

		/// <summary>
		/// Responsável por direcionar a ação do robô de acordo com a tecla pressionada pelo usuário.
		/// </summary>
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

		/// <summary>
		/// Responsável por excutar a movimentação do robô, observando objetos transponíveis e não transponíveis
		/// </summary>
		public void MoveRobot(Map map, int dx, int dy)
		{
			int tempX = X;
			int tempY = Y;
			tempX += dx;
			tempY += dy;

			try
			{
				//Delimita a movimentação do Robô para apenas os limites do mapa e objetos transponiveis. Se a movimentação for indevida será gerada uma exceção que será capturada no catch.
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
				Console.Write("\nNão é possível sair dos limites do mapa!");
				Console.ResetColor();
				Console.ReadKey();
			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("\nCaminho bloqueado!");
				Console.ResetColor();
				Console.ReadKey();
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

		/// <summary>
		/// Responsável por coletar jóias e adicioná-las à bag do robô
		/// e por recarregar a energia do robô.
		/// </summary>
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

		/// <summary>
		/// Sobreposição do método ToString.
		/// Definimos que a impressão de um objeto desta classe
		/// irá imprimir o atributo Type na cor especificada
		/// </summary>
		public override string ToString()
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			return (this.Type);
		}
	}
}
