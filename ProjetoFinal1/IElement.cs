using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Interface reponsável pelos elementos do mapa.
	/// </summary>
	public interface IElement
	{
		int X { get; set; }
		int Y { get; set; }
		string Type { get; set; }
	}
}

