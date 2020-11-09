using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DeepDiveWeekFunctionVisualStudio
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static void Run(
            [BlobTrigger("images/{name}")]Stream myBlob,
            string name, 
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
