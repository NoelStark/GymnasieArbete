using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameTesting
{
    class FileMove
    {
        public static void Move(string file, string destination, string extension)
        {
            var newPath = Path.Combine(destination, Path.GetFileName(file));

            if (!File.Exists(newPath))
            {

            
            if(File.Exists(file)) File.Move(file, newPath);
            }
            else
            {
                var changePath = newPath.Replace(extension, "_copy" + extension);

                while (File.Exists(changePath))
                {
                    changePath = changePath.Replace(extension, "_copy" + extension);
                }

                   if(File.Exists(file)) File.Move(file, changePath);
                

            }

        }


    }
}
