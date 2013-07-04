using System;

namespace ReformatBackup
{
	public class CopyProgramData : CopyFolder
	{
		public CopyProgramData (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
			sourceFolder = @"C:\ProgramData\";
			destFolder = @"C\ProgramData\";
			File = @"ProgramData.txt";
		}
	}
}

