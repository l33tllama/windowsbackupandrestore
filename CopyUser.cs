using System;

namespace ReformatBackup
{
	public class CopyUser : CopyFolder
	{
		public CopyUser (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
			sourceFolder = @"C:\Users\" + DC.user + @"\";
			destFolder = @"C\Users\" + DC.user + @"\";
			File = @"User.txt";
		}
	}
}