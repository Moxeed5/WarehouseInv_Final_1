using Dapper;
using System.Data;
using WarehouseInv_Final_1.Models;

namespace WarehouseInv_Final_1
{
    public class ProductRepository : IProductRepository
    {

        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Product AssignCategory()
        {
            throw new NotImplementedException();
        }

        //public Product AssignCategory()
        //{
        //    var categoryList = GetCategories();
        //    var product = new Product();
        //    product.Categories = categoryList;
        //    return product;
        //}

        public Product AssignLocation()
        {
            var locationList = GetLocations();
            var product = new Product();
            product.Locations = locationList;
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public IEnumerable<Location> GetLocations()
        {
            return _conn.Query<Location>("SELECT * FROM location;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE UPC = @id", new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {   
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID, UPC, LOCATION) VALUES (@name, @price, @categoryID, @upc, @location);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID, upc = productToInsert.UPC, location = productToInsert.Locations});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE UPC = @id",
            new { name = product.Name, price = product.Price, id = product.UPC });
        }

       
    }
}
