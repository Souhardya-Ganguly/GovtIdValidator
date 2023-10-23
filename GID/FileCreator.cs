using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GID
{
    public class FileCreator:IFileCreator
    {
        string fileHeader;
        public FileCreator(string fileHeader)
        {
            this.fileHeader = fileHeader;
        }

        public bool checkExistence(string path) { 
            return File.Exists(path);
        }

        public void createFile(string path) { 
        File.WriteAllText(path, fileHeader);
            Console.WriteLine("File Exists");
        }
        public void deleteFile(string path)
        {
            File.Delete(path);
        }
        public void appendData(string path, string clientDetails)
        {
            File.AppendAllText(path, clientDetails);
            Console.WriteLine("Data Added");
        }
    }
}
