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

		public override string ToString() {
			// if (this.Type){
			//     return(this.Type + " ");
            // } else {
            //     return("x ");
            // }
            return(this.Type + " ");
		}
	}
}

