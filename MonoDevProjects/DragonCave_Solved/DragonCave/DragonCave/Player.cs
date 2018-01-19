using System;

namespace DragonCave
{
	public class Player
	{
		public int row;
		public int col;
		public int dir;
		// 0 is EAST, 1 SOUTH, 2 WEST, 3 NORTH
		public bool hasGold;
		public bool hasKilledDragon;
		public bool hasEscaped;
		public bool isAlive;
		public bool hasArrow;


		String message;

		public Player ()
		{
			hasGold = false;
			hasKilledDragon = false;
			hasEscaped = false;
			isAlive = true;
			hasArrow = true;
			message = "";
		}

		public void setPos (int r, int c)
		{
			row = r;
			col = c;
		}

		public void update (String cmd)
		{
			message = "";
			if (cmd == "F")
				moveForward ();
			if (cmd == "R")
				turn (1);
			if (cmd == "L")
				turn (-1);
			if (cmd == "G") {
				if (hasGold)
					message = "You have the gold!";
				else
					message = "No gold to grab.";
			}

			if (cmd == "C") {
				if (hasEscaped) {
					if (hasGold && hasKilledDragon)
						message = "You escape a rich dragon slayer!";
					else if (hasGold)
						message = "You escape a rich coward!";
					else if (hasKilledDragon)
						message = "You escape a poor dragon slayer!";
					else
						message = "You escape a poor coward!";
				} else {
					message = "You can not climb out here.";
				}
			}

			if (cmd == "S") {
				if (hasArrow) {
					hasArrow = false;
					if (hasKilledDragon)
						message = "You here a giant roar in the distance!!!";
					else
						message = "You here a thud in the distance.";
				} else {
					message = "You don't have an arrow.";
				}
			}
		}

		public void render (String cmd)
		{
			if (cmd == "X")
				Console.WriteLine ("Your Position Is: Row " + row + ", Col " + col);


			if (isAlive && !hasEscaped) {
				String dirStr = "EAST";
				if (dir == 1)
					dirStr = "SOUTH";
				else if (dir == 2)
					dirStr = "WEST";
				else if (dir == 3)
					dirStr = "NORTH";

				Console.WriteLine ("You are facing " + dirStr + ".");
			}

			if (message != "")
				Console.WriteLine (message);
		}

		private void moveForward ()
		{
			message = "You walk into the next room.";
			String error = "You bumped into a wall!";
			if (dir == 0) {
				if (col == 3)
					message = error;
				else
					col++;
			} else if (dir == 1) {
				if (row == 3)
					message = error;
				else
					row++;
			} else if (dir == 2) {
				if (col == 0)
					message = error;
				else
					col--;
			} else if (dir == 3) {
				if (row == 0)
					message = error;
				else
					row--;
			}
		}

		private void turn (int right)
		{
			dir = (4 + dir + right) % 4;
		}
	}
}

