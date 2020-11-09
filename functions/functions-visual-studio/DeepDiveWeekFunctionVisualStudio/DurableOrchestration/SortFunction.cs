using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepDiveWeekFunctionVisualStudio.DurableOrchestration
{
	public static class SortFunction
	{
		[FunctionName("SortFunction")]
		public static List<string> Sort([ActivityTrigger] List<string> list, ILogger log)
		{
			log.LogInformation($"Running Sort Function");
			list.Sort();
			return list;
		}

	}
}
