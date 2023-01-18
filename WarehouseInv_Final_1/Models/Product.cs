namespace WarehouseInv_Final_1.Models
{
    public class Product
    {
        public int UPC { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int QTY { get; set; }
        public int Zone { get; set; }
        public int Isle { get; set; }

        //public IEnumerable<Location> Locations { get; set; }




    }
}
