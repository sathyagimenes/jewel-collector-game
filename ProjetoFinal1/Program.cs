﻿using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ProjetoFinal1 {
    class JewelCollector {
        private static Map map;
        private static Robot robot;
        static void Main(string args) {
            map = new Map (10,10);
            robot = new Robot (0,0);
            Jewel jewel = new Jewel(0, 0, " ", 0, 0);

            Start();

            Console.WriteLine("* * * JEWEL COLLECTOR!!! * * *");

            while (true) {
                Console.WriteLine("Comandos: w - norte, s - sul, a - oeste, d - leste, g - coletar joia");
                Console.WriteLine("Total de Jóias coletadas: " + jewel.QntJewels + " | Score: " + jewel.ValorJewels);
                Console.WriteLine("Digite um comando:");
                char command = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (command) {
                    case 'w':
                        MoveRobot(-1,0);
                        break;
                    case 's':
                        MoveRobot(1,0);
                        break;
                    case 'a':
                        MoveRobot(0,-1);
                        break;
                    case 'd':
                        MoveRobot(0,1);
                        break;
                    case 'g':
                        MoveRobot(0,0);
                        break;
                    default:
                        Console.WriteLine("Comando inválido. Tente novamente.");
                        break;
                }
                map.PrintMap();            
            }
        }
        private static void Start() {
            // Posicionando as joias
            map.AddJewel(new Jewel(1, 9, "Red",0, 0));
            map.AddJewel(new Jewel(8, 8, "Red", 0, 0));
            map.AddJewel(new Jewel(9, 1, "Green", 0, 0));
            map.AddJewel(new Jewel(7, 6, "Green", 0, 0));
            map.AddJewel(new Jewel(3, 4, "Blue", 0, 0));
            map.AddJewel(new Jewel(2, 1, "Blue", 0, 0));

            // Inserindo os obstáculos
            map.AddObstacle(new Obstacle(5, 0, "Water"));
            map.AddObstacle(new Obstacle(5, 1, "Water"));
            map.AddObstacle(new Obstacle(5, 2, "Water"));
            map.AddObstacle(new Obstacle(5, 3, "Water"));
            map.AddObstacle(new Obstacle(5, 4, "Water"));
            map.AddObstacle(new Obstacle(5, 5, "Water"));
            map.AddObstacle(new Obstacle(5, 6, "Water"));
            map.AddObstacle(new Obstacle(5, 9, "Tree"));
            map.AddObstacle(new Obstacle(3, 9, "Tree"));
            map.AddObstacle(new Obstacle(8, 3, "Tree"));
            map.AddObstacle(new Obstacle(2, 5, "Tree"));
            map.AddObstacle(new Obstacle(1, 4, "Tree"));

            //Situando o Robô
            map.SetRobot(robot);
        }
        private static void MoveRobot(int dx, int dy) {
            int newX = robot.X + dx;
            int newY = robot.Y + dy;
            
            // Verificar os limites do mapa
            if (newX >= 0 && newX < map.Width && newY >= 0 && newY < map.Height) {
                
                //Remove as jóias coletadas
                if (command == 'g') {
                    if (Jewel[x] - newX <= -1 && Jewel[x] - newX >= 1 && Jewel[y] - newY <= -1 && Jewel[y] - newY >= 1) {
                        Jewel[x, y] = '-';
                    }
                    else {
                        Console.WriteLine("Não há nada por aqui.");
                    }
                }
                if (Obstacle(newX, newY) != null) {
                    robot.Move(dx, dy);
                }
                else {
                    Console.WriteLine("ATENCÃO! Algo impede o meu avanço!");
                }               
            }
            else {
                Console.WriteLine("CUIDADO! Limite do Mapa!");
                Console.WriteLine("Aqui o mundo é plano sim!");
            }
        }
        private static void CollectJewel() {
            


            /*Jewel jewel = map.JewelAt (robot.X, robot.Y);

            if (jewel != null) {
                robot.CollectJewel(jewel);
                map.RemoveJewel(robot.X, robot.Y);
            }
            else {
                Console.WriteLine("Não tem nada aqui!");
            }*/
        }
    }

}

 