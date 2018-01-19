using System;

namespace DragonCave
{
	public class Board
	{
		String[,] rooms;
		Random randomGen;
		Player player;
		int dragonRow;
		int dragonCol;

		public Board (Player p)
		{
			player = p;
			randomGen = new Random ();

			rooms = new String[4, 4];
			for (int row = 0; row < 4; row++) {
				for (int col = 0; col < 4; col++) {
					rooms [row, col] = ".";
				}
			}

			rooms [0, 0] = "E";
			rooms [0, 1] = "P";
			rooms [0, 2] = "P";
			rooms [0, 3] = "P";
			rooms [1, 0] = "D";
			rooms [1, 1] = "G";
			dragonRow = 1;
			dragonCol = 0;
			swapRandomRoom (0, 0);
			swapRandomRoom (0, 1);
			swapRandomRoom (0, 2);
			swapRandomRoom (0, 3);
			swapRandomRoom (1, 0);
			swapRandomRoom (1, 1);
		}

		public void update (String cmd)
		{
			if(getPlayerRoom() == "G" && cmd == "G"){
				rooms[player.row, player.col] = ".";
				player.hasGold = true;
			}

			else if(getPlayerRoom() == "E" && cmd == "C"){
				player.hasEscaped = true;
			}

			else if(cmd == "S" && player.hasArrow){
				player.hasArrow = false;
				if((player.row == dragonRow && player.col < dragonCol && player.dir == 0) ||
					(player.row == dragonRow && player.col > dragonCol && player.dir == 2) ||
					(player.col == dragonCol && player.row < dragonRow && player.dir == 1) ||
					(player.col == dragonCol && player.row > dragonRow && player.dir == 3)){

						player.hasKilledDragon = true;
						rooms[dragonRow, dragonCol] = ".";
					}
			}
		}

		public void render (String cmd)
		{
			if (cmd == "X") {
				Console.WriteLine ("===========MAP===========");
				for (int row = 0; row < 4; row++) {
					for (int col = 0; col < 4; col++) {
						Console.Write (rooms [row, col] + "\t");
					}
					Console.WriteLine ();
				}
				Console.WriteLine ("=========================");
			}

			String neighbors = getPlayerNeighbors();
			if (neighbors.Contains("P"))
				Console.WriteLine("A damp breeze is in the air!");
			if (neighbors.Contains("D"))
				Console.WriteLine("A foul stench is in the air!");

			if(getPlayerRoom() == "G")
				Console.WriteLine("The room is glittering!");
			if(getPlayerRoom() == "D"){
				Console.WriteLine("The Dragon Eats You !!!");
				player.isAlive = false;
			}
			if(getPlayerRoom() == "P"){
				Console.WriteLine("You fall into a pit !!!");
				player.isAlive = false;
			}
		}

		private String getRoom (int row, int col)
		{
			if (row < 0 || row > 3 || col < 0 || col > 3)
				return "";
			else
				return rooms [row, col];
		}

		private String getPlayerRoom(){
			return getRoom(player.row, player.col);
		}

		private String getPlayerNeighbors ()
		{
			int r = player.row;
			int c = player.col;
			return getRoom (r, c + 1) + getRoom (r, c - 1) + getRoom (r + 1, c) + getRoom (r - 1, c);
		}

		private void swapRandomRoom (int row, int col)
		{
			int newRow = randomGen.Next (0, 4);
			int newCol = randomGen.Next (0, 4);
			String temp = rooms [row, col];
			rooms [row, col] = rooms [newRow, newCol];
			rooms [newRow, newCol] = temp;


			if (rooms [row, col] == "E")
				player.setPos (row, col);
			else if (rooms [newRow, newCol] == "E")
				player.setPos (newRow, newCol);

			if (rooms [row, col] == "D"){
				dragonRow = row;
				dragonCol = col;
			}
			else if (rooms [newRow, newCol] == "D"){
				dragonRow = newRow;
				dragonCol = newCol;
			}
		}

		public bool isGameOver(){
			return !player.isAlive || player.hasEscaped;
		}
	}
}

