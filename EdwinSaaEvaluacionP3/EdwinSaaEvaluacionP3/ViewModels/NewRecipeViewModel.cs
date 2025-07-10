using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EdwinSaaEvaluacionP3.Models;
using EdwinSaaEvaluacionP3.Services;
using System.Windows.Input;

namespace EdwinSaaEvaluacionP3.ViewModels
{
    public partial class NewRecipeViewModel : ObservableObject
    {
        private readonly RecipeDatabase _database;

        [ObservableProperty] private string name = string.Empty;
        [ObservableProperty] private string ingredients = string.Empty;
        [ObservableProperty] private int preparationTime;
        [ObservableProperty] private bool isVegetarian;
        [ObservableProperty]

        private int recipeId;

        public async Task LoadRecipeAsync(int id)
        {
            var recipe = await _database.GetRecipeByIdAsync(id);
            if (recipe != null)
            {
                RecipeId = recipe.Id;
                Name = recipe.Name;
                Ingredients = recipe.Ingredients;
                PreparationTime = recipe.PreparationTimeMinutes;
                IsVegetarian = recipe.IsVegetarian;
            }
        }


        public ICommand SaveCommand { get; }

        public NewRecipeViewModel(RecipeDatabase database)
        {
            _database = database;
            SaveCommand = new AsyncRelayCommand(SaveRecipeAsync);
        }

        private async Task SaveRecipeAsync()
        {
            // Validación de la regla de negocio
            if (!isVegetarian && preparationTime > 180)
            {
                await Shell.Current.DisplayAlert(
                    "Validación",
                    "El tiempo de preparación no puede superar 180 minutos para recetas no vegetarianas.",
                    "OK"
                );
                return;
            }

            // Crear y guardar la receta
            var recipe = new Recipe
            {
                Name = name,
                Ingredients = ingredients,
                PreparationTimeMinutes = preparationTime,
                IsVegetarian = isVegetarian
            };

            await _database.SaveRecipeAsync(recipe);

            // Registrar en el log con el formato requerido
            await LogService.AppendLogAsync(name);

            await Shell.Current.DisplayAlert("Éxito", "¡Receta guardada!", "OK");

            // Limpiar los campos del formulario
            name = string.Empty;
            ingredients = string.Empty;
            preparationTime = 0;
            isVegetarian = false;


        }
    }
}
