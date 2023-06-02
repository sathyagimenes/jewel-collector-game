using System;


namespace ProjetoFinal1
{
	public class EmptySpace : IElement {
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }

		public EmptySpace(int x, int y, string type) {
			X = x;
			Y = y;
			Type = type;
		}
        //Integrando cor ao elemento radioativo
        public override string ToString() {
            if (Type == "!!")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return (this.Type);
		}
	}
}

