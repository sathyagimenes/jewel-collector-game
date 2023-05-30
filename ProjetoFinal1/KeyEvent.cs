namespace ProjetoFinal1
{
	public class KeyEvent
	{
		private char command;
		public char Command
		{
			get { return command; }
			set
			{
				command = value;
				OnKeyChanged(command);
			}
		}
		public event EventHandler<char>? KeyChanged;
		protected virtual void OnKeyChanged(char e)
		{
			KeyChanged?.Invoke(this, e);
		}
	}
}