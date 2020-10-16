using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskSchedulerDataHandler.Services.Utility
{
    internal class JSONDataProvider : IDataProvider
    {
        private string _pathToFile;
        public string PathToFile => _pathToFile;


        public JSONDataProvider(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public object LoadData()
        {
            if (File.Exists(PathToFile))
            {
                string jsonString = File.ReadAllText(PathToFile);
                object data = JsonSerializer.Deserialize<object>(jsonString);
                return data;
            }
            return null;
        }

        public void SaveData(object data)
        {
            string jsonString = JsonSerializer.Serialize<object>(data);
            if (File.Exists(PathToFile))
            {
                File.Copy(PathToFile, $"{PathToFile}_old");
            }
            File.WriteAllText(PathToFile, jsonString);
        }
    }
}
