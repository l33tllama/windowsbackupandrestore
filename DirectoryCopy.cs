using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ReformatBackup
{
	public class DirectoryCopy
	{
		public string backupDirectory { get; set;}
		public string user { get; set;}
		public DirectoryCopy (string backupDirectory, string user)
		{
			this.backupDirectory = backupDirectory;
			this.user = user;
		}
		public void CopyDirectory(string sourceDir, string destDir, bool copySubDirs){
			DirectoryInfo dirInfo = new DirectoryInfo (sourceDir);
			try{
				DirectoryInfo[] dirs = dirInfo.GetDirectories();

				if(!dirInfo.Exists){
					throw new DirectoryNotFoundException ("Source dir doesn't exist or couldn't be cound: " + sourceDir);
				}

				if (!Directory.Exists (destDir)) {
					Directory.CreateDirectory (destDir);
				}
				
	       		FileInfo[] files = dirInfo.GetFiles();

				foreach (FileInfo file in files) {
					string temppath = Path.Combine (destDir, file.Name);
					if (!File.Exists(temppath)) {
						//Console.WriteLine ("Copying {0} to {1}.", file.Name, temppath); 
						try{
							file.CopyTo (temppath, false);
						}
						catch(PathTooLongException ex){
							Console.WriteLine (ex.Message);
						}
					} else {
						FileInfo destFile = new FileInfo(destDir);
						if(destFile.LastWriteTime < file.LastWriteTime){
							Console.WriteLine("File has been modified since last copy. Now coying new file: {0} ", file.Name);
						} else {
							Console.WriteLine ("Skipping {0}, file already exists, and is not newer.", file.Name);
						}
					}

				}

				if(copySubDirs){
					foreach (DirectoryInfo subdir in dirs){
						string temppath = Path.Combine (destDir, subdir.Name);
						CopyDirectory (subdir.FullName, temppath, copySubDirs);
					}
				}
			}
			catch(UnauthorizedAccessException e){
				Console.WriteLine ("Access denied to {0}, skipping.. {1}", sourceDir, e);
			}
		}
	}
}

