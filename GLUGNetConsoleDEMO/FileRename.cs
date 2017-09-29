using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace GLUGNetConsoleDEMO
{
    class FileRename
    {
        public int TotalRecords = 0;

        public void RenameFiles()

        {
            //Loop with LINQ as possible enhancement
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-query-for-duplicate-files-in-a-directory-tree-linq

            //Added code to check for case sentive differences using:
            //https://stackoverflow.com/questions/444798/case-insensitive-containsstring
            //https://stackoverflow.com/questions/6275980/string-replace-ignoring-case

            string FileLocation = @"C:\GlugNetDEMO";

            //TEST ASUS COMMIT

            //Added code to check for directory existing as well.
            if (!Directory.Exists(FileLocation))
            {
                Directory.CreateDirectory(FileLocation);
            }
            //Initialize Files 
            for (int i = 1; i < 100; i++)
            {
                if (!File.Exists(FileLocation + @"\Text" + i + ".txt") && !File.Exists(FileLocation + @"\Jacob" + i + ".txt"))
                {
                    File.Create(FileLocation + @"\Text" + i + ".txt").Close();
                    //Close is needed or the file will be locked when you try to move it
                }
            }

            if (Directory.Exists(FileLocation))
            {   
                foreach (var file in Directory.GetFiles(FileLocation))
                {
                    string filename = new FileInfo(file).Name;

                    string testString;
                    string replaceString;
                    
                    //Initialize Files to be Renamed based upon what is found:
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

                    if (filename.IndexOf (testString,0,StringComparison.CurrentCultureIgnoreCase)!=-1)
                    {
                        //File.Delete(file);
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
