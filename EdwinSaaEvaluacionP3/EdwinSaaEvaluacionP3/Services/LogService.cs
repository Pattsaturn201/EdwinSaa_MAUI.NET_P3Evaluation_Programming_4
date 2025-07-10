using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwinSaaEvaluacionP3.Services
{
    public class LogService
    {

        public static async Task AppendLogAsync(string recipeName)
        {
            string logFileName = Path.Combine(FileSystem.AppDataDirectory, "Logs_Saa.txt");//para la crecion y registrio de los logs
            string logEntry = $"Se incluyó el registro {recipeName} el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            await File.AppendAllTextAsync(logFileName, logEntry);
        }

        public static async Task<string> ReadLogsAsync()
        {
            string logFileName = Path.Combine(FileSystem.AppDataDirectory, "Logs_Saa.txt");// para la lectura de los logs
            return File.Exists(logFileName) ? await File.ReadAllTextAsync(logFileName) : "No logs found.";
        }

    }
}
