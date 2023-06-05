using System;

namespace ProjetoFinal1
{
	class JewelCollector
	{
		public static bool Running { get; set; }//variável que determina quando jogo deve encerrar
		/// <summary>
		/// Método principal, inicia o jogo.
		/// </summary>
		static void Main()
		{
			Running = true;
			Map map = new Map(10, 10);
			map.PopulateMap();
			Robot robot = new Robot(map);
			robot.Energy = 5; //valor de energia inicial
			map.PrintMap();
			map.Lvl = 0; //nível inicial do jogo
			KeyEvent newEvent = new KeyEvent();
			newEvent.KeyChanged += makeMovement; //concatenação de método a ser executado quando um evento é disparado

			/// <summary>
			/// Esse método invoca a função Move para executar a ação
			/// do robô de acordo com a key recebida
			/// </summary>
			void makeMovement(object? sender, char newKey)
			{
				robot.Move(newKey, map);
			}

			while (Running)
			{
				//Instruções do menu printados na tela para o usuário
				Console.Clear();
				Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");
				Console.WriteLine("Level : " + (map.Lvl + 1));
				Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia, q - encerrar\n");
				Console.WriteLine("Coletar Jóias Azuis (JB) e Árvores ($$) recuperam energia");
				Console.WriteLine("PERIGO! Elemento Radioativo (!!) Mantenha distância!");
				map.PrintMap();

				//Condições necessárias para subir de nível
				if (robot.ValorJewels == 320)
				{
					map.Lvl++; //aumenta o nível do jogo
					map.Height++; //aumenta a extensão do mapa
					map.Width++;
					map.Positions = new IElement[map.Width, map.Height];
					robot.Bag = new List<IElement>();
					robot.X = 0;
					robot.Y = 0;
					map.RandomMap();
					robot.MoveRobot(map, 0, 0);
				}

				//Mostragem de status do jogador
				Console.WriteLine("\nTotal de Jóias coletadas: " + robot.QntJewels + " | Score: " + robot.ValorJewels);
				Console.WriteLine("Energia: " + robot.Energy);
				Console.Write("Digite um comando: ");
				newEvent.Command = Console.ReadKey().KeyChar;
				if (robot.Energy <= 0 || map.Lvl >= 29)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nGAME OVER: A energia do robo acabou!\nPressione qualquer tecla para sair");
					Console.ResetColor();
					Console.ReadKey();
					Running = false;
				}
			}
		}
	}
}
