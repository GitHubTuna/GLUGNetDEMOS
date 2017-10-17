namespace GLUGNetConsoleDEMO
{
    //References for working with Contains and Replace on text that has case sensitivity issues.
    //https://stackoverflow.com/questions/444798/case-insensitive-containsstring
    //https://stackoverflow.com/questions/6275980/string-replace-ignoring-case
    //Test Author

    class FileRename
    {
        //Has branch with changes but another PC has a more updated version

        public int TotalRecords = 0;
        //Test VAIO Commit
        public void RenameFiles()
        {
            //TEST
            string FileLocation = @"C:\Fortuna";

            if (Directory.Exists(FileLocation))
            {
                foreach (var file in Directory.GetFiles(FileLocation))
                {
                    string filename = new FileInfo(file).Name;

                    string testString;
                    string replaceString;
                    //TEST
                    testString = "Jacob";
                    if (filename.IndexOf(testString, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        replaceString = "Text";
                    }
                    else
                    {
                        testString = "Text";
                        replaceString = "Jacob";
                    }

                    if (filename.IndexOf(testString, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        string newfile = Regex.Replace(filename, testString, replaceString, RegexOptions.IgnoreCase);
                        newfile = FileLocation + @"\" + newfile;
                        File.Move(file, newfile);
                        TotalRecords++;
                    }
                }
            }
        }
    }
}