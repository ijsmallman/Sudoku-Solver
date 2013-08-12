using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace Sudoku
{
	public class BasicSudokuReader : ISudokuReader
	{
		public Sudoku Read(string path)
		{
			List<int> dat = new List<int>();
			if (File.Exists(path))
			{
				string fileContent = File.ReadAllText(path);
				string[] array = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
				
				foreach(string s in array)
				{
					dat.Add(Convert.ToInt32(s, CultureInfo.InvariantCulture));
				}
			}
			return new Sudoku(dat);
		}
	}
}
