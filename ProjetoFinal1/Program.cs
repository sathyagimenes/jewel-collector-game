using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ProjetoFinal1
{
	class JewelCollector
	{
		static void Main()
		{
			bool running = true;
			Map map = new Map(10, 10);
			map.PopulateMap();
			Robot robot = new Robot(map);
			map.PrintMap();

			while (running)
			{
				Console.Clear();
			    Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
				map.PrintMap();
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
				Console.Write("Digite um comando: ");
				char command = Console.ReadKey().KeyChar;
				Console.WriteLine();

				if (command == 'q')
				{
					running = false;
				}
				else
				{
					robot.Move(command, map);
				}
			}
		}
	}
}
