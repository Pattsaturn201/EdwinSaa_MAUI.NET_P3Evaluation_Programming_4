using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EdwinSaaEvaluacionP3.Models;
using EdwinSaaEvaluacionP3.Services;
using System.Collections.ObjectModel;

namespace EdwinSaaEvaluacionP3.ViewModels
{
    public partial class RecipeListViewModel : ObservableObject
    {
        private readonly RecipeDatabase _database;

        public ObservableCollection<Recipe> Recipes { get; } = new();

        public RecipeListViewModel(RecipeDatabase database)
        {
            _database = database;
            LoadRecipes();
        }

        [RelayCommand]
        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            if (recipe == null) return;

            bool confirm = await Shell.Current.DisplayAlert("Delete", $"Delete {recipe.Name}?", "Yes", "No");
            if (confirm)
            {
                await _database.DeleteRecipeAsync(recipe);
                Recipes.Remove(recipe);
            }
        }

        public async void LoadRecipes()
        {
            Recipes.Clear();
            var recipes = await _database.GetRecipesAsync();
            foreach (var recipe in recipes)
                Recipes.Add(recipe);
        }
    }
}
