using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável por elementos transponíveis (espaços vazios e elemento radioativo).
	/// Essa classe implementa a interface IElement
	/// </summary>
	public class EmptySpace : IElement
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
		/// Tipo do elemento (espaço vazio ou elemento radioativo)
		/// </summary>
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

