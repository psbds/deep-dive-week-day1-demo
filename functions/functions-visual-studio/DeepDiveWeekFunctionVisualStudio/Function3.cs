using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DeepDiveWeekFunctionVisualStudio
{
	public static class Function3
	{
		[FunctionName("Function3")]
		public static async Task Run(
			[BlobTrigger("images/{name}")]Stream myBlob,
			[Blob("thumbnail", FileAccess.Write)] CloudBlobContainer thumbnail,
			string name,
			ILogger log)
		{
			log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");


			using (MemoryStream ms = new MemoryStream())
			{
				myBlob.Position = 0;
				var result = ResizeImage(myBlob, new Size(100, 100));

				result.Save(ms, ImageFormat.Jpeg);
				var blockBlob = thumbnail.GetBlockBlobReference(name);
				ms.Position = 0;
				await blockBlob.UploadFromStreamAsync(ms);
			}

		}

		public static Image ResizeImage(Stream stream, Size size)
		{
			return (Image)(new Bitmap(new Bitmap(stream), size));
		}
	}
}
