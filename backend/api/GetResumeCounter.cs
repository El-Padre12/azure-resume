using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;



namespace Company.Function
{
    public class GetResumeCounter
    {
       

        [Function("GetResumeCounter")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,

                                 [CosmosDBInput(databaseName:"AzureResume",
                                                containerName:"Counter",
                                                Connection = "AzureResumeConnectionString",
                                                Id = "1",
                                                PartitionKey = "1")]Counter counter
                                //  [CosmosDBOutput(databaseName:"AzureResume",
                                //                 containerName:"Counter",
                                //                 Connection = "AzureResumeConnectionString",
                                //                 PartitionKey = "1")]Counter updatedCounter
                                ) 
        {
            counter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) 
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
