using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppTest.Models
{
    public interface IRecipe
    {
        string Title { get; set; }
        string Summary { get; set; }

        int Id { get; set; }
        List<ExtendedIngredient> ExtendedIngredients { get; set; }
        string SourceUrl { get; set; }

        string Instructions { get; set; }
    }
}
