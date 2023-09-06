using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FrameTesting
{
    class DirectoryCreate
    {
        public static string source = @"C:\Mappar";
        public static string config = $@"{source}\config";
        public static void Create()
        {
            


            if (!Directory.Exists(source))
            {
                Directory.CreateDirectory(source);
            }
            if (!Directory.Exists(config))
            {
                Directory.CreateDirectory(config);
            }



            if (!File.Exists($@"{config}\config.txt"))
                File.Create($@"{config}\config.txt").Close();

            if (!File.Exists($@"{config}\log.txt"))
                File.Create($@"{config}\log.txt").Close();
        }
    }
}
