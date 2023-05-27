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
            robot.Energy = 5;
            map.PrintMap();
			map.Lvl = 0;

			while (running)
			{
				Console.Clear();
			    Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Level: "+ (map.Lvl +1));
				Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
                Console.WriteLine("Coletar Jóias Azuis (JB) e Árvores ($$) recuperam energia");
                map.PrintMap();
				if (robot.ValorJewels == 320)
				{
					map.Lvl++;
                    map.Height += map.Lvl;
                    map.Width += map.Lvl;
                    map.Positions = new IElement[map.Width, map.Height];
                    robot.ValorJewels = 0;
					robot.QntJewels = 0;
                    robot.Energy = 5;
                    map.RandomMap();		
				}
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
                Console.WriteLine("Energia: " + robot.Energy);
                Console.Write("Digite um comando: ");
				char command = Console.ReadKey().KeyChar;
				Console.WriteLine();

				if (command == 'q' || robot.Energy <= 0 || map.Lvl > 29)
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
