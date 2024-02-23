using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppTest.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AnalyzedInstruction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
    }

    public class Equipment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class Ingredient
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class Length
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class RandomRecipeApiData
    {
        [JsonProperty("recipes")]
        public List<Recipe> Recipes { get; set; }
    }

    public class Step
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("step")]
        public string aStep { get; set; }

        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        [JsonProperty("equipment")]
        public List<Equipment> Equipment { get; set; }

        [JsonProperty("length")]
        public Length Length { get; set; }
    }

}
