using System;
using System.Threading;
namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int mark;
        static int gameStatus = 0;

        static void Main(string[] args)
        {
            //Manages all inputs and game completion
            do
            {
                Update();

                //Reads input for space to mark, checks if input is valid
                while(true)
                {
                    Console.WriteLine("Select space to mark");

                    //Checks if input is an integer
                    if (int.TryParse(Console.ReadLine(), out mark))
                    {
                        if (mark >= 1 && mark <= 9)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Please enter a valid number");

                    Thread.Sleep(2000);
                    Update();
                }


                //Marks space if it is empty, prompts new input if not
                if (num[mark] != 'X' && num[mark] != 'O')
                {
                    if (player == 1)
                    {
                        num[mark] = 'X';
                        player++;
                    }
                    else
                    {
                        num[mark] = 'O';
                        player--;
                    }
                }
                else
                {
                    Console.WriteLine("Please select an empty space.");
                    Thread.Sleep(2000);
                }

                gameStatus = WinCondition();

            }
            while (gameStatus == 0);

            //Displays end
            if (gameStatus == 1)
            {
                if (player == 1)
                {
                    player++;
                }
                else
                {
                    player--;
                }
                Console.Clear();
                DrawBoard();
                Console.WriteLine();
                Console.WriteLine("Player " + player + " wins.");
            }
            else if (gameStatus == -1)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine();
                Console.WriteLine("The game is a draw.");
            }
                
            //Draws Tic Tac Toe Board
            static void DrawBoard()
            {
                Console.WriteLine("   {0}  |  {1}  |  {2}   ", num[1], num[2], num[3]);
                Console.WriteLine("-------------------");
                Console.WriteLine("   {0}  |  {1}  |  {2}   ", num[4], num[5], num[6]);
                Console.WriteLine("-------------------");
                Console.WriteLine("   {0}  |  {1}  |  {2}   ", num[7], num[8], num[9]);
            }

            //Manages player turns and updates game
            static void Update()
            {
                Console.Clear();
                if (player == 1)
                {
                    
                    Console.WriteLine("Player 1 turn");
                }
                else
                {
                    Console.WriteLine("Player 2 turn");
                }

                Console.WriteLine();
                DrawBoard();
                Console.WriteLine();
            }

            //Check if a player has won
            static int WinCondition()
            {
                //Horizontal wins
                if (num[1] == num[2] && num[2] == num[3])
                {
                    return 1;
                }
                else if (num[4] == num[5] && num[5] == num[6])
                {
                    return 1;
                }
                else if (num[7] == num[8] && num[8] == num[9])
                {
                    return 1;
                }
                //Vertical wins
                else if (num[1] == num[4] && num[4] == num[7])
                {
                    return 1;
                }
                else if (num[2] == num[5] && num[5] == num[8])
                {
                    return 1;
                }
                else if (num[3] == num[6] && num[6] == num[9])
                {
                    return 1;
                }
                //Diagonal wins
                else if (num[1] == num[5] && num[5] == num[9])
                {
                    return 1;
                }
                else if (num[3] == num[5] && num[5] == num[7])
                {
                    return 1;
                }
                //Check for draws
                else if (num[1] != '1' && num[2] != '2' && num[3] != '3' && num[4] != '4' && num[5] != '5' && num[6] != '6'
                    && num[7] != '7' && num[8] != '8' && num[9] != '9')
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}