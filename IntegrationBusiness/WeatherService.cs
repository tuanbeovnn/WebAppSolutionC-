using IntegrationApplication;
using IntegrationDtos;
using IntegrationModels;
using IntegrationModels.WeatherInfo;

namespace IntegrationBusiness;

public class WeatherService
{
    private readonly WeatherApi _api;
    private readonly IUnitOfWork _uow;

    public WeatherService(WeatherApi api, IUnitOfWork uow)
    {
        _api = api;
        _uow = uow;
    }

    public async Task<bool> GetCurrentWeather(WeatherDto dto)
    {
        //1. Call API
        //2. Save data
        //3. Return response
        var response = await _api.GetCurrentWeather(dto);
        if (response.Success)
        {
            _uow.WeatherInfo.Insert(new WeatherInfoEntity()
            {
                city = "demo"
            });
            return await _uow.SaveChangeAsync();
        }

        return false;
    }
}