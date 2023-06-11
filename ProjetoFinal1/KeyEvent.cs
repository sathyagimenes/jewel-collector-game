using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável por gerenciar eventos.
	/// </summary>
	public class KeyEvent
	{
		///	<summary>
		/// Variável privada que armazena a key recebida
		/// </summary>
		private char command;
		///	<summary>
		/// Propriedade que recebe a key recebida e dispara um evento quando seu valor é alterado
		/// </summary>
		public char Command
		{
			get { return command; }
			set
			{
				command = value;
				OnKeyChanged(command);//chama o método OnKeyChanged quando houver troca no valor da variável command
			}
		}

		/// <summary>
		/// Cadeia de delegates a ser executado quando há um evento
		/// </summary>
		public event EventHandler<char>? KeyChanged;

		/// <summary>
		/// Método responsável por invocar a cadeia de 
		/// delegates KeyChanged para executar ações do evento.
		/// </summary>
		protected virtual void OnKeyChanged(char e)
		{
			KeyChanged?.Invoke(this, e);
		}
	}
}