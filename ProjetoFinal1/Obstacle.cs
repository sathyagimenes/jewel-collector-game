using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável pelos obstáculos árvore e agua.
	/// Essa classe implementa a interface IElement
	/// </summary>
	public class Obstacle : IElement
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
		/// Tipo do elemento (árvore ou água)
		/// </summary>
		public string Type { get; set; }

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
