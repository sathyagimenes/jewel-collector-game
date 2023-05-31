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
			map.Lvl = 0;
			newEvent.KeyChanged += makeMovement;
			void makeMovement(object? sender, char newKey)
			{
				robot.Move(newKey, map);
			}

			while (Running)
			{
				Console.Clear();
				Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Level : " + (map.Lvl +1));
				Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
                Console.WriteLine("Coletar Jóias Azuis (JB) e Árvores ($$) recuperam energia");
                map.PrintMap();
				if (robot.ValorJewels == 320)
				{
					map.Lvl++;
                    map.Height++;
                    map.Width++;
                    map.Positions = new IElement[map.Width, map.Height];
					robot.Bag = new List<IElement>();
                    map.RandomMap();		
				}
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
				Console.WriteLine("Energia: " + robot.Energy);
				Console.Write("Digite um comando: ");
				newEvent.Command = Console.ReadKey().KeyChar;
				if (robot.Energy <= 0 || map.Lvl >= 29)
				{
					Console.WriteLine("\nGAME OVER: A energia do robo acabou\nPressione qualquer tecla para sair");
					Console.ReadKey();
					Running = false;
				}
			}
		}
	}
}
