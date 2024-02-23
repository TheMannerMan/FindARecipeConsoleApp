using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppTest.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class MissedIngredient
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("unitLong")]
        public string UnitLong { get; set; }

        [JsonProperty("unitShort")]
        public string UnitShort { get; set; }

        [JsonProperty("aisle")]
        public string Aisle { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }

        [JsonProperty("meta")]
        public List<string> Meta { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("extendedName")]
        public string ExtendedName { get; set; }
    }

    public class RecipeApiData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("usedIngredientCount")]
        public int UsedIngredientCount { get; set; }

        [JsonProperty("missedIngredientCount")]
        public int MissedIngredientCount { get; set; }

        [JsonProperty("missedIngredients")]
        public List<MissedIngredient> MissedIngredients { get; set; }

        [JsonProperty("usedIngredients")]
        public List<UsedIngredient> UsedIngredients { get; set; }

        [JsonProperty("unusedIngredients")]
        public List<object> UnusedIngredients { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }
    }

    public class UsedIngredient
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("unitLong")]
        public string UnitLong { get; set; }

        [JsonProperty("unitShort")]
        public string UnitShort { get; set; }

        [JsonProperty("aisle")]
        public string Aisle { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }

        [JsonProperty("meta")]
        public List<string> Meta { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("extendedName")]
        public string ExtendedName { get; set; }
    }


}
