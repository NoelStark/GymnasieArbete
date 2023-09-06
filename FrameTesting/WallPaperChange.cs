using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FrameTesting
{
    public static class WallPaperChange
    {
        

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);


        public static void DisplayPicture(string picture, string destination, string type)
        {
            SystemParametersInfo(0x14, 0, picture, 0);
            System.Threading.Thread.Sleep(100);
            FileMove.Move(picture, destination, type);

        }

    }
}
