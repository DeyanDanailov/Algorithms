using System;
using System.Collections.Generic;

namespace EightQueens
{
    public class StartUp
    {
       
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void TryPutQueen(int row, int boardSize, int[,] board)
        {
            if (row == boardSize)
            {
                PrintBoard(board, boardSize);
                return;
            }
            else
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (CanPlaceQueen(row, col, boardSize, board))
                    {
                        MarkAttackedFields(row, col, board);
                        TryPutQueen(row + 1, boardSize, board);
                        UnmarkAttackedFields(row, col, board);
                    }

                }
            }
        }

        private static void UnmarkAttackedFields(int row, int col, int[,] board)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAttackedFields(int row, int col, int[,] board)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col, int boardSize, int[,] board)
        {
            if (attackedRows.Contains(row))
            {
                return false;
            }
            if (attackedCols.Contains(col))
            {
                return false;
            }
            var leftRow = row;
            var leftCol = col;
            while (leftRow != 0 && leftCol != 0)
            {
                leftRow--;
                leftCol--;
            }
            while (leftRow != boardSize - 1 && leftCol != boardSize - 1)
            {
                if (board[leftRow, leftCol] == 1)
                {
                    return false;
                }
                leftRow++;
                leftCol++;
            }
            var rightRow = row;
            var rightCol = col;
            while (rightRow != 0 && rightCol != boardSize - 1)
            {
                rightRow--;
                rightCol++;
            }
            while (rightRow != boardSize - 1 && rightCol != 0)
            {
                if (board[rightRow, rightCol] == 1)
                {
                    return false;
                }
                rightRow++;
                rightCol--;
            }
            return true;
        }

        private static void PrintBoard(int[,] board, int boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i, j] == 1)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------");
        }

        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            int[,] board = new int[boardSize, boardSize];
            TryPutQueen(0, boardSize, board);

        }
    }
}
