using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Warehouse
{
    public interface IWarehouseRepository
    {

        Task AddProductAsync(Product product);
        void UpdateProduct(Product product, int quantity);
        Task<Product> GetOneProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task SaveAsync();
        int CheckProductQuantity(Product product);

        int CheckProductExists(Product product);


    }


}