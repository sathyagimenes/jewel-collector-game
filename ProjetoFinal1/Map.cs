using System;


namespace ProjetoFinal1
{
	public class Map
	{
		public IElement[,] Positions;
		public int Width { get; set; }
		public int Height { get; set; }
		public int Lvl { get; set; }

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
						Positions[x, y] = new Jewel(x, y, "JR");
					}
					else if ((y == 9 && x == 1) || (y == 7 && x == 6))
					{
						Positions[x, y] = new Jewel(x, y, "JG");
					}
					else if ((y == 3 && x == 4) || (y == 2 && x == 1))
					{
						Positions[x, y] = new Jewel(x, y, "JB");
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
			if (Lvl == 1)
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
			}
			else
			{
				Height += Lvl;
                Width += Lvl;
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
            }
		}
	}
}
