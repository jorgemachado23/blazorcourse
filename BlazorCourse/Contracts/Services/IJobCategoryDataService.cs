using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}
