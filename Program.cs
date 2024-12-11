using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace StorageCopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process of copy files begun....");
            string connectionString = "AzureConnectionString;Secrets";
            var blobClient = new BlobServiceClient(connectionString);
            string sourceContainer = "first";
            string destinationContainer = "second";
            string sourceFile = "dotnet.png";
            string destinationFile = $"dotnet_{DateTime.UtcNow.ToString("yyyy-MM-dd:hh-MM-ss")}_copy.png";

            var sourceClient = new BlockBlobClient(connectionString, sourceContainer, sourceFile);
			var destinationClient = new BlockBlobClient(connectionString, destinationContainer, destinationFile);

            //var res = destinationClient.StartCopyFromUri(sourceClient.Uri);

            BlobProperties properties = sourceClient.GetProperties();

            Dictionary<string,string> metadata = new Dictionary<string,string>();
            metadata.Add("CreatedBy", "Viktor");
            metadata["environment"] = "development";

            sourceClient.SetMetadata(metadata);

    //        var status = res.UpdateStatus();

    //        if(status.IsError)
    //        {
				//Console.WriteLine($"Process of copy files failed. {status.ReasonPhrase}");
    //            Console.ReadKey();
    //            return;
    //        }
           
			//Console.WriteLine($"Process of copy files finished successfully.... {status.ReasonPhrase}");
            Console.ReadKey();
		}
    }
}
