using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static RealtyWeb_Client.Pages.Weather;

namespace RealtyWeb_Client.Pages.LearnBlazor
{
    partial class FetchDataPart
    {
        [Inject]
        HttpClient Http { get; set; } = null!;
        private WeatherForecast[]? forecasts;
        
        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
