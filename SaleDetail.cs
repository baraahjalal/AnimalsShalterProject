namespace AnimalsShalterProject
{
    public class SaleDetail
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }      // snapshot at sale time
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }       // snapshot — never re-read from Product later
        public decimal Subtotal => Quantity * UnitPrice;
    }
}
