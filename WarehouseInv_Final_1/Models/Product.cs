namespace WarehouseInv_Final_1.Models
{
    public class Product
    {
        public int UPC { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int QTY { get; set; }

        public IEnumerable<Location> Locations { get; set; }




    }
}
