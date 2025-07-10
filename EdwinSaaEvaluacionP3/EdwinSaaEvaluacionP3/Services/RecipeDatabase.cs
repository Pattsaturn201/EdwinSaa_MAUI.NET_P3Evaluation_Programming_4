using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EdwinSaaEvaluacionP3.Models;

namespace EdwinSaaEvaluacionP3.Services
{
    public class RecipeDatabase
    {

        private readonly SQLiteAsyncConnection _database;

        public RecipeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetRecipesAsync() => _database.Table<Recipe>().ToListAsync();

        public Task<int> SaveRecipeAsync(Recipe recipe) => _database.InsertAsync(recipe);


    }
}
