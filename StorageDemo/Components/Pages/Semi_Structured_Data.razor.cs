using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace StorageDemo.Components.Pages
{
    public partial class Semi_Structured_Data
    {
    private string JsonData = string.Empty;
        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            GenerateJson();
        }

        private void GenerateJson()
        {
            // Define the directory to scan
            string imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            // Check if the directory exists
            if (!Directory.Exists(imagesDirectory))
            {
                JsonData = $"Error: Directory not found: {imagesDirectory}";
                StateHasChanged();
                return;
            }

            // Get all .png files in the directory
            var pngFiles = Directory.GetFiles(imagesDirectory, "*.png");

            // Generate JSON data
            var jsonData = pngFiles.Select((filePath, index) => new
            {
                id = index + 1,
                filename = Path.GetFileName(filePath),
                filepath = $"/images/{Path.GetFileName(filePath)}",
                filesize = new FileInfo(filePath).Length
            }).ToArray();

            // Serialize to JSON
            JsonData = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });

            // Refresh the UI
            StateHasChanged();

            // Call JavaScript to initialize CodeMirror
            JSRuntime.InvokeVoidAsync("initializeCodeMirror");
        }
    }
}