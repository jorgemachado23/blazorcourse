using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Services;

public interface ICountryDataService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}
