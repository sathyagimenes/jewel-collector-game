using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ProjetoFinal1
{
	class JewelCollector
	{
		public static bool Running { get; set; }
		static void Main()
		{
			Running = true;
			KeyEvent newEvent = new KeyEvent();
			Map map = new Map(10, 10);
			map.PopulateMap();
			Robot robot = new Robot(map);
			robot.Energy = 5;
			map.PrintMap();
			newEvent.KeyChanged += makeMovement;
			void makeMovement(object? sender, char newKey)
			{
				robot.Move(newKey, map);
			}

			while (Running)
			{
				// Console.Clear();
				Console.WriteLine("\n* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Comandos válidos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
				map.PrintMap();
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
				Console.WriteLine("Energia: " + robot.Energy);
				Console.Write("Digite um comando: ");
				newEvent.Command = Console.ReadKey().KeyChar;
				if (robot.Energy < 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nGAME OVER: A energia do robo acabou");
					Console.ResetColor();
					Running = false;
				}
			}
		}
	}
}
