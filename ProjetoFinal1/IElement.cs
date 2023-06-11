using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Interface reponsável pelos elementos do mapa.
	/// </summary>
	public interface IElement
	{
		///	<summary>
		/// Posição do elemento no eixo X
		/// </summary>
		int X { get; set; }
		///	<summary>
		/// Posição do elemento no eixo Y
		/// </summary>
		int Y { get; set; }
		///	<summary>
		/// Tipo do elemento
		/// </summary>
		string Type { get; set; }
	}
}

