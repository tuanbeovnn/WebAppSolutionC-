using System.Net;
using System.Text.Json.Serialization;
using IntegrationDtos;
using IntegrationModels;
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

    public async Task<Response<WeatherInfo>> GetCurrentWeather(WeatherDto dto)
    {
        //FluentValidation 
        //Call API + Named Client
        HttpClient client = new HttpClient()
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
                var info = JsonConvert.DeserializeObject<WeatherInfo>(data);
                return new SuccessResponse<WeatherInfo>()
                {
                    Message = "",
                    Data = info,
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        return new Response<WeatherInfo>()
        {
            Success = false,
            Message = ""
        };
    }
}