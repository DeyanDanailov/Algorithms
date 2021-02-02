using System;
using System.Collections.Generic;

namespace EightQueens
{
    public class StartUp
    {
        private const int boardSize = 8;
        static int[,] board = new int[boardSize, boardSize];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void TryPutQueen(int row)
        {
            if (row == boardSize)
            {
                PrintBoard(board);
                return;
            }
            else
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedFields(row, col);
                        TryPutQueen(row + 1);
                        UnmarkAttackedFields(row, col);
                    }

                }
            }
        }

        private static void UnmarkAttackedFields(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAttackedFields(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
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

        private static void PrintBoard(int[,] board)
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
            Console.WriteLine("-------------------------");
        }

        static void Main(string[] args)
        {
            TryPutQueen(0);

        }
    }
}
