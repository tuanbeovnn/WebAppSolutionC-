using IntegrationDtos;
using IntegrationModels;

namespace IntegrationBusiness;

public class WeatherService
{
    private readonly WeatherApi _api;
    //private readonly UnitOfWork _uow;
    public WeatherService(WeatherApi api)
    {
        _api = api;
    }

    public async Task<bool> GetCurrentWeather(WeatherDto dto)
    {
        //1. Call API
        //2. Save data
        //3. Return response
        var response=await _api.GetCurrentWeather(dto);
        if (response.Success)
        {
            //_uow.Weather.Insert(response.Data);
        }
        return false;
    }
}