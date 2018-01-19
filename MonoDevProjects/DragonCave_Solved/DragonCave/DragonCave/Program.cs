using System;

namespace DragonCave
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Player player = new Player();
			Board board = new Board(player);

			Console.WriteLine("Welcome to Dragon Cave!");
			Console.WriteLine("Try to find the gold and return here to climb back out.");
			Console.WriteLine("You have 1 arrow that you can shoot.");
			Console.WriteLine("Try the following commands:");
			Console.WriteLine("Move (F)orward, Turn (L)eft, Turn (R)ight,");
			Console.WriteLine("(G)rab the Gold, (S)hoot the Arrow, (C)limb out.");
			Console.WriteLine("(Q)uit the game, Use (X) to cheat.\n\n");

			board.render("");
			player.render("");

			while(!board.isGameOver()){
				//get user input
				Console.Write("Enter Command: ");
				String input = Console.ReadLine().ToUpper();
				if(input == "Q"){
					break;
				}
				Console.WriteLine();

				//update
				board.update(input);
				player.update(input);

				//render
				board.render(input);
				player.render(input);
			}

			Console.WriteLine("Game Over");
		}
	}
}
