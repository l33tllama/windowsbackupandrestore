using System;
using System.IO;

/*Things to backup from C
 * Selected folders
 * User/
 * 	AppData/
 * 		Selected folders
 * 		Local/Selected folders
 * 		LocalLow/Selected folders
 * 		Roaming/selected folders
 * 	My Documents/All Stuff
 * 	My Pictures/All Stuff
 * 	My Music/All Stuff
 * 	ProgramData/Selected folders
 * 
 * List of programs in Program files
 * 
*/

namespace ReformatBackup
{
	class MainClass
	{
		static string backupDirectory;
		static string userName;
		static CopyAppDataLocal cAppDataLocal;
		static DirectoryCopy dc;
		static CopyC cC;
		static CopyAppDataLocalLow cAppDataLocalLow;
		static CopyAppDataRoaming cAppDataRoaming;
		static CopyProgramData cProgData;
		static CopyProgramFiles cProgFiles;
		static CopyUser cUser;
		static CopyDocsPicsMusic cDPM;
		static CopyDirectoryLists cDirLists;
		static bool restoreMode = false;
		public static void Main (string[] args)
		{
			Console.WriteLine ("Windows Application Data Backup and Restore");
			Console.WriteLine ("Restore Mode? (Enter 'restore', otherwise ENTER for backup mode)");

			string inputMode = Console.ReadLine ();
			if (inputMode == "restore") {
				restoreMode = true;
			}
			Console.WriteLine (@"Enter backup directory (ENTER for Default: E:\backup\PCSwapJul2013\)");
			//TODO: restore mode
			string inputDir = Console.ReadLine ();
			backupDirectory = @"E:\backup\PCSwapJul2013\";
			if(inputDir != ""){
				backupDirectory = inputDir;
			}

			Console.WriteLine (@"Enter Windows User Name that you want to backup (ENTER for Default: Leo)");
			string inputName = Console.ReadLine ();
			userName = "Leo";
			if (inputName != "") {
				userName = inputName;
			}

			dc = new DirectoryCopy (backupDirectory, "Leo");
			cC = new CopyC (dc);
			cAppDataLocal = new CopyAppDataLocal (dc);
			cAppDataLocalLow = new CopyAppDataLocalLow (dc);
			cAppDataRoaming = new CopyAppDataRoaming (dc);
			cProgData = new CopyProgramData (dc);
			cProgFiles = new CopyProgramFiles (dc);
			cUser = new CopyUser (dc);
			cDPM = new CopyDocsPicsMusic (dc);
			cDirLists = new CopyDirectoryLists (backupDirectory);
			if (restoreMode) {
				cAppDataLocal.restoreFiles ();
				cAppDataLocalLow.restoreFiles ();
				cAppDataRoaming.restoreFiles ();
				cDPM.restoreFiles ();
				cProgData.restoreFiles ();
				cProgFiles.restoreFiles ();
				cUser.restoreFiles ();
				Console.WriteLine ("Restore Complete!!!");
			} else {
				cAppDataLocal.copyFiles ();
				cAppDataLocalLow.copyFiles ();
				cAppDataRoaming.copyFiles();
				cC.copyFiles ();
				cDPM.copyFiles ();
				cProgData.copyFiles ();
				cProgFiles.copyFiles ();
				cUser.copyFiles ();

				cDirLists.copyTextFiles ();
				Console.WriteLine ("Backup Complete!!!");
			}




			Console.ReadKey ();
		}
	}
}
