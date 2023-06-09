﻿using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável pelo Mapa.
	/// </summary>
	public class Map
	{
		/// <summary>
		/// Variável para gerar um número aleatório
		/// </summary>
		Random random = new Random();
		/// <summary>
		/// Mapa do jogo. Matriz de elementos do tipo IElement
		/// </summary>
		public IElement[,] Positions;
		/// <summary>
		/// Propriedade que armazena largura do mapa
		/// </summary>
        public int Width { get; set; }
		/// <summary>
		/// Propriedade que armazena altura do mapa
		/// </summary>
		public int Height { get; set; }
		/// <summary>
		/// Propriedade que nível do jogo
		/// </summary>
		public int Lvl { get; set; }

		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			Positions = new IElement[Width, Height];
		}


		/// <summary>
		/// Adiciona os elementos no mapa no nível 1
		/// </summary>
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
						Positions[x, y] = new Jewel(x, y, "JR");
					}
					else if ((y == 9 && x == 1) || (y == 7 && x == 6))
					{
						Positions[x, y] = new Jewel(x, y, "JG");
					}
					else if ((y == 2 && x == 1) || (y == 3 && x == 4))
					{
						Positions[x, y] = new Jewel(x, y, "JB");
					}
					else if ((y == 5 && x <= 6))
					{
						Positions[x, y] = new Obstacle(x, y, "##");
					}
					else if (((y == 5 || y == 3) && x == 9) || (y == 2 && x == 5) || (y == 1 && x == 4) || y == 8 && x == 3)
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

		/// <summary>
		/// Adiciona os elementos no mapa de forma aleatória a partir do nível 2
		/// </summary>
		public void RandomMap()
		{
			int x, y;

			for (x = 0; x < Height; x++)
			{
				for (y = 0; y < Width; y++)
				{
					Positions[x, y] = new EmptySpace(x, y, "--");
				}
			}

			for (int z = 0; z < 2; z++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new Jewel(x, y, "JR");
				else
					z--;
			}
			for (int c = 0; c < 2; c++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new Jewel(x, y, "JG");
				else
					c--;
			}
			for (int v = 0; v < 2; v++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new Jewel(x, y, "JB");
				else
					v--;
			}
			for (int b = 0; b < 7; b++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new Obstacle(x, y, "##");
				else
					b--;
			}
			for (int m = 0; m < 5; m++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new Obstacle(x, y, "$$");
				else
					m--;
			}
			for (int l = 0; l < 1; l++)
			{
				x = random.Next(0, Height);
				y = random.Next(0, Width);
				if (Positions[x, y].Type == ("--"))
					Positions[x, y] = new EmptySpace(x, y, "!!");
				else
					l--;
			}
		}

		/// <summary>
		/// Responsável por imprimir a matriz do mapa no terminal
		/// </summary>
		public void PrintMap()
		{

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Console.Write(Positions[x, y]);
					Console.ResetColor();
					Console.Write(" ");
				}
				Console.Write("\n");
			}
			Console.Write("\n");
		}
	}
}
