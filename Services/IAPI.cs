using VisitorManagementStudent2022.DTO;

namespace VisitorManagementStudent2022.Services
{
    public interface IAPI
    {
        string Message { get; set; }

        Task<Root> WeatherAPI(string apiKey, string URL);
    }
}