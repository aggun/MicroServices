using AutoMapper;
using CourseServicesCatalog.Dtos;
using CourseServicesCatalog.Models;
using CourseServicesCatalog.Settings;
using CourseShared.Dtos;
using MongoDB.Driver;

namespace CourseServicesCatalog.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task <Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);

        }

        public async Task <Response<CategoryDto>> CreateAsync (CategoryCreateDto categoryCreateDto)
        {
            var newcategory = _mapper.Map<Category>(categoryCreateDto);
            await _categoryCollection.InsertOneAsync(newcategory);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(newcategory), 200);
        }

        public async Task <Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if(category==null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }


    }
}
