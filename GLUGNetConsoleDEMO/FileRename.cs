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
            bool isReset = false;
            string fileLocation = @"C:\GlugNetDEMO";
            //Added code to check for directory existing as well.
            if (!Directory.Exists(fileLocation))
            {
                Directory.CreateDirectory(fileLocation);
            }

            Console.WriteLine("Type 'Y' to reset folder's contents to nothing");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                isReset = true;
            }

            Process.Start("explorer.exe", fileLocation);

            //Initialize Files 
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
                        if(isReset)
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
