
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace HelloAzureFunctions
{
    public static class Subtract
    {
        /// <summary>
        /// Example of an Azure function that takes two parameters specified in the URL (/num1/5/num2/3)
        /// </summary>
        /// <returns>The result of the substraction of two numbers as an integer</returns>
        [FunctionName("Subtract")]
        public static IActionResult Run([HttpTrigger(
            AuthorizationLevel.Anonymous, 
            "get",
            Route = "sub/num1/{num1}/num2/{num2}")]HttpRequest req, int num1, int num2, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            return new OkObjectResult(num1 - num2);
        }
    }
}
