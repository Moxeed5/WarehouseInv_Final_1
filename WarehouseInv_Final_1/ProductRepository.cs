using Dapper;
using System.Data;
using System.Security.Policy;
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

        //public Product AssignLocation()
        //{
        //    var locationList = GetLocations();
        //    var product = new Product();
        //    product.Locations = locationList;
        //    return product;
        //}

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        //public IEnumerable<Location> GetLocations()
        //{
        //    return _conn.Query<Location>("SELECT * FROM location;");
        //}

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE UPC = @id", new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {   
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORY, UPC, QTY, ZONE, ISLE) VALUES (@name, @price, @category, @upc, @qty, @zone, @isle);",
                new { name = productToInsert.Name, price = productToInsert.Price, category = productToInsert.Category, upc = productToInsert.UPC, qty = productToInsert.QTY, zone = productToInsert.Zone, isle = productToInsert.Isle});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, QTY = @qty, Category = @category, Price = @price WHERE UPC = @id",
            new { name = product.Name, price = product.Price, id = product.UPC, qty = product.QTY, category = product.Category});
        }

        public void DeleteProduct(Product product)
        {
            
            _conn.Execute("DELETE FROM Products WHERE UPC = @id;", new { id = product.UPC });
        }

        public IEnumerable<Picklist> GetAllPickList()
        {
            return _conn.Query<Picklist>("SELECT * FROM picklist;");
        }

        public void AddToPickList(int id)
        {
            var product = GetProduct(id);

            _conn.Execute("INSERT INTO picklist (NAME, PRICE, UPC, QTY, ZONE, ISLE) VALUES (@name, @price, @upc, @qty, @zone, @isle);",
                new { name = product.Name, price = product.Price, upc = product.UPC, qty = product.QTY, zone = product.Zone, isle = product.Isle });
        }

        //public void AddToPickList(int selectedUPCs)
        //{


        //    var product = GetProduct(selectedUPCs);
        //    _conn.Execute("INSERT INTO picklist (NAME, PRICE, UPC, QTY, ZONE, ISLE) VALUES (@name, @price, @upc, @qty, @zone, @isle);",
        //        new { name = product.Name, price = product.Price, upc = product.UPC, qty = product.QTY, zone = product.Zone, isle = product.Isle });

        //}

    }
}
