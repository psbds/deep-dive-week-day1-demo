using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DeepDiveWeekFunctionVisualStudio
{
	public static class DurableFunction
	{
		[FunctionName("DurableFunction_HttpStart")]
		public static async Task<HttpResponseMessage> HttpStart(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
			[DurableClient] IDurableOrchestrationClient starter,
			ILogger log)
		{
			var body = JsonConvert.DeserializeObject<ListRequest>(req.Content.ReadAsStringAsync().Result);

			string instanceId = await starter.StartNewAsync("DurableFunction", Guid.NewGuid().ToString(), body);

			log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
			return await starter.WaitForCompletionOrCreateCheckStatusResponseAsync(req, instanceId);
			//return starter.CreateCheckStatusResponse(req, instanceId);
		}

		[FunctionName("DurableFunction")]
		public static async Task<List<string>> RunOrchestrator(
			[OrchestrationTrigger] IDurableOrchestrationContext context)
		{
			var input = context.GetInput<ListRequest>();

			input.list = await context.CallActivityAsync<List<string>>("SortFunction", input.list);
			input.list = await context.CallActivityAsync<List<string>>("FilterFunction", input);

			return input.list;
		}


	}
}