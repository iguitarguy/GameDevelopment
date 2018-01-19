using System;

namespace ArrayDemo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");
			for (int i = 0; i < 1; i++) {
				Console.WriteLine ("Bob");
			}

			string[] a = new string[10];
			for (int i = 0; i < 10; i++) {
				a [i] = "x";
			}

			a [4] = "Howdy do!";

			for (int i = 0; i < 10; i++) {
				Console.WriteLine("a at " + i + " is " + a[i]);
			}

			//random Swap
			Random r = new Random ();
			int newIndex = r.Next (0, 4);
			string temp = a [4];
			a [4] = a [newIndex];
			a [newIndex] = temp;


			//start array for DragonCave
			string[,] c = new string[3, 5];
			for (int row = 0; row < 3; row++) {
				for (int column = 0; column < 5; column++) {
					c [row, column] = ".";
				}

			}


			c [1, 3] = "B";
			for (int row = 0; row < 3; row++) {
				for (int column = 0; column < 5; column++) {
					Console.Write (c [row, column]); // no new Line
				}
				Console.WriteLine (); //new Line at end of row
			}
			//use swap to randomize it
				
		}
	}
}
