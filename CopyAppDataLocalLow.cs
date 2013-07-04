using System;

namespace ReformatBackup
{
	public class CopyAppDataLocalLow : CopyFolder
	{
		public CopyAppDataLocalLow (DirectoryCopy dc) : base(dc)
		{
			DC = dc;
			sourceFolder = @"C:\Users\" + DC.user + @"\AppData\LocalLow\";
			destFolder = @"C\Users\" + DC.user + @"\AppData\LocalLow\";
			File = @"AppDataLocalLow.txt";
		}
	}
}

