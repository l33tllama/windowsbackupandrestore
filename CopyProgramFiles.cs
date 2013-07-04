using System;
using System.IO;

namespace ReformatBackup
{
	public class CopyProgramFiles : CopyFolder
	{
		public CopyProgramFiles (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
			File = @"ProgramFiles.txt";
		}
		override public void copyFiles(){
			try {
				using (StreamReader txr = new StreamReader (File)) {
					string tempDir;
					string sourceDir;
					string destDir;
					while ((tempDir = txr.ReadLine()) != null) {
						sourceDir = tempDir;
						if(tempDir[16] == '\\'){
							sourceFolder = tempDir.Substring(0, 16);
							destFolder = @"C\Program Files\";
							tempDir = tempDir.Substring(17);
						} else {
							sourceFolder = tempDir.Substring(0, 22);
							destFolder = @"C\Program Files (x86)\";
							tempDir = tempDir.Substring(23);
						}

						Console.WriteLine("\nCopying {0} to {1}", sourceFolder, DC.backupDirectory + destFolder);
						destDir = DC.backupDirectory + destFolder + tempDir;
						Console.WriteLine ("Dir: {0}, Source: {1}, Dest: {2}", tempDir, sourceDir, destDir);
						DC.CopyDirectory(sourceDir, destDir, true);
					}
					Console.WriteLine("Done.");
				}
			} catch (Exception e) {
				Console.WriteLine ("The file could not be read:");
				Console.WriteLine (e.Message);
			}
		}
	}
}

