using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLUGNetConsoleDEMO
{

    class Program
    {
        static void Main(string[] args)
        {
            //FortunaPhotos is now helping with this project

            //Future changes - Remove extra code in File Rename class.
            //Add a UI
            //Return Modified File Names as well as count.

            //Added code to check for case sentive differences using:
            //https://stackoverflow.com/questions/444798/case-insensitive-containsstring
            //https://stackoverflow.com/questions/6275980/string-replace-ignoring-case

            FileRename myFile = new FileRename();
            myFile.RenameFiles();
            Console.WriteLine(myFile.TotalRecords);
            Console.ReadLine();
        }
    }
}
   
