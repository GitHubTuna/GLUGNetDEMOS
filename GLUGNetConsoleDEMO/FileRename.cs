using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GLUGNetConsoleDEMO
{
    class FileRename
    {
        public int TotalRecords = 0;

        public void RenameFiles()
        //Ready for TM Presentation: Files are currently named "LESSON"
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

                    if (filename.Contains("TEST"))
                    {
                        string newfile = filename.Replace("TEST", "JacobText");
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
