using System;


namespace ProjetoFinal1 {
    public class Jewel : IElement {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }

       
    
 

            
        }

        public override string ToString()
        {
            return (this.Type + " ");
        }
    }
}

