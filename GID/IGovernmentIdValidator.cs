using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GID
{
    public interface IGovernmentIdValidator
    {
        Tuple<string, string> Validate(string clientName, string panNumber, string aadharNumber);
    }
}
