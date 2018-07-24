
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace HelloAzureFunctions
{
    public static class Add
    {
        /// <summary>
        /// Example of an Azure function that takes two parameters not specified in the URL (?num1=1&num2=2)
        /// </summary>
        /// <returns>The result of the addition of two number as an integer</returns>
        [FunctionName("Add")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string param1 = req.Query["num1"];
            string param2 = req.Query["num2"];

            if(!string.IsNullOrEmpty(param1) && !string.IsNullOrEmpty(param2))
            {
                var num1 = int.Parse(param1);
                var num2 = int.Parse(param2);
                return new OkObjectResult(num1+num2);
            }

            return new BadRequestObjectResult("Please pass as a parameter on the query num1 and num2");
        }
    }
}
