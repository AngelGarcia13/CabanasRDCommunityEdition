using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CabanasRD.Framework.APIs.Models
{
    public partial class MotelResponse
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
        public List<MotelResponseService> MotelServices { get; set; }

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

    public partial class MotelResponseService
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
