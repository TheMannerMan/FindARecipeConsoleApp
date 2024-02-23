using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppTest.Models
{
    public class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }
    }

    public class SearchwordRecipeApiData
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
    }
}
