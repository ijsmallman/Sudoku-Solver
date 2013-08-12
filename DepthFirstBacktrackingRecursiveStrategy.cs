using System;
using System.Collections.Generic;

namespace Sudoku
{
	public class DepthFirstBacktrackingRecursiveStrategy : ISudokuSolverStrategy
	{
        private Sudoku Sudoku;

		public Sudoku Solve(Sudoku sudoku)
		{
            Sudoku = new Sudoku(sudoku);
			RecursiveSolve(Sudoku, Sudoku.FindZero());
			return Sudoku;
		}
		
		public void RecursiveSolve(Sudoku sudoku, int pos)
		{
            if (sudoku.Complete())
            {
                sudoku.Solved = true;
                return;
            }
            foreach (int i in sudoku.AvailableNumbers(pos))
            {
                sudoku.Values[pos] = i;
                RecursiveSolve(sudoku, sudoku.FindZero());
                if (sudoku.Solved) break;
                sudoku.Values[pos] = 0;
            }
		}
	}
}

