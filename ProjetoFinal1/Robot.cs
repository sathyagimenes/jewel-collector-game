using System;


namespace ProjetoFinal1 {
    public class Robot {
        public int X { get; set; }
        public int Y { get; set; }

        public Robot(int x, int y) {
            X = x;
            Y = y;
        }

        public void Move(int dx, int dy) {
            X += dx;
            Y += dy;
        }

        public void CollectJewel(Jewel jewel) {
            Console.WriteLine("+1 " + jewel.Type + "!\nParabéns! Continue assim!");
        }

        public void PrintRobotPosition() {
            Console.WriteLine("Position: (" + X + ", " + Y + ")");
        }
    }
}
