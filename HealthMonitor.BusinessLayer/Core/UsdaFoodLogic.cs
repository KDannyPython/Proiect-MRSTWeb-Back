using System.Text.Json;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Food;

namespace HealthMonitor.BusinessLayer.Core;

public class UsdaFoodLogic: IUsdaFoodLogic
{
    private readonly HttpClient _httpClient;

    private const string ApiKey = "UsOI9NgoEXvuh4tQ1bBND2cNUt9G2vc6WhvYTPre";
    private const string BaseUrl = "https://api.nal.usda.gov/fdc/v1/";

    public UsdaFoodLogic(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UsdaFoodSearchResponseDto> SearchUsdaFoodAsync(string query)
    {
        var url = $"{BaseUrl}foods/search?query={Uri.EscapeDataString(query)}&api_key={ApiKey}";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        var result = new UsdaFoodSearchResponseDto
        {
            TotalHits = root.TryGetProperty("totalHits", out var totalHitsEl)
                    ? totalHitsEl.GetInt32()
                    : 0
        };

        if (root.TryGetProperty("foods", out var foodsEl))
        {
            foreach (var food in foodsEl.EnumerateArray())
            {
                var item = new UsdaFoodItemDto
                {
                    FdcId = food.GetProperty("fdcId").GetInt32(),
                    Description = food.GetProperty("description").GetString() ?? ""
                };
                
                if (food.TryGetProperty("foodNutrients", out var nutrients))
                {
                    foreach (var nutrient in nutrients.EnumerateArray())
                    {
                        var name = nutrient.GetProperty("nutrientName").GetString();
                        var value = nutrient.GetProperty("value").GetDouble();

                        switch (name)
                        {
                            case "Energy":
                                item.Calories = value;
                                break;
                            case "Protein":
                                item.Protein = value;
                                break;
                            case "Carbohydrate, by difference":
                                item.Carbohydrates = value;
                                break;
                            case "Total lipid (fat)":
                                item.Fat = value;
                                break;
                        }
                    }
                }

                result.Foods.Add(item);
            }
        }

        return result;
    }
}