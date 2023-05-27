using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ProjetoFinal1
{
	class JewelCollector
	{
		private char command;
		public char Command
		{
			get { return command; }
			set
			{
				command = value;
				OnKeyChanged(EventArgs.Empty);
			}
		}
		public event EventHandler CommandChanged;
		protected virtual void OnKeyChanged(EventArgs e)
		{
			CommandChanged?.Invoke(this, e);
		}
		static void Main()
		{
			bool running = true;
			JewelCollector game = new JewelCollector();
			Map map = new Map(10, 10);
			map.PopulateMap();
			Robot robot = new Robot(map);
			map.PrintMap();
			game.CommandChanged += move_commandChanged;  
			void move_commandChanged(object sender, EventArgs e)
			{
				robot.Move(game.command, map);
			}

			while (running)
			{
				Console.Clear();
			    Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
				map.PrintMap();
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
				Console.Write("Digite um comando: ");
				game.Command = Console.ReadKey().KeyChar;
				if (game.command == 'q')
					running = false;
			}
		}
	}
}
