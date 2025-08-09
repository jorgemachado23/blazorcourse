using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Repositories;

public interface IJobCategoryRepository
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}