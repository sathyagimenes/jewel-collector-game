namespace ProjetoFinal1
{
	class JewelCollector
	{
		public static bool Running { get; set; }
		static void Main()
		{
			Running = true;
			KeyEvent newEvent = new KeyEvent();                         //gerador do evento
			Map map = new Map(10, 10);                                  //tamanho inicial do mapa
			map.PopulateMap();                                          //adiciona os elementos ao mapa
			Robot robot = new Robot(map);                               //insere o robô ao mapa
			robot.Energy = 5;                                           //valor de energia inicial
			map.PrintMap();                                             //delimita o mapa
			map.Lvl = 0;                                                //nível inicial do jogo que aumenta conforme passa de fase
			newEvent.KeyChanged += makeMovement;                        //evento de movimentação do robô
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
					map.Lvl++;                  //aumenta o lvl
					map.Height++;               //aumenta a extensão do mapa no eixo x e y
					map.Width++;
					map.Positions = new IElement[map.Width, map.Height];
					robot.Bag = new List<IElement>();
					map.RandomMap();
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
