using System;


namespace ProjetoFinal1
{
	public class EmptySpace : IElement
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }

		public EmptySpace(int x, int y, string type)
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
			if (Type == "!!")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			return (this.Type);
		}
	}
}

