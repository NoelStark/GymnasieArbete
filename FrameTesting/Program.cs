using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;

namespace FrameTesting
{
    class Program
    {
        static void mail()
        {
            try
            {

            
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("noel.stark17@gmail.com");
                mail.To.Add("noel.k.stark@gmail.com");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("stark.noel17@gmail.com", "Noel123456789$");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void Main()
        {
            
            
            string path = @"C:\Mappar\config\config.txt"; //Path to the files

            string[] readfile = File.ReadAllLines(path);
                string[] pth = new string[readfile.Length];
            for (int j = 0; j < readfile.Length; j++)
            {
                string[] pathToInput = readfile[j].Split(';');
                pth[j] = pathToInput[0];


            //mail();
            //DirectoryCreate.Create();
            string[] dir = Directory.GetFiles($@"{pth[j]}");

            DirectoryInfo files = new DirectoryInfo(pth[j]); //gathers information from the directory 
                var file = files.GetFiles();
            for(int i = 0; i < dir.Length; i++)//iterates through all the files
            {


                var extension = Path.GetExtension(file[i].ToString().ToLower()); //gathers the extension of the file
                FileRead.Read(extension, dir[i]);//goes to the class 'FileRead' where 'extension' contains extension and 'item' contains the file

              
            }
            
            }

        }
        /*
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);


        public static void DisplayPicture(string picture)
        {
            SystemParametersInfo(0x14, 0, picture, 0);
        }




        static void comment()
        {
            //string destination = @"C:\Mappar\output";
            //var files = Directory.GetFiles(path, "*jpg"); //gathers all .JPG files(images)
            //var files = Directory.GetFiles(path);

            /*
           foreach (var item in files)
           {
               string[] image = item.Split('\\');

               //var resultat = Path.ChangeExtension(item, ".JPG"); //changes the extension of the file to .JPG since the Registry uses .JPG
               DisplayPicture($@"C:\Mappar\{image[2]}");


               System.Threading.Thread.Sleep(1000);
               var oldImages = Path.Combine($@"{path}\old images", Path.GetFileName(image[3]));
               File.Move(item, oldImages);
           }
          
        }
    */
    }
}

