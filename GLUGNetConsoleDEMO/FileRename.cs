using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

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

            bool removeFiles=false;

            Console.WriteLine("Remove all text files created from this app from your PC? (Y/N)");
            if (Console.ReadLine().ToUpper()=="Y")
            {
                removeFiles = true;
            }

            string fileLocation = @"C:\GlugNetDEMO";

            if (!Directory.Exists(fileLocation))
            {
                Directory.CreateDirectory(fileLocation);
            }

            Process.Start("explorer.exe", fileLocation);

            //Create set of files to rename
            for (int i = 1; i < 100; i++)
            {
                if (!File.Exists(fileLocation + @"\Text" + i + ".txt") && !File.Exists(fileLocation + @"\Jacob" + i + ".txt"))
                {
                    File.Create(fileLocation + @"\Text" + i + ".txt").Close();
                    //Close is needed or the file will be locked when you try to move it
                }
            }

            if (Directory.Exists(fileLocation))
            {   
                foreach (var file in Directory.GetFiles(fileLocation))
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
                        if (removeFiles)
                        {
                            File.Delete(file);
                        }
                        else
                        {
                            string newfile = Regex.Replace(filename, testString, replaceString, RegexOptions.IgnoreCase);
                            newfile = fileLocation + @"\" + newfile;
                            File.Move(file, newfile);
                            TotalRecords++;
                        }
   
                    }  
                }
            }
        }
    }
}
