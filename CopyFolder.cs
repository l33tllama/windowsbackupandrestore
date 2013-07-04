using System;
using System.IO;

namespace ReformatBackup
{
	public class CopyFolder
	{
		public DirectoryCopy DC { get; set;}
		public string sourceFolder { get; set;}
		public string destFolder {get;set;}
		public string File { get; set;}
		public CopyFolder (DirectoryCopy dc)
		{
			this.DC = dc;
		}
		virtual public void copyFiles(){
			try {
				using (StreamReader txr = new StreamReader (File)) {
					string tempDir;
					string sourceDir;
					string destDir;
					Console.WriteLine("\nCopying {0} to {1}", sourceFolder, DC.backupDirectory + destFolder);
					while ((tempDir = txr.ReadLine()) != null) {
						sourceDir = sourceFolder + tempDir;
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
		virtual public void restoreFiles(){
			try {
				using (StreamReader txr = new StreamReader(File)){
					string tempDir;
					string sourceDir;
					string destDir;
					Console.WriteLine("\nRestoring {0} to {1}", DC.backupDirectory + destFolder, sourceFolder);
					while((tempDir = txr.ReadLine()) != null){
						sourceDir = DC.backupDirectory + destFolder + tempDir;
						destDir = sourceFolder + tempDir;
						Console.WriteLine("Dir: {0}, Backup Source: {1}, Backup Dest: {2}.", tempDir, sourceDir, destDir);
						DC.CopyDirectory(sourceDir, destDir, true);
					}
					Console.WriteLine("Done.");
				}
			}catch (Exception e) {
				Console.WriteLine ("The file could not be read:");
				Console.WriteLine (e.Message);
			}
		}
	}
}

