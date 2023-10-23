using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GID
{
    public interface IFileCreator
    {
        
        public bool checkExistence(string path);
        public void createFile(string path);
        public void deleteFile(string path);

        public void appendData(string path, string clientDetails);
    }
}
