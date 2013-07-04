using System;

namespace ReformatBackup
{
	public class CopyAppDataRoaming : CopyFolder
	{
		public CopyAppDataRoaming (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
			sourceFolder = @"C:\Users\" + DC.user + @"\AppData\Roaming\";
			destFolder = @"C\Users\" + DC.user + @"\AppData\Roaming\";
			File = @"AppDataRoaming.txt";
		}
	}
}

