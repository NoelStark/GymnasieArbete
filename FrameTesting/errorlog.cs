using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FrameTesting
{
    class errorlog
    {
        public static void log(string message) //gets a message 
        {
            string path = @"C:\Mappar\config\error.txt"; //locates the error log
            File.AppendAllText(path, message + Environment.NewLine); //writes the error in the file
        }
    }
}
