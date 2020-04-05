using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionV2Example
{
    public class AzureFunctionV2
    {
        private readonly IGreetingsService _greetingsService;

        public AzureFunctionV2(IGreetingsService greetingsService)
        {
            _greetingsService = greetingsService;
        }

        [FunctionName("SayHello")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];

            return !string.IsNullOrWhiteSpace(name)
                ? (ActionResult)new OkObjectResult(_greetingsService.SayHi(name))
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
