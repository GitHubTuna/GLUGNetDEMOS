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
            FileRename myFile = new FileRename();
            myFile.RenameFiles();
            Console.WriteLine(myFile.TotalRecords);
            Console.ReadLine();
        }
    }
}
   
