using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GID
{
    public class GovernmentIdValidator : IGovernmentIdValidator
    {
        public Tuple<string, string> Validate(string clientName, string panNumber, string aadharNumber)
        {
            string responseMessage = "Something went wrong"; // Default message

            string strRegexAadhar = @"^[2-9]{1}[0-9]{3}\s[0-9]{4}\s[0-9]{4}$";
            string strRegexPan = @"[A-Z]{5}[0-9]{4}[A-Z]{1}$";
            Regex reAadhar = new Regex(strRegexAadhar);
            Regex rePan = new Regex(strRegexPan);
            string color = "Blue";
            if (string.IsNullOrEmpty(panNumber) || string.IsNullOrEmpty(aadharNumber))
            {
                responseMessage = "This HTTP Trigger app compiled successfully";
            }
            else
            {
                if (reAadhar.IsMatch(aadharNumber) && rePan.IsMatch(panNumber))
                {
                    responseMessage = $"Hello {clientName}, your Aadhar number: {aadharNumber} and Pan number: {panNumber} are both valid";
                    color = "green";
                }
                else if (reAadhar.IsMatch(aadharNumber) && !rePan.IsMatch(panNumber))
                {
                    responseMessage = $"Hello {clientName}, your Aadhar number: {aadharNumber} is valid but your Pan number: {panNumber} is not valid";
                    color = "teal";
                }
                else if (!reAadhar.IsMatch(aadharNumber) && rePan.IsMatch(panNumber))
                {
                    responseMessage = $"Hello {clientName}, your Aadhar number: {aadharNumber} is not valid but your Pan number: {panNumber} is valid";
                    color = "teal";
                }
                else
                {
                    responseMessage = $"Hello {clientName}, NEITHER your Aadhar number: {aadharNumber} is NOR your Pan number: {panNumber} is valid";
                    color = "red";
                }
            }
            Tuple<string, string> t = new Tuple<string, string>(responseMessage, color);
            return t;
        }
    }
}
