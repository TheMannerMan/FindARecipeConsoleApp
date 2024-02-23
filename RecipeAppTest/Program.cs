using RecipeAppTest.Models;
using RecipeAppTest.ReceipeService;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

RecipeService service = new RecipeService();


Console.WriteLine("Welcome to this simple recipe app.");
MainMenu();
void MainMenu()
{
    Console.Title = "Main Menu";

    // Main menu loop
    while (true)
    {
        Console.WriteLine("=================");
        Console.WriteLine("Main menu -  Please make a choice bellow.");
        Console.WriteLine("=================");
        Console.WriteLine("1 - Find recipes by a searchword");
        Console.WriteLine("2 - Find recipes by ingredient");
        Console.WriteLine("3 - Get a random recipe");
        Console.WriteLine("4 - Exit program");
        Console.WriteLine("=================");


        string userChoice = Console.ReadLine();
        switch (userChoice)
        {
            case "1":
                Console.WriteLine("Searchword");
                SearchBySearchword(service);
                break;
            case "2":
                SearchByIngredients(service);
                break;
            case "3":
                SearchRandomRecipe(service);
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}

void SearchBySearchword(RecipeService service)
{
    Console.WriteLine();
    Console.Write("Enter a searchword: ");
    string searchword = Console.ReadLine();

    Exception exception = null;
    Task<Recipe[]> recipeTask = null;
    
    try
    {
        recipeTask = service.SearchRecipesBySearchwordAsync(searchword);
        Task.WaitAll(recipeTask);
    }

    catch (Exception ex)
    {
        exception = ex;
        Console.WriteLine($"Error: {ex.Message}");
        // TODO: HOW TO HANDLE EXCEPTION. Titta på min inlämning.
    }

    if (recipeTask != null && recipeTask.Status == TaskStatus.RanToCompletion)
    {
        var recipes = recipeTask.Result;
        Console.WriteLine("Found recipes:");
        Console.WriteLine();
        ChooseAReceipe(recipes);
    }

    //TODO: HANTERA VAL AV INGREDIENSER
    PressAKeyToContinue();


}

void SearchByIngredients(RecipeService service)
{
    Exception exception = null;
    Task<Recipe[]> recipeTask = null;
    string searchedIngredients = GetIngredients();

    try
    {
        recipeTask = service.SearchRecipesByIngredientsAsync(searchedIngredients);
        Task.WaitAll(recipeTask);
    }

    catch (Exception ex)
    {
        exception = ex;
        Console.WriteLine($"Error: {ex.Message}");
        // TODO: HOW TO HANDLE EXCEPTION. Titta på min inlämning.
    }

    if (recipeTask != null && recipeTask.Status == TaskStatus.RanToCompletion)
    {
        var recipes = recipeTask.Result;
        Console.WriteLine("Found recipes:");
        Console.WriteLine();
        ChooseAReceipe(recipes);
    }

    //TODO: HANTERA VAL AV INGREDIENSER
    PressAKeyToContinue();
}

void SearchRandomRecipe(RecipeService service)
{
    Exception exception = null;
    Task<Recipe> randomRecipeTask = null;
   
    try
    {
        randomRecipeTask = service.SearchRandomRecipe();
        Task.WaitAll(randomRecipeTask);
    }

    catch (Exception ex)
    {
        exception = ex;
        Console.WriteLine($"Error: {ex.Message}");
        // TODO: HOW TO HANDLE EXCEPTION. Titta på min inlämning.
    }

    if (randomRecipeTask != null && randomRecipeTask.Status == TaskStatus.RanToCompletion)
    {
        var loadedRandomRecipe = randomRecipeTask.Result;
        DisplayRecipe(loadedRandomRecipe);
    }
}

void SearchByID(IRecipe recipe)
{
    Exception exception = null;
    Task<DetailedRecipeApiData> detailedRecipeTask = null;
    int recipeID = recipe.Id;
    IRecipe choosenRecipe = recipe;

    try
    {
        detailedRecipeTask = service.SearchSpecificRecipeAsync(recipeID);
        Task.WaitAll(detailedRecipeTask);
    }
    catch (Exception ex)
    {
        exception = ex;
        Console.WriteLine($"Error: {ex.Message}");
    }

    if (detailedRecipeTask != null && detailedRecipeTask.Status == TaskStatus.RanToCompletion)
    {
        var loadedRecipe = detailedRecipeTask.Result;

        DisplayRecipe(loadedRecipe);
    }

}

void DisplayRecipe(IRecipe loadedRecipe)
{
    Console.Clear();
    Console.WriteLine(loadedRecipe.Title.ToUpper());
    Console.WriteLine();
    Console.WriteLine(RemoveHtmlTags(loadedRecipe.Summary));
    Console.WriteLine();

    foreach (var ingredient in loadedRecipe.ExtendedIngredients)
    {
        Console.WriteLine($"Ingredient: {ingredient.Name} Amount: {ingredient.Measures.Metric.Amount} {ingredient.Measures.Metric.UnitShort}");
    }
    Console.WriteLine();
    Console.WriteLine("Instuctions " + RemoveHtmlTags(loadedRecipe.Instructions));
    Console.WriteLine();
    Console.WriteLine("If instructions isn't displayed. Please visit the following page for instructions:");
    Console.WriteLine(loadedRecipe.SourceUrl);

    Console.WriteLine();
    PressAKeyToContinue();
}

void ChooseAReceipe(IRecipe[] recipes)
{

    int order = 1;
    foreach (var recipe in recipes)
    {
        Console.WriteLine($"{order}: {recipe.Title}");
        order++;
    }

    while (true)
    {
        Console.WriteLine("Choose a recipe (enter the number) or press ESC to go back to the main menu.");

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
        }

        Console.Write("Enter the recipe number: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= recipes.Length)
        {
            SearchByID(recipes[choice - 1]);
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}

string GetIngredients()
{
    string ingredients = "";
    Console.Write("Please enter a ingredient (ex. chicken): ");
    ingredients += Console.ReadLine();
    bool isRunning = true;
    while (isRunning)
    {
        Console.WriteLine();
        Console.WriteLine($"Ingredients: {ingredients}");
        Console.Write("Please enter another ingredient or press \"ESC\" to continue: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            isRunning = false;// Indicate cancellation by returning null
            break;
        }
        else
        {
            ingredients += $",{Console.ReadLine()}";
        }

    }
    return ingredients;

}

static string RemoveHtmlTags(string input)
{
    return Regex.Replace(input, "<.*?>", string.Empty);
}

static void PressAKeyToContinue()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Please press a key to continue.");
    Console.ResetColor(); // Reset the color to the default
    Console.ReadKey();
    Console.Clear();
}