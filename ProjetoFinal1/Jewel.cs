using System;


namespace ProjetoFinal1 {
    public class Jewel : IElement {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        public int QntJewels { get; set; }
        public int ValorJewels { get; set; }

        public Jewel(int x, int y, string type, int qntjewels, int valorjewels) {
            X = x;
            Y = y;
            Type = type;

            QntJewels = qntjewels;
            ValorJewels = valorjewels;
           
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

