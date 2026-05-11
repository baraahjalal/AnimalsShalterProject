using System;

namespace AnimalsShalterProject
{
    public class Adoption
    {
        public int ID { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }      // snapshot at adoption time
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }    // snapshot at adoption time
        public string CustomerPhone { get; set; }   // snapshot at adoption time
        public DateTime AdoptionDate { get; set; }
        public decimal FeePaid { get; set; }
    }
}
