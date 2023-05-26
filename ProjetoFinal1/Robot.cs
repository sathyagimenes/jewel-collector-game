using System;


namespace ProjetoFinal1
{
	public class Robot : IElement {
		public int X { get; set; }
		public int Y { get; set; }

		public string Type { get; set; }

		public Robot(int x, int y, string type) {
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
		// public void Move(int dx, int dy) {
		//     X += dx;
		//     Y += dy;
		// }

		// public void CollectJewel(Jewel jewel) {
		//     Console.WriteLine("+1 " + jewel.Type + "!\nParabéns! Continue assim!");
		// }

		// public void PrintRobotPosition() {
		//     Console.WriteLine("Position: (" + X + ", " + Y + ")");
		// }
	}
}
