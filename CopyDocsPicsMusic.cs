using System;

namespace ReformatBackup
{
	public class CopyDocsPicsMusic : CopyFolder
	{
		bool restoreMode = false;
		public CopyDocsPicsMusic (DirectoryCopy dc) : base (dc)
		{
			DC = dc;
		}
		public override void copyFiles ()
		{
			//string sourceDir = @"C:\Users\" + DC.user + @"\My Documents\";
			string destDir = DC.backupDirectory + @"C\Users\" + DC.user + @"\My Documents\";

			Console.WriteLine ("\nCopying My Documents");
			copyMyDocs(destDir);
			Console.WriteLine ("Done.\nCopying My Pictures");
			copyMyPictures(destDir + @"My Pictures\");
			Console.WriteLine ("Done.\nCopying My Music");
			copyMyMusic (destDir + @"My Music\");
			Console.WriteLine("Done.");
		}
		override public void restoreFiles(){
			restoreMode = true;
			string destDir = DC.backupDirectory + @"C\Users\" + DC.user + @"\My Documents\";

			Console.WriteLine ("\nRestoring My Documents");
			copyMyDocs(destDir);
			Console.WriteLine ("Done.\nRestoring My Pictures");
			copyMyPictures(destDir + @"My Pictures\");
			Console.WriteLine ("Done.\nRestoring My Music");
			copyMyMusic (destDir + @"My Music\");
			Console.WriteLine("Done.");
		}
		public void copyMyDocs(string destDir){
			string myDocs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			Console.WriteLine ("MyDocs: {0}",myDocs );
			if(restoreMode){
				DC.CopyDirectory (destDir, myDocs, true);
			}else {
				DC.CopyDirectory (myDocs, destDir, true);
			}
		}
		public void copyMyMusic(string destDir){
			string myMusic = Environment.GetFolderPath (Environment.SpecialFolder.MyMusic);
			Console.WriteLine ("MyMusic: {0}",myMusic );
			if(restoreMode) {
				DC.CopyDirectory (destDir, myMusic, true);
			}else {
				DC.CopyDirectory (myMusic, destDir, true);
			}
		}
		public void copyMyPictures(string destDir){
			string myPics = Environment.GetFolderPath (Environment.SpecialFolder.MyPictures);
			Console.WriteLine ("MyPictures: {0}",myPics );
			if (restoreMode) {
				DC.CopyDirectory (destDir, myPics, true);
			} else {
				DC.CopyDirectory (myPics, destDir, true);
			}
		}

	}
}

