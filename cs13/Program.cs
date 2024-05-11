namespace cs13
{
    internal class Program
    {
        static void Main()
        {
            var ingredients = new List<string> { "Pasta", "Tomato Sauce", "Ground Beef", "Cheese" };
            Recipes lasagnaRecipe = new Recipes()
            {
                Name = "Lasagna",
                Country = "Italian",
                Ingredients = ingredients,
                TimeForCookInMinuts = 60,
                StepByStepDescription = "1. Cook the pasta.\n2. Layer the ingredients in a baking dish.\n3. Bake in the oven.",
                Calories = 134,
                DishType = "Main"
            };

            var carbonaraIngredients = new List<string> { "Spaghetti", "Eggs", "Bacon", "Cheese", "Black Pepper" };
            Recipes carbonaraRecipe = new Recipes()
            {
                Name = "Spaghetti Carbonara",
                Country = "Italian",
                Ingredients = carbonaraIngredients,
                TimeForCookInMinuts = 30,
                StepByStepDescription = "1. Cook spaghetti until al dente.\n2. Fry bacon until crispy.\n3. Whisk eggs and cheese together.\n4. Combine spaghetti, bacon, and egg mixture.\n5. Season with black pepper and serve.",
                Calories = 157,
                DishType = "Main"
            };  

            var collection = new RecipesCollection();
            collection.AddRecipe(lasagnaRecipe);
            collection.AddRecipe(carbonaraRecipe);


            string filePath = "collection.txt";

            while (true)
            {
                Console.Write("Choose number of task(1-3): ");
                int.TryParse(Console.ReadLine(), out int task);
                switch (task)
                {
                    case 1:
                        collection.SaveRecipesToFile(filePath);
                        break;                        
                    case 2:
                        var cuisineGroups = collection.SearchRecipesByCuisine("Italian").Select(x => x.Country);
                        Console.WriteLine("Recipes by Cuisine:");
                        Console.WriteLine($"- {cuisineGroups.Count()} recipes");

                        var orderedTimeRecipes = collection.SearchRecipesByCookingTime(30).Select(x => x.Name);
                        Console.WriteLine("Recipes by Cooking Time:");
                        Console.WriteLine($"- {orderedTimeRecipes.Count()} recipes");

                        var ingredientGroups = collection.SearchRecipesByIngredient("Cheese").Select(x => x.Name);
                        Console.WriteLine("Recipes by Ingredients:");
                        Console.WriteLine($"- {ingredientGroups.Count()} recipes");

                        var orderedRecipes = collection.SearchRecipesByName("Lasagna").Select(x => x.Name);
                        Console.WriteLine("Recipes by Name:");
                        Console.WriteLine($"- {orderedRecipes.Count()} recipes");
                        break;
                    case 3:
                        var caloriesGroups = collection.SearchRecipesByCalories(180).Select(x => x.Name);
                        Console.WriteLine("Recipes by Calories:");
                        Console.WriteLine($"- {caloriesGroups.Count()} recipes");

                        var typeGroup = collection.SearchRecipesByDishType("Main").Select(x => x.Name);
                        Console.WriteLine("Recipes by Dish Type:");
                        Console.WriteLine($"- {typeGroup.Count()} recipes");
                        break;
                }

                if (task == 0) break;
            }





            //var str = new[] { "a", "b", "c", "d" };

            //var fileName = "name.txt";

            //using (var writer = new StreamWriter(fileName, append: true))
            //{
            //    foreach (var item in str)
            //    { 
            //        writer.Write(item);
            //    }
            //}

            //using (var reader = new StreamReader(fileName))
            //{
            //    string line = reader.ReadToEnd();
            //    Console.WriteLine(line);
            //}

            //File.WriteAllText(fileName, "New text");

            //var res = File.ReadAllText(fileName);
            //Console.WriteLine(res);
        }
    }
}
