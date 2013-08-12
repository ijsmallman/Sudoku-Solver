using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace Sudoku
{
	public interface ISudokuPrinter
	{
		void Print(Sudoku sudoku);
	}
}
