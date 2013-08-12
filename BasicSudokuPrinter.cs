using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace Sudoku
{
	public class BasicSudokuPrinter : ISudokuPrinter
	{
		public void Print(Sudoku sudoku)
		{
			Console.Write("+");
			for (int i = 0; i < sudoku.SqrtMaxValue; i++)
			{
				for (int j = 0; j < sudoku.SqrtMaxValue; j ++)
				{
					Console.Write("-");
				}
				Console.Write("+");
			}
			Console.Write("\n");
			for (int i = 0; i < sudoku.Values.Count; i++)
			{
				if ( i % sudoku.SqrtMaxValue == 0 ) Console.Write("|");
				Console.Write(sudoku.Values[i]);
				if ( (i+1) % sudoku.MaxValue == 0 ) Console.Write("|\n");
				if ( (i+1) % sudoku.SecRowCount == 0 )
				{
					Console.Write("+");
					for (int j = 0; j < sudoku.SqrtMaxValue; j++)
					{
						for (int k = 0; k < sudoku.SqrtMaxValue; k++)
						{
							Console.Write("-");
						}
						Console.Write("+");
					}
					Console.Write("\n");
				}
			}
		}
	}
}
