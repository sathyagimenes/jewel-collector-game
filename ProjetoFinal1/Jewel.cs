using System;


namespace ProjetoFinal1
{
	public class Jewel : IElement {
		public int X { get; set; }
		public int Y { get; set; }
		public string Type { get; set; }

		public Jewel(int x, int y, string type) {
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

