using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StorageDemo.Components.Pages
{
    public partial class Unstructured_Data
    {
        private class DatabaseJson
        {
            [JsonPropertyName("images")]
            public required List<ImageData> Images { get; set; }
        }

        private class ImageData
        {
            [JsonPropertyName("filename")]
            public required string FileName { get; set; }

            [JsonPropertyName("filepath")]
            public required string FilePath { get; set; }

            [JsonPropertyName("filesize")]
            public int FileSize { get; set; }
        }

        private Dictionary<string, string> Images { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Components", "Data", "database.json");

            if (File.Exists(jsonFilePath))
            {
                var jsonData = await File.ReadAllTextAsync(jsonFilePath);
                var imageData = JsonSerializer.Deserialize<DatabaseJson>(jsonData);

                if (imageData?.Images != null)
                {
                    Images = new Dictionary<string, string>();
                    foreach (var image in imageData.Images)
                    {
                        Images[image.FileName] = image.FilePath;
                    }
                }
            }
        }
    }
}