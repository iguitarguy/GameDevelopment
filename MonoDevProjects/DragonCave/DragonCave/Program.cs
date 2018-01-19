using System;

namespace DragonCave
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to Dragon Cave!\n" +
			"Try to find the gold and return here to climb back out.\n" +
			"You have 1 arrow that you can shoot." + "\n" +
			"Try the following commands:\n" +
			"Move (F)orward, Turn (L)eft, Turn (R)ight,\n" +
			"(G)rab the Gold, (S)hoot the Arrow, (C)limb out.\n" +
			"(Q)uit the game, Use (X) to cheat.\n");
			//start array for DragonCave
			string[,] map = new string[4, 4];
			for (int row = 0; row < 4; row++) {
				for (int column = 0; column < 4; column++) {
					map [row, column] = ".";
				}

			}
			map [0, 2] = "P";
			map [0, 3] = "D";
			map [1, 0] = "G";
			map [2, 0] = "P";
			map [2, 1] = "P";
			map [1, 1] = "E";

			int r = 1;
			int c = 1;

			//random Swap
			Random ran = new Random ();

			for (int row = 0; row < 4; row++) {
				for (int column = 0; column < 4; column++) {
					int rowIndex = ran.Next (3);
					int columnIndex = ran.Next (3);
					string temp = map [row, column];
					map [row, column] = map [rowIndex, columnIndex];
					map [rowIndex, columnIndex] = temp;
				}
			}

			for (int row = 0; row < 4; row++) {
				for (int column = 0; column < 4; column++) {
					//Check where entrance is, make that r and c. Change the value of that room to "."
					if (map [row, column] == "E") {
						r = row;
						c = column;
						map [row, column] = ".";
					}
				}
			}
	
			//Saves entrance coordinates
			int r2 = r;
			int c2 = c;

			//Initialize valiables and assign values
			Boolean hasGold = false;
			Boolean hasArrow = true;
			Boolean hasKilledDragon = false;
			string direction = "EAST";

			while (true) {
				//Die 
				if (map [r, c] == "P" || map [r, c] == "D" && hasKilledDragon == false) {
					if (map [r, c] == "P") {
						Console.WriteLine ("You fall into a pit !!!");
					} else if (map [r, c] == "D") {
						Console.WriteLine ("The Dragon Eats You !!!");
					}
					Console.WriteLine ("You Die !!!");
					Environment.Exit (0);
				} else {
				}

				//In the gold room
				if (map [r, c] == "G" && hasGold == false) {
					Console.Write ("The room is glittering!\n");
				} else {
				}

				//Next to a dragon or pit
				//Check row
				if (r - 1 >= 0) {
					if (map [r - 1, c] == "D") {
						Console.Write ("A foul stench is in the air!\n");
					} else if (map [r - 1, c] == "P") {
						Console.Write ("A damp breeze is in the air!\n");
					} 
				} else {
				}
				if (r + 1 <= 3) {
					if (map [r + 1, c] == "D") {
						Console.Write ("A foul stench is in the air!\n");
					} else if (map [r + 1, c] == "P") {
						Console.Write ("A damp breeze is in the air!\n");
					} 
				} else {
				}
				//Check columns
				if (c - 1 >= 0) {
					if (map [r, c - 1] == "D") {
						Console.Write ("A foul stench is in the air!\n");
					} else if (map [r, c - 1] == "P") {
						Console.Write ("A damp breeze is in the air!\n");
					} 
				} else {
				}
				if (c + 1 <= 3) {
					if (map [r, c + 1] == "D") {
						Console.Write ("A foul stench is in the air!\n");
					} else if (map [r, c + 1] == "P") {
						Console.Write ("A damp breeze is in the air!\n");
					} 
				} else {
				}

				Console.Write ("\nYou are facing " + direction + "\nEnter Command: ");
				string input = Console.ReadLine ();

				//Cheat
				if (input == "x" || input == "X") {
					for (int row = 0; row < 4; row++) {
						for (int column = 0; column < 4; column++) {
							Console.Write (map [row, column] + "       "); // no new Line
						}
						Console.WriteLine (); //new Line at end of row
					}
					Console.WriteLine ("CHEAT: You are in: (" + r + "," + c + ")");
				}

				//Turn Left
				else if (input == "l" || input == "L") {
					if (direction == "EAST")
						direction = "NORTH";
					else if (direction == "NORTH")
						direction = "WEST";
					else if (direction == "WEST")
						direction = "SOUTH";
					else if (direction == "SOUTH")
						direction = "EAST";
				}

				//Turn Right
				else if (input == "r" || input == "R") {
					if (direction == "EAST")
						direction = "SOUTH";
					else if (direction == "NORTH")
						direction = "EAST";
					else if (direction == "WEST")
						direction = "NORTH";
					else if (direction == "SOUTH")
						direction = "WEST";
				}

				//Shoot 
				else if (input == "s" || input == "S") {
					if (hasArrow == true) {
						hasArrow = false;
						if (direction == "EAST") {
							//Console.WriteLine ("SHOT ARROW");
							if ((c + 3) <= 3) {
								if (map [r, c + 3] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c + 2] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c + 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if ((c + 2) <= 3) {
								if (map [r, c + 2] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c + 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if ((c + 1) <= 3) {
								if (map [r, c + 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else {
								Console.WriteLine ("You hear a thud in the distance.");
							}
						} else if (direction == "SOUTH") {
							if (r + 3 <= 3) {
								if (map [r + 3, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r + 2, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r + 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if (r + 2 <= 3) {
								if (map [r + 2, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r + 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if (r + 1 <= 3) {
								if (map [r + 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else {
								Console.WriteLine ("You hear a thud in the distance.");
							}
						} else if (direction == "WEST") {
							if (c - 3 >= 0) {
								if (map [r, c - 3] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c - 2] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c - 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if (c - 2 >= 0) {
								if (map [r, c - 2] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r, c - 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if (c - 1 >= 0) {
								if (map [r, c - 1] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else {
								Console.WriteLine ("You hear a thud in the distance.");
							}
						} else if (direction == "NORTH") {
							if (r - 3 >= 0) {
								if (map [r - 3, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r - 2, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r - 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}

							} else if (r - 2 >= 0) {
								if (map [r - 2, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else if (map [r - 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else if (r - 1 >= 0) {
								if (map [r - 1, c] == "D") {
									hasKilledDragon = true;
									Console.WriteLine ("You hear a giant roar in the distance!!!");
								} else {
									Console.WriteLine ("You hear a thud in the distance.");
								}
							} else {
								Console.WriteLine ("You hear a thud in the distance.");
							}
						}
					} else if (hasArrow == false) {
						Console.WriteLine ("You don't have an arrow.");
					}
				}

				//Quit
				else if (input == "q" || input == "Q") {
					Console.WriteLine ("Quitter!!!");
					Environment.Exit (0);
				}

				//Grab gold
				else if (input == "g" || input == "G") {
					if (map [r, c] == "G") {
						hasGold = true;
						Console.WriteLine ("You got the gold !!!");
					} else {
						Console.WriteLine ("Nothing happens.");
					}
				}

				//Climb out
				else if (input == "c" || input == "C") {
					if (r == r2 && c == c2) {
						Console.WriteLine ("You escape the cave!!!");
						if (hasGold == true && hasKilledDragon == true) {
							Console.WriteLine ("!!!!!! You Win !!!!!!");
						} else if (hasGold == true && hasKilledDragon == false) {
							Console.WriteLine ("But there is still a dragon to slay.");
						} else if (hasGold == false && hasKilledDragon == true) {
							Console.WriteLine ("But there is still gold to be found.");
						} else {
							Console.WriteLine ("But there is still gold to be found.");
							Console.WriteLine ("But there is still a dragon to slay.");
						}
						Environment.Exit (0);
					} else {
						Console.WriteLine ("Nothing happens.");
					}
				}

				//Move forward
				else if (input == "f" || input == "F") {
					if (direction == "EAST") {
						if (c + 1 <= 3) {
							c++;
							Console.WriteLine ("You walk into the next room.");
						} else {
							Console.WriteLine ("You bump into a wall.");
						}
					} else if (direction == "SOUTH") {
						if (r + 1 <= 3) {
							r++;
							Console.WriteLine ("You walk into the next room.");
						} else {
							Console.WriteLine ("You bump into a wall.");
						}
					} else if (direction == "WEST") {
						if (c - 1 >= 0) {
							c--;
							Console.WriteLine ("You walk into the next room.");
						} else {
							Console.WriteLine ("You bump into a wall.");
						}
					} else if (direction == "NORTH") {
						if (r - 1 >= 0) {
							r--;
							Console.WriteLine ("You walk into the next room.");
						} else {
							Console.WriteLine ("You bump into a wall.");
						}
					} else {
						
					}

				}


			}
				





		}
	}
}