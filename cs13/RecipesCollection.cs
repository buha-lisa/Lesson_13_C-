

namespace cs13
{
    class RecipesCollection
    {
        private List<Recipes> _recipes;

        public RecipesCollection()
        {
            _recipes = new List<Recipes>();
        }

        public void AddRecipe(Recipes recipe)
        {
            _recipes.Add(recipe);
        }
        public void RemoveRecipe(Recipes recipe)
        {
            _recipes.Remove(recipe);
        }

        public void UpdateRecipe(Recipes oldRecipe, Recipes newRecipe)
        {
            int index = _recipes.IndexOf(oldRecipe);
            if (index != -1)
            {
                _recipes[index] = newRecipe;
            }
        }
        public List<Recipes> SearchRecipesByName(string name)
        {
            return _recipes.FindAll(recipe => recipe.Name == name);
        }

        public List<Recipes> SearchRecipesByCuisine(string country)
        {
            return _recipes.FindAll(recipe => recipe.Country == country);
        }

        public List<Recipes> SearchRecipesByIngredient(string ingredient)
        {
            return _recipes.FindAll(recipe => recipe.Ingredients.Contains(ingredient));
        }

        public List<Recipes> SearchRecipesByCookingTime(int cookingTime)
        {
            return _recipes.FindAll(recipe => recipe.TimeForCookInMinuts <= cookingTime);
        }

        public List<Recipes> SearchRecipesByCalories(int calories)
        {
            return _recipes.FindAll(recipe => recipe.Calories <= calories);
        }

        public List<Recipes> SearchRecipesByDishType(string type)
        {
            return _recipes.FindAll(recipe => recipe.DishType == type);
        }

        public void SaveRecipesToFile(string filePath)
        {
            string res = _recipes.ToString();
            File.AppendAllText(filePath, res);
        }
        public void LoadRecipesFromFile(string filePath)
        {
            if (File.Exists(filePath)) 
            {
                var result = File.ReadAllText(filePath);
                Console.WriteLine(result);
            }
        }
    }

}
