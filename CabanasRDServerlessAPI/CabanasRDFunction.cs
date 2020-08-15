using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CabanasRDServerlessAPI
{
    public static class CabanasRDFunction
    {
        [FunctionName("CabanasRDFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "cabanas")] HttpRequest req,
            [CosmosDB(
                databaseName: "cabanasdb",
                collectionName: "cabanascollection",
                ConnectionStringSetting = "CosmosDBConnection",
                SqlQuery = "SELECT * FROM c")] IEnumerable<Motel> items,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(items);
        }
    }

    public partial class Motel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("motelServices")]
        public List<MotelService> MotelServices { get; set; }

        [JsonProperty("phones")]
        public List<string> Phones { get; set; }

        [JsonProperty("takeCredictCards")]
        public bool TakeCredictCards { get; set; }

        [JsonProperty("ranking")]
        public int Ranking { get; set; }

        [JsonProperty("images")]
        public List<Uri> Images { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("descripcion")]
        public object Descripcion { get; set; }

        [JsonProperty("creditCards")]
        public List<object> CreditCards { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("isManagedByTheOwner")]
        public bool IsManagedByTheOwner { get; set; }

        [JsonProperty("rankingValue")]
        public double RankingValue { get; set; }

    }

    public partial class MotelService
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("currencyType")]
        public int CurrencyType { get; set; }

        [JsonProperty("descriptionDetail")]
        public object DescriptionDetail { get; set; }
    }

    public partial class State
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
