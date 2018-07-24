
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using HelloAzureFunctions.DTO;
using System;

namespace HelloAzureFunctions
{
    public static class Multiply
    {
        /// <summary>
        /// Example of an Azure function that return an object
        /// </summary>
        /// <returns>A DTO containing the result as an integer and the DateTime of the operation</returns>
        [FunctionName("Multiply")]
        public static IActionResult Run([HttpTrigger(
            AuthorizationLevel.Anonymous,
            "get",
            Route = "mul/num1/{num1}/num2/{num2}")]HttpRequest req, int num1, int num2, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var result = new ResultNumber()
            {
                Result = num1 * num2,
                CreatedDate = DateTime.Now
            };

            return new OkObjectResult(result);
        }
    }
}
