using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Contracts.Repositories;
using BlazorCourse.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCourse.Repositories;
public class CountryRepository : ICountryRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    //public CountryRepository(AppDbContext appDbContext)
    //{
    //    _appDbContext = appDbContext;
    //}

    public CountryRepository(IDbContextFactory<AppDbContext> DbFactory)
    {
        _appDbContext = DbFactory.CreateDbContext();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();    
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await Task.FromResult(_appDbContext.Countries);
    }

    public async Task<Country> GetCountryById(int countryId)
    {
        return await _appDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId);
    }
}