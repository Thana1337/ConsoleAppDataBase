using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;

namespace ConsoleAppDataBase.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;
    private readonly ManufactureService _manufactureService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService, ManufactureService manufactureService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
        _manufactureService = manufactureService;
    }

    public ProductEntity CreateProduct(string title, string description, decimal price, string categoryName)//, string manufactureName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);
        //var manufactureEntity = _manufactureService.CreateManufactureName(manufactureName);
        var productEntity = new ProductEntity
        {
            Title = title,
            Description = description,
            Price = price,
            CategoryId = categoryEntity.Id,
            //ManufactureId = manufactureEntity.Id

        };
        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }


    public ProductEntity GetProductByTitle(string productTitle)
    {
        var productEntity = _productRepository.Get(x => x.Title == productTitle);
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductEntity GetProductById(int id)
    {
        var productEntity = _productRepository.Get(x => x.Id == id);
        return productEntity;
    }


    public ProductEntity UpdateProductTitle(int productId, string newTitle)
    {
        var productToUpdate = _productRepository.GetById(productId);
        if (productToUpdate != null)
        {
            productToUpdate.Title = newTitle;
            return _productRepository.Update(p => p.Id == productId, productToUpdate);
        }
        else
        {
            return null!;
        }
    }
    public void UpdateProductDescription(int productId, string newDescription)
    {
        var product = _productRepository.GetById(productId);
        if (product != null)
        {
            product.Description = newDescription;
            _productRepository.Update(p => p.Id == productId, product);
        }
    }

    public void UpdateProductPrice(int productId, decimal newPrice)
    {
        var product = _productRepository.GetById(productId);
        if (product != null)
        {
            product.Price = newPrice;
            _productRepository.Update(p => p.Id == productId, product);
        }
    }

    public void UpdateProductCategory(int productId, string newCategoryName)
    {
        var product = _productRepository.GetById(productId);
        if (product != null)
        {
            var category = _categoryService.CreateCategory(newCategoryName);
            product.Category = category;
            _productRepository.Update(p => p.Id == productId, product);
        }
    }


    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
