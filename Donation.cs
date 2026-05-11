using System;

namespace AnimalsShalterProject
{
    public class Donation
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string DonorName { get; set; }      // snapshot at donation time
        public decimal Amount { get; set; }
        public string Category { get; set; }       // e.g., "Cash", "Food", "Supplies" — keep flexible
        public DateTime DonationDate { get; set; }
        public string Note { get; set; }           // optional, can be empty
    }
}
