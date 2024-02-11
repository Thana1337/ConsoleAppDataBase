using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;


namespace ConsoleAppDataBase.Services;

internal class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

        return categoryEntity;
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepository.Get(x => x.Id == id);
        return categoryEntity;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var categoryUpdated = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return categoryUpdated;
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
    }
}
