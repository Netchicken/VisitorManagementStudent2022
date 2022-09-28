using VisitorManagementStudent2022.DTO;

namespace VisitorManagementStudent2022.Services
{
    public interface IAPI
    {
        Task<Root> WeatherAPI();
    }
}