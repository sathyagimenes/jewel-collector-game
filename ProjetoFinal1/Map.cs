using System;


namespace ProjetoFinal1 {
    public class Map {
        private Jewel[,] jewels;
        private Obstacle[,] obstacles;
        private Robot robot;

        public Map(int width, int height) {
            Width = width;
            Height = height;

            jewels = new Jewel[Width, Height];
            obstacles = new Obstacle[Width, Height];
        }

        public int Width { get; }
        public int Height { get; }

        public void AddJewel(Jewel jewel) {
            jewels[jewel.X, jewel.Y] = jewel;
        }

        public void AddObstacle(Obstacle obstacle) {
            obstacles[obstacle.X, obstacle.Y] = obstacle;
        }

        public void SetRobot(Robot robot) {
            this.robot = robot;
        }

        public void PrintMap() {
            Console.WriteLine("Mapa:");

            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    if (robot.X == x && robot.Y == y) {
                        Console.Write("ME ");
                    }
                    else if (jewels[x,y] != null) {
                        string jewelType = jewels[x, y].Type == "JR" ? "JG" : "JB";
                        Console.Write(jewels[x, y].Type.Substring(0, 1) + " ");
                    }
                    else if (obstacles[x, y] != null) {
                        string obstacleType = obstacles[x, y].Type == "Water" ? "$$" : "##";
                        Console.Write(obstacleType + " ");
                    }
                    else {
                        Console.Write("-- ");
                    }
                }
                Console.WriteLine();
            }
        public ObstacleAt (int x, int y) {
            if ()
        } 
        }
    }
}
