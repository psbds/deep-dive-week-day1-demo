using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeepDiveWeekFunctionVisualStudio.DurableOrchestration
{
	public static class FilterFunction
	{
		[FunctionName("FilterFunction")]
		public static List<string> Filter([ActivityTrigger] ListRequest request, ILogger log)
		{
			log.LogInformation($"Running Filter Function");
			return request.list.Where(x => x.ToLower().Contains(request.filter.ToLower())).ToList();
		}

	}
}
