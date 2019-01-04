using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToeGame
{
    class MainClass
    {
        //Creates the board and sets the player to player 1
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
       
        static void Main(string[] args)
        {
            //Builds the board, and loops until there is a player
            BuildBoard();
            while(DidWin() == -1)
            {
                //Sets the slot with a 0 or X depending on the turn
                if(player % 2 == 0)
                {
                    PlayerInput('0');
                }
                else
                {
                    PlayerInput('X');
                }
                player++;
                BuildBoard();
            }
            if (DidWin() == 1)
            {
                //Tells who has won
                if (player % 2 != 0)
                {
                    Console.WriteLine("Player 2 has WON!!!!!");
                }
                else
                {
                    Console.WriteLine("Player 1 has WON!!!!!");
                }
            }
            else if(DidWin() == 0)
            {
                Console.WriteLine("The game is a draw.");
            }
        }
        //Checks to see if the user wants to play against another player or the computer
        private static int PV()
        {
            Console.WriteLine("Enter in '1' for 2 player. Enter in a '2' to play against a computer.");
            int pv = int.Parse(Console.ReadLine());
            while(PVInputValidation(pv) == false)
            {
                Console.WriteLine("The number you entered was not 1 or 2, please enter in a new number: ");
                pv = int.Parse(Console.ReadLine());
            }
            return pv;
        }
        //Input Validation
        private static Boolean PVInputValidation(int pv)
        {
            if(pv == 1 || pv == 2)
            {
                return true;
            }
            return false;
        }

        //Checks to see if anyone won 
        private static int DidWin()
        {
            //Horizontal winning
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }

            //Vertical winning
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }

            //Diagonal Winning
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            //Draw
            else if(board[1] != '1' && board[2] != '2' && board[3] != '3' 
            & board[4] != '4' && board[5] != '5' && board[6] != '6' 
                && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return 0;
            }
            //Keeps the game going
            else
            {
                return -1;
            }

        }
        //Gets the player input and sets it to the board
        private static void PlayerInput(char item)
        {
            Console.WriteLine("Enter in the space you want to move at:");
            int playerInput = int.Parse(Console.ReadLine());
            while(board[playerInput] == 'X' || board[playerInput] == '0' || InputValidation(playerInput) == false)
            {
                if(InputValidation(playerInput) == false)
                {
                    Console.WriteLine("You entered in a non 1-9 digit.");
                }
                else
                {
                    Console.WriteLine("The spot is alread filled.");
                }
                Console.WriteLine("Please enter in a new spot: ");
                playerInput = int.Parse(Console.ReadLine());
            }
            board[playerInput] = item;
        }
        //Input Validation
        private static Boolean InputValidation(int input)
        {
            String regex = ( @"[1-9]");
            Match m = Regex.Match(input.ToString(), regex, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        //Still in Development
        //Computer Input
        private static void ComputerInput()
        {
            Random rnd = new Random();
            int CompChoice = rnd.Next(1, 9);
            while (board[CompChoice] == 'X' || board[CompChoice] == '0')
            {
                CompChoice = rnd.Next(1, 9);
            }
        }
        //Builds the board
        private static void BuildBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("   {0} | {1}   | {2} ", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("   {0} | {1}   | {2} ", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("   {0} | {1}   | {2} ", board[7], board[8], board[9]);
            Console.WriteLine("     |     |     ");
        }
    }
}
