using System;
using System.IO;

namespace ReformatBackup
{
	public class CopyDirectoryLists
	{
		private string backupDest;
		public CopyDirectoryLists (string backupDirectory)
		{
			backupDest = backupDirectory;
		}
		public void copyTextFiles(){
			DirectoryInfo dirInfo = new DirectoryInfo (".");
			FileInfo[] files = dirInfo.GetFiles ("*.txt");
			foreach (FileInfo textFile in files) {
				textFile.CopyTo (Path.Combine(backupDest, textFile.Name), true);
			}
		}
	}
}

