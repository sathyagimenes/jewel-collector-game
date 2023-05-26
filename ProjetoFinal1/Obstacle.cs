using System;

namespace ProjetoFinal1 {
    public class Obstacle {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }

        public Obstacle(int x, int y, string type) {
            X = x;
            Y = y;
            Type = type;
        }
    }
}
