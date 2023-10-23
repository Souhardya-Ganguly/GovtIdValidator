using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GID
{
    public static class Startup
    {
        [FunctionName("Startup")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string clientName = req.Query["clientName"];
            string panNumber = req.Query["panNumber"];
            string aadharNumber = req.Query["aadharNumber"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            clientName = clientName ?? data?.clientName;
            aadharNumber = aadharNumber ?? data?.aadharNumber;
            panNumber = panNumber ?? data?.panNumber;
            Middle application = new Middle();
            Tuple<string, string> htmlParams = application.checkCredentials(new GovernmentIdValidator(), clientName, panNumber, aadharNumber);
            string responseMessage = htmlParams.Item1;
            string color = htmlParams.Item2;
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;;
            string sFilePath = "C:\\Users\\ASUS\\Desktop\\C# Practice\\GID\\CSV\\resources.csv";
            string clientData = clientName + "," + aadharNumber + "," + panNumber;
            Console.WriteLine(clientData);
            application.fileOps(new FileCreator("Client Name , Aadhar Number , Pan Number"), sFilePath, color, clientData);
            string html = $"<html><head></head><body bgcolor={color}><h1>{responseMessage}</h1></body></html>";

            return new ContentResult()
            {
                Content = html,
                ContentType = "text/html",
                StatusCode = 200
            };
        }
    }
}
