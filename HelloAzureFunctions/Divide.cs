
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
    public static class Divide
    {
        /// <summary>
        /// Example of a POST Azure function that takes a DTO in the body.
        /// </summary>
        /// <returns>A DTO containing the result as an integer and the DateTime of the operation</returns>
        [FunctionName("Divide")]
        public static IActionResult Run([HttpTrigger(
            AuthorizationLevel.Anonymous, 
            "post", 
            Route = "div")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var azureNumbers = JsonConvert.DeserializeObject<Numbers>(requestBody);

            if (azureNumbers.Num2 == 0) return new BadRequestObjectResult("Divide by 0 not possible");

            var result = new ResultNumber()
            {
                Result = azureNumbers.Num1 / azureNumbers.Num2,
                CreatedDate = DateTime.Now
            };

            return new OkObjectResult(result);
        }
    }
}
