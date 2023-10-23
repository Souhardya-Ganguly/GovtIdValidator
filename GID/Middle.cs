using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GID
{
    public class Middle

    {
        private IFileCreator _filecreator;
        private IGovernmentIdValidator _validator;
        public Tuple<string,string> checkCredentials(IGovernmentIdValidator validator, string clientName, string panNumber, string aadharNumber) { 
        this._validator = validator;
            return this._validator.Validate(clientName,panNumber,aadharNumber);
        }
        public void fileOps(IFileCreator filecreator, string path,string statusColor, string clientData) { 
        this._filecreator = filecreator;
            if (statusColor.Equals("green", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!this._filecreator.checkExistence(path))
                    this._filecreator.createFile(path);
                this._filecreator.appendData(path, clientData);
            }
            else {
                this._filecreator.appendData(path, clientData);
            }
        }
    }
}
