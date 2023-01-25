using WarehouseInv_Final_1.Models;
using System;
using System.Collections.Generic;

namespace WarehouseInv_Final_1
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
        public void UpdateProduct(Product product);

        public void InsertProduct(Product productToInsert);
        //public IEnumerable<Category> GetCategories();
        public Product AssignCategory();

        //public Product AssignLocation();

        public void DeleteProduct(Product product);

        public IEnumerable<Picklist> GetAllPickList();

        public void AddToPickList(int id);


    }
}
