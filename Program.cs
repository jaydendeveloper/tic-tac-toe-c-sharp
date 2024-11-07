using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiktaktoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gyalog Patrik 2024.11.05");

            int[,] gameMap = new int[3, 3] {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            };
            string nev1;
            string nev2;
            string currentPlayer = "X";
            bool gameWon = false;
            int turns = 0;
            Random random = new Random();

            void printGameMap()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   A  B  C");
                for (int i = 0; i < gameMap.GetLength(0); i++) 
                {
                    Console.Write(i + 1 + " ");
                    for (int j = 0; j < gameMap.GetLength(1); j++)
                    {
                        if (gameMap[i, j] == 1)
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("|");
                        }
                        else if (gameMap[i, j] == -1)
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("|");
                        } else
                        {
                            Console.Write("| |");
                        }
                    }
                    Console.WriteLine("\n");
                }
            }

            void playerTurn()
            {
                printGameMap();

                if (turns < 9) {
                    if (currentPlayer == "X")
                    {
                        Console.WriteLine(nev1 + " lép!");
                       try
                        {
                            Console.WriteLine("Sor:");
                            int mapLine = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Oszlop:");
                            string mapCol = Console.ReadLine().ToUpper();
                            int selectedCol = -1;

                            if (mapCol == "A") selectedCol = 0;
                            if (mapCol == "B") selectedCol = 1;
                            if (mapCol == "C") selectedCol = 2;

                            if (selectedCol > -1 && gameMap[mapLine, selectedCol] == 0)
                            {
                                gameMap[mapLine, selectedCol] = 1;
                                currentPlayer = "O";
                                turns++;
                            }
                        } catch
                        {
                            gameWon = true;
                            string str = $"{nev1} feladta {nev2} nyert";
                            Console.WriteLine(str);
                        }
                        checkWinConditions();
                    }
                    else
                    {
                        Console.WriteLine(nev2 + " lép");
                        Console.WriteLine("Sor:");
                        try
                        {
                            int mapLine = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Oszlop:");
                            string mapCol = Console.ReadLine().ToUpper();
                            int selectedCol = -1;

                            if (mapCol == "A") selectedCol = 0;
                            if (mapCol == "B") selectedCol = 1;
                            if (mapCol == "C") selectedCol = 2;


                            if (selectedCol > -1 && gameMap[mapLine, selectedCol] == 0)
                            {

                                gameMap[mapLine, selectedCol] = -1;
                                currentPlayer = "X";
                                turns++;
                            }
                        } catch
                        {
                            gameWon = true;
                            string str = $"{nev2} feladta {nev1} nyert";
                            Console.WriteLine(str);

                        }
                        checkWinConditions();
                    }
                } else
                {
                    gameWon = true;
                    Console.WriteLine("Döntetlen.");
                }
            }

            void botTurn()
            {
                if (turns < 9)
                {
                    if (currentPlayer == "O")
                    {
                        Console.WriteLine(nev2 + " lép!");
                        
                        int line = random.Next(0,3);
                        int column = random.Next(0, 3);
                        Console.WriteLine("Gondolkozik...");

                        while (gameMap[line,column] != 0)
                        {
                            line = random.Next(0, 3);
                            column = random.Next(0, 3);
                        }


                        gameMap[line, column] = -1;
                        currentPlayer = "X";
                        checkWinConditions();
                    }
                    
                }
                else
                {
                    gameWon = true;
                    Console.WriteLine("Döntetlen.");
                }
            }

            void checkWinConditions()
            {
                bool row1SumX = gameMap[0, 0] + gameMap[0, 1] + gameMap[0, 2] == 3;     
                bool row1SumO = gameMap[0, 0] + gameMap[0, 1] + gameMap[0, 2] == -3;
                bool row2SumX = gameMap[1, 0] + gameMap[1, 1] + gameMap[1, 2] == 3;     
                bool row2SumO = gameMap[1, 0] + gameMap[1, 1] + gameMap[1, 2] == -3;
                bool row3SumX = gameMap[2, 0] + gameMap[2, 1] + gameMap[2, 2] == 3;     
                bool row3SumO = gameMap[2, 0] + gameMap[2, 1] + gameMap[2, 2] == -3;

                bool col1SumX = gameMap[0,0] + gameMap[1, 0] + gameMap[2,0] == 3;
                bool col1SumO = gameMap[0,0] + gameMap[1, 0] + gameMap[2,0] == -3;
                bool col2SumX = gameMap[0,1] + gameMap[1, 1] + gameMap[2,1] == 3;
                bool col2SumO= gameMap[0,1] + gameMap[1, 1] + gameMap[2,1] == -3;
                bool col3SumX = gameMap[0,2] + gameMap[1, 2] + gameMap[2,2] == 3;
                bool col3SumO = gameMap[0,2] + gameMap[1, 2] + gameMap[2,2] == -3;

                bool diagonal1SumX = gameMap[0, 0] + gameMap[1, 1] + gameMap[2, 2] == 3;
                bool diagonal1SumO = gameMap[0, 0] + gameMap[1, 1] + gameMap[2, 2] == -3;
                bool diagonal2SumX = gameMap[0, 2] + gameMap[1, 1] + gameMap[2, 0] == 3;
                bool diagonal2SumO = gameMap[0, 2] + gameMap[1, 1] + gameMap[2, 0] == -3;

                if (row1SumX || row2SumX || row3SumX || col1SumX || col2SumX || col3SumX || diagonal1SumX || diagonal2SumX)
                {
                    printGameMap();
                    gameWon = true;
                    Console.WriteLine(nev1 + " nyert");

                    gameController();
                }
                if (row1SumO || row2SumO || row3SumO || col1SumO || col2SumO || col3SumO || diagonal1SumO || diagonal2SumO)
                {
                    printGameMap();
                    gameWon = true;
                    Console.WriteLine(nev2 + " nyert");

                    gameController();
                }
            }

            void gameController()
            {

                Console.WriteLine("1 - PVP 2 - BOT");
                string option = Console.ReadLine();
                turns = 0;
                gameWon = false;
                currentPlayer = "X";
                gameMap = new int[3, 3] {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0},
                };

                if (option == "1")
                {
                    try
                    {
                        Console.WriteLine("Adjon meg 2 nevet:");
                        nev1 = Console.ReadLine();
                        nev2 = Console.ReadLine();
                        while (!gameWon)
                        {

                            playerTurn();

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Hibás adatok");
                    }
                }

                if(option == "2")
                {
                    try
                    {
                        Console.WriteLine("Adjon meg 2 nevet:");
                        nev1 = Console.ReadLine();
                        nev2 = Console.ReadLine()  + " (BOT)";
                        while (!gameWon)
                        {

                            if(currentPlayer == "X")
                            {
                                playerTurn();
                            } else
                            {
                                botTurn();
                            }
                           
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Hiba!");
                    }
                }

                if(option != "2" && option != "3")
                {
                    Console.WriteLine("Kilépés...");
                    Environment.Exit(0);
                }

                
            } 

            gameController();

        }
    }
}
