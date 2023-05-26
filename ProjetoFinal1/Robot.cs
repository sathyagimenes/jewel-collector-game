using System;


namespace ProjetoFinal1
{
    public class Robot : IElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Type { get; set; }
        public int QntJewels { get; set; }
        public int ValorJewels { get; set; }


        public Robot(int x, int y, string type, int qntjewels, int valorjewels)
        {
            //talvez remover esse construtor
            X = x;
            Y = y;
            Type = type;
            QntJewels = qntjewels;
            ValorJewels = valorjewels;

        }

        public Robot(Map map)
        {
            X = 0;
            Y = 0;
            Type = "ME";
        }

        public void Move(char command, Map map)
        {
            switch (command)
            {
                case 'w':
                    MoveRobot(map, 0, -1);
                    break;
                case 's':
                    MoveRobot(map, 0, 1);
                    break;
                case 'a':
                    MoveRobot(map, -1, 0);
                    break;
                case 'd':
                    MoveRobot(map, 1, 0);
                    break;
                case 'g':
                    //verificar as 4 posições e coletar todas as joias de acordo com o tipo
                	Bag(map, 0, 0, "J");
                 	break;
                default:
                    Console.WriteLine("Comando inválido. Tente novamente.");
                    break;
            }
        }

        public void MoveRobot(Map map, int dx, int dy)
        {
            int tempX = X;
            int tempY = Y;
            tempX += dx;
            tempY += dy;
            if ((tempX < map.Width && tempX >= 0) && (tempY < map.Height && tempY >= 0) && (map.Positions[tempX, tempY].Type == "--"))
            {
                //if (Robot.Move(command) == 'g')  {
                //                if (map.Positions.Jewel[X] - tempX >= -1 && Jewel[X] - tempX <= 1 && Jewel[Y] - tempY >= -1 && Jewel[Y] - tempY <= 1)
                //                {
                //                    map.Positions[X, Y] = new EmptySpace (X,Y, "--");

                //                }
                //                else
                //                {
                //                    Console.WriteLine("Não há nada por aqui.");
                //                }
                //}
                //else {
                map.Positions[X, Y] = new EmptySpace(X, Y, "--");
                X = tempX;
                Y = tempY;
                map.Positions[X, Y] = new Robot(map);
                //}
            }

        }
        public void Bag (Map map, int x, int y, string type)
        {
            X = x;
            Y = y;
            Type = type;
           

            if (map.Positions[X-1,Y])
            {

            

                switch (type)
                {
                    case "Red":
                        QntJewels++;
                        ValorJewels += 100;
                        break;

                    case "Green":
                        QntJewels++;
                        ValorJewels += 50;
                        break;

                    case "Blue":
                        QntJewels++;
                        ValorJewels += 10;
                        break;
                }
            }        
        }
    }



        // public void CollectJewel(Map map) {
        //chama o metodo da classe map para remover joia do mapa
        //add joia na bag
        //     Console.WriteLine("+1 " + jewel.Type + "!\nParabéns! Continue assim!");
        // }

            // public void PrintRobotPosition() {
            //     Console.WriteLine("Position: (" + X + ", " + Y + ")");
            // }
        public override string ToString()
        {
            return (this.Type + " ");
        }
    }
}
