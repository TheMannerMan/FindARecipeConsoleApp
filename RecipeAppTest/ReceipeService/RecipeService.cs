using RecipeAppTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppTest.ReceipeService
{
    public class RecipeService
    {
        HttpClient httpClient = new HttpClient();

        // API-Key
        readonly string apiKey = "0dea074b09e14c9b83497449757e6260";

        public async Task<Recipe[]> SearchRecipesBySearchwordAsync(string searchword)
        {
            var uri = $"https://api.spoonacular.com/recipes/complexSearch?query={searchword}&apiKey={apiKey}&number=5&ignorePantry=true&sort=popularity";
            Recipe[] recipes = await ReadWebApiSearchwordAsync(uri);
            return recipes;
        }

        public async Task<Recipe[]> SearchRecipesByIngredientsAsync(string ingredients)
        {
            var uri = $"https://api.spoonacular.com/recipes/findByIngredients?apiKey={apiKey}&number=5&ignorePantry=true&ranking=2&ingredients={ingredients}"; //TODO: undersök vilken ranking som passar bäst.

            Recipe[] recipes = await ReadWebApiAsync(uri);

            // Framtida funktion: Spara i cache

            return recipes;
        }

        private async Task<Recipe[]> ReadWebApiAsync(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            RecipeApiData[] rd = await response.Content.ReadFromJsonAsync<RecipeApiData[]>();
            
            List<Recipe> result = new List<Recipe>();

            foreach (RecipeApiData recipeApiData in rd)
            {
                Recipe recipe = new Recipe()
                {
                    Id = recipeApiData.Id,
                    Title = recipeApiData.Title,
                };
                result.Add(recipe);
            }
            

            return result.ToArray();
        }

        private async Task<Recipe[]> ReadWebApiSearchwordAsync(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            SearchwordRecipeApiData rd = await response.Content.ReadFromJsonAsync<SearchwordRecipeApiData>(); // ändra denna

            List<Recipe> result = new List<Recipe>();

            foreach (var recipes in rd.Results)
            {
                Recipe recipe = new Recipe()
                {
                    Id = recipes.Id,
                    Title = recipes.Title,
                };
                result.Add(recipe);
            }

            return result.ToArray();
        }


        public async Task<DetailedRecipeApiData> SearchSpecificRecipeAsync(int id)
        {
            var uri = $"https://api.spoonacular.com/recipes/{id}/information?apiKey={apiKey}&includeNutrition=false";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            DetailedRecipeApiData detailedRecipe = await response.Content.ReadFromJsonAsync<DetailedRecipeApiData>();
            return detailedRecipe;
        }

        public async Task<Recipe> SearchRandomRecipe()
        {
            int numberOfRandomRecipiesToSearch = 1;
            var uri = $"https://api.spoonacular.com/recipes/random?apiKey={apiKey}&number={numberOfRandomRecipiesToSearch}&limitLicense=true";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            RandomRecipeApiData randomRecipes = await response.Content.ReadFromJsonAsync<RandomRecipeApiData>();

            return randomRecipes.Recipes[0];

        }
    }
}
