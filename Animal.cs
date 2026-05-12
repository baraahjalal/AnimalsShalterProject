using System;

namespace AnimalsShalterProject
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public string HealthStatus { get; set; }
        public string Status { get; set; }
        public DateTime? VaccineDate { get; set; }

        // خطوة 1 — حقول التطعيم الجديدة
        public bool IsVaccinated { get; set; }
        public DateTime? LastVaccineDate { get; set; }
    }
}