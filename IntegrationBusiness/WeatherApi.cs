using IntegrationDtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IntegrationBusiness;

public class WeatherApi
{
    private readonly WeatherOptions _options;

    public WeatherApi(IOptions<WeatherOptions> options)
    {
        _options = options.Value;
    }

    public async Task<Response<WeatherResponse>> GetCurrentWeather(WeatherDto dto)
    {
        using HttpClient client = new()
        {
            BaseAddress = new Uri(_options.BaseAddress),
        };

        string requestUri = $"appId={_options.AppId}&units={dto.Units}&q={dto.Query}";
        var response = await client.GetAsync("/data/2.5/weather?" + requestUri);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            try
            {
                var info = JsonConvert.DeserializeObject<WeatherResponse>(data);
                return new SuccessResponse<WeatherResponse>("Weather data retrieved successfully")
                {
                    Data = info
                };
            }
            catch (Exception)
            {
                return new ErrorResponse<WeatherResponse>("Failed to parse weather data.");
            }
        }

        return new ErrorResponse<WeatherResponse>("Failed to fetch weather data from API.");
    }
}