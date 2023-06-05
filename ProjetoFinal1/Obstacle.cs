using System;

namespace ProjetoFinal1
{
	public class Obstacle : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }
		public int Energy { get; set; }

		public Obstacle(int x, int y, string type)
		{
			X = x;
			Y = y;
			Type = type;
		}

		/// <summary>
		/// Sobreposição do método ToString.
		/// Definimos que a impressão de um objeto desta classe
		/// irá imprimir o atributo Type na cor especificada
		/// </summary>
		public override string ToString()
		{
			if (Type == "$$")
			{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
			}
			else if (Type == "##")
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
			}
			return (this.Type);
		}
	}
}
