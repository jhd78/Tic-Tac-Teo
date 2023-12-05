using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]
        {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };

        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Current player: " + currentPlayer);
                Console.WriteLine("Enter row and column separated by a space: ");

                int row, col;

                //read the input then check if it valid or not if so try again 
                try
                {
                    string[] inputs = Console.ReadLine().Split(' ');
                    row = int.Parse(inputs[0]) - 1;
                    col = int.Parse(inputs[1]) - 1;

                    //if it not valid move try again
                    if (row < 0 || row > 2 || col < 0 || col > 2)
                    {
                        Console.WriteLine("Invalid move. Try again.");
                        continue;
                    }

                    //if filled try again
                    if (board[row, col] != ' ')
                    {
                        Console.WriteLine("Cell already filled. Try again.");
                        continue;
                    }
                }

                //if error input try again
                catch
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                board[row, col] = currentPlayer;
                PrintBoard();

                if (IsWinningMove(row, col))
                {
                    Console.WriteLine(currentPlayer + " wins!");
                    break;
                }

                if (IsDraw())
                {
                    Console.WriteLine("Draw!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        //print for the input
        static void PrintBoard()
        {
            Console.WriteLine();
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static bool IsWinningMove(int row, int col)
        {
            // Check row
            for (int i = 0; i < 3; i++)
            {
                if (board[row, i] != currentPlayer)
                {
                    break;
                }

                if (i == 2)
                {
                    return true;
                }
            }

            // Check column
            for (int i = 0; i < 3; i++)
            {
                if (board[i, col] != currentPlayer)
                {
                    break;
                }

                if (i == 2)
                {
                    return true;
                }
            }

            // Check diagonal
            if (row == col)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, i] != currentPlayer)
                    {
                        break;
                    }
                    if (i == 2)
                    {
                        return true;
                    }
                }
            }

            // Check reverse diagonal
            if (row + col == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 2 - i] != currentPlayer)
                    {
                        break;
                    }

                    if (i == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
