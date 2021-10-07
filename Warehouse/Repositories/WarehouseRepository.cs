using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace Warehouse
{
    public class WarehouseRepository: IWarehouseRepository
    {

        private Database _db;

        public WarehouseRepository(Database db){
            _db=db;
        }


         public async Task AddProductAsync(Product product){
             await _db.AddAsync(product);
         }
       public void UpdateProduct(Product product, int quantity){
           product.Quantity=quantity;
        }
        public async Task<Product> GetOneProductAsync(int productId){
           return await _db.Products.Where(p=>p.Id==productId).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync(){
            return await _db.Products.ToListAsync();
        }
        public async Task SaveAsync(){
            await _db.SaveChangesAsync();
        }
        public int CheckProductQuantity(Product product){
            return product.Quantity;
        }


    }


}