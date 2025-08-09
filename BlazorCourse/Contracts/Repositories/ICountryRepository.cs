using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}
