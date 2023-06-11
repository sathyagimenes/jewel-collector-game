using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável pelas jóias.
	/// Essa classe implementa a interface IElement
	/// </summary>
	public class Jewel : IElement
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
		/// Tipo do elemento (Joia vermelha, azul ou verde)
		/// </summary>
		public string Type { get; set; }
		///	<summary>
		/// Propriedade que armazena o valor da joia
		/// </summary>
		public int JewelValue { get; set; }
		public Jewel(int x, int y, string type)
		{
			X = x;
			Y = y;
			Type = type;
			//Atribuição do valor referente a cada jóia
			JewelValue = Type == "JR" ? 100 : Type == "JG" ? 50 : 10;
		}

		/// <summary>
		/// Sobreposição do método ToString.
		/// Definimos que a impressão de um objeto desta classe
		/// irá imprimir o atributo Type na cor especificada
		/// </summary>
		public override string ToString()
		{
			if (Type == "JR")
			{
				Console.BackgroundColor = ConsoleColor.Red;
			}
			else if (Type == "JG")
			{
				Console.BackgroundColor = ConsoleColor.Green;
			}
			else
			{
				Console.BackgroundColor = ConsoleColor.DarkCyan;
			}
			return (this.Type);
		}
	}
}
