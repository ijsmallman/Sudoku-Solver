using System;
using System.Collections.Generic;

namespace Sudoku
{
	public class SudokuSolver
	{
		private ISudokuSolverStrategy Strategy;
		
		public SudokuSolver (ISudokuSolverStrategy strategy)
		{
			Strategy = strategy;
		}
		
		public Sudoku Solve(Sudoku sudoku)
		{
			return Strategy.Solve(sudoku);
		}
	}
}

