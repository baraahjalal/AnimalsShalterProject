using System;
using System.Collections.Generic;

namespace AnimalsShalterProject
{
    public class Sale
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }     // snapshot
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }     // computed at confirm time, stored for fast display
        public List<SaleDetail> Details { get; set; } = new List<SaleDetail>();
    }
}
