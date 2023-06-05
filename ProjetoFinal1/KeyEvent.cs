using System;

namespace ProjetoFinal1
{
	/// <summary>
	/// Classe reponsável por gerenciar eventos.
	/// </summary>
	public class KeyEvent
	{
		private char command;
		public char Command
		{
			get { return command; }
			set
			{
				command = value;
				OnKeyChanged(command);//chama o método OnKeyChanged quando houver troca no valor da variável command
			}
		}

		//Cadeia de delegates a ser executado quando há um evento
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