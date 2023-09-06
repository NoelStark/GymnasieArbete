using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FrameTesting
{
    class FileRead
    {
        /*
        public static void AddFileSecurity(string fileName, string account,
           FileSystemRights rights, AccessControlType controlType)
        {
            // Get a FileSecurity object that represents the current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));
            File.SetAccessControl(fileName, fSecurity);
        }

        public static void RemoveFileSecurity(string fileName, string account,
         FileSystemRights rights, AccessControlType controlType)
        {
            // Get a FileSecurity object that represents the current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Remove the FileSystemAccessRule from the security settings.
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
                rights, controlType));
            File.SetAccessControl(fileName, fSecurity);
        }
        */


        public static void Read(string type, string file)
        {
            /*
            var domain = WindowsIdentity.GetCurrent().Name;
            string fileName = $@"C:\Mappar\README.txt";
            Console.WriteLine(domain);
            Console.ReadLine();
            AddFileSecurity(fileName, domain, FileSystemRights.ReadData, AccessControlType.Deny);
  
            Console.WriteLine("Done");
            Console.ReadLine();


            RemoveFileSecurity(fileName, domain, FileSystemRights.ReadData, AccessControlType.Deny);
            Console.WriteLine("Done.");
            */

            //Variables for the class
            string path = @"C:\Mappar\config\config.txt";
            string[] readfile = File.ReadAllLines(path);
            string[] str = new string[readfile.Length];
            string[] extension = new string[readfile.Length];
            
            char[] splitOn = { ';' };
            bool exists = false;
            string destination = "";
            int k = 0;
            
            for(int j = 0; j < readfile.Length; j++) //iterates through the entire file
            {
                string ext = readfile[j].Split(splitOn)[1]; //ex gets the *.{extension} of every row in the text file
                
                ext = ext.Remove(0, 2); //Removes the space and * from extension
                str[j] = ext; //the arrays item gets the value of ex
                
            }
            
            if (str.Contains(type)) exists = true; //if the extension of the file in the folder 'Mappar' exists in the textfile 'config.txt', exists is true
            
            if(exists == true) //If the extension exists and is valid
            {

            
            for(int i = 0; i < readfile.Length; i++) //once again iterates through the entire file
            {
                    
                    string fileType = readfile[k].Split(splitOn)[1];
                    fileType = fileType.Remove(0, 2);
                    string active = readfile[i].Split(splitOn)[2]; //looks through the third item that is either active, inactive or denied
                    active = active.Remove(0, 1); //removes the white space
                    if(fileType == type)
                    {
                        if (active == "active") //if the file type is 'active' then the program will continue
                        {
                            destination = readfile[i].Split(splitOn)[3];
                            extension[i] = destination;
                            if(type.ToLower() == ".jpg")
                            {
                                WallPaperChange.DisplayPicture(file, extension[i], type);
                                
                            }
                            else
                            {
                                FileMove.Move(file, extension[i], type);
                                break;
                            }
                            

                            k = 0;
                        }
                        else if (active == "denied") //if its denied then the file will get deleted
                        {
                            errorlog.log("This file: {" + file.ToString() + "} has been denied and will be deleted");
                            File.Delete($@"C:\Mappar\{file}");
                        }
                    }
                    else
                    {
                        
                        k++;
                    }
                          
               
                }
            }
            else //if the extension isn't valid then you will get an error message
            {

                errorlog.log("This file type: {" + type.ToString() + "} does not exist or format is wrong in config.txt");
            }






            /*
            string source = DirectoryCreate.source;
            string[] filePath;
            string destination;




            if (new FileInfo($@"{source}\README.txt").Length == 0)
            {
                File.AppendAllText($@"{source}\README.txt", @"C:\Mappar");
            }
            filePath = File.ReadAllLines($@"{source}\README.txt");
            destination = filePath[0];

            DirectoryInfo start = new DirectoryInfo(source);
            DirectoryInfo stop = new DirectoryInfo(destination);



            Console.WriteLine("Finished");
            Console.ReadLine();
            foreach (var item in start.GetFiles())
            {
                if (item.Name.ToLower() != "readme.txt")
                {
                    item.CopyTo(Path.Combine(stop.ToString(), item.Name), true);
                    item.Delete();

                }
            }
            */
        }

    }
}
