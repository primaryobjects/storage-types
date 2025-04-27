using Microsoft.AspNetCore.Components;
using StorageDemo.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StorageDemo.Components.Pages
{
    public partial class Structured_Data
    {
        private List<string> Columns { get; set; } = new();
        private List<List<object?>> Rows { get; set; } = new();
        private List<string> TableNames { get; set; } = new();

        private int CurrentPage { get; set; } = 1;
        private int PageSize { get; set; } = 10;
        private int TotalPages => (int)System.Math.Ceiling((double)Rows.Count / PageSize);

        private List<List<object?>> PagedRows => Rows
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        [Inject]
        private StructuredDataService? DataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Fetch table names
            if (DataService != null)
            {
                TableNames = await DataService.GetTableNamesAsync();

                // Fetch data from the first table (if any)
                if (TableNames.Count != 0)
                {
                    var dataTable = await DataService.GetDataAsync();
                    if (dataTable != null)
                    {
                        Columns = [.. dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName)];
                        Rows = [.. dataTable.Rows.Cast<DataRow>().Select(row => row.ItemArray.ToList())];
                    }
                }
            }
        }

        private void GoToPreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        private void GoToNextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
            }
        }
    }
}