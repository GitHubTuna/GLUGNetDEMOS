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
        //This looks incorrect to me Jacob...
        public int TotalRecords = 0;

        public void RenameFiles()
        {
            // @ makes "\" read as a directory
            string FileLocation = @"C:\Fortuna";

            if (Directory.Exists(FileLocation))
            {
                //foreach (var folder in Directory.GetDirectories(FileLocation))
                //{
                foreach (var file in Directory.GetFiles(FileLocation))
                {
                    //if (file.EndsWith("_4.jpg"))
                    //{
                    
                    string filename = new FileInfo(file).Name;

                    string testString;
                    string replaceString;
                    
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
                        string newfile = Regex.Replace(filename, testString,replaceString,RegexOptions.IgnoreCase);
                        newfile = FileLocation + @"\" + newfile;
                        File.Move(file, newfile);
                        TotalRecords++;
                    }  
                }
                //}
                //}
            }
        }
    }
}
