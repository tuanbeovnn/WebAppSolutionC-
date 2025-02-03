using IntegrationApplication.EF;
using IntegrationModels.WeatherInfo;

namespace IntegrationApplication.Repositories;

public class WeatherInfoRepository(IntegrationDbContext context) : GenericRepository<WeatherInfoEntity>(context)
{
}