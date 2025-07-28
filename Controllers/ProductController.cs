using WebApiRestful.DTOs;
using WebApiRestful.Model;

namespace WebApiRestful.Controllers
{
    public class ProductController
    {
        private readonly List<Product> _products;

        public ProductController()
        {
            _products = new List<Product>();
        }
        public ProductResponse GetProduct(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };

        }
        public ProductResponse AddProduct(ProductResponse dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity
            };

            _products.Add(product);

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
