using CourseServicesCatalog.Dtos;
using CourseServicesCatalog.Models;
using CourseShared.Dtos;

namespace CourseServicesCatalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
  
    }
}
