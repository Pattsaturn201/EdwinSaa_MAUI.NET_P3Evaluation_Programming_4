// ViewModels/LogsViewModel.cs
using CommunityToolkit.Mvvm.ComponentModel;
using EdwinSaaEvaluacionP3.Services;

namespace RecipeApp.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty] private string logs;

        public LogsViewModel()
        {
            LoadLogs();
        }

        private async void LoadLogs()
        {
            logs = await LogService.ReadLogsAsync();
        }
    }
}
