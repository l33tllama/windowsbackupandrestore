using System;
using System.IO;

namespace ReformatBackup
{
	public class CopyC : CopyFolder
	{	
		public CopyC (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
			sourceFolder = @"C:\";
			destFolder = @"C\";
			File = @"C.txt";
		}
	}
}

