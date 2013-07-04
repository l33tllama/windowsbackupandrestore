using System;

namespace ReformatBackup
{
	public class CopyAppDataLocal : CopyFolder
	{
		public CopyAppDataLocal (DirectoryCopy dc) :base(dc)
		{
			DC = dc;
			sourceFolder = @"C:\Users\" + DC.user + @"\AppData\Local\";
			destFolder = @"C\Users\" + DC.user + @"\AppData\Local\";
			File = @"AppDataLocal.txt";
		}
	}
}

