using System;
using System.Collections.Generic;

namespace Sudoku
{
	public interface ISudokuSolverStrategy
	{
        Sudoku Solve(Sudoku sudoku);
	}
}

