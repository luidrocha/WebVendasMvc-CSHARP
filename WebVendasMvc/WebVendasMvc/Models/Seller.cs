using System;
using System.Collections.Generic;
using System.Linq;



namespace WebVendasMvc.Models
{

    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department  { get; set; } // Um vendedor pode esta em um departamento
        public decimal BaseSalary { get; set; }
        public ICollection<SallersRecord> Sales { get; set; } = new List<SallersRecord>();


        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthDate, decimal baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Department = department;
            BaseSalary = baseSalary;
        }

        public void AddSSalles(SallersRecord sr)
        {

            Sales.Add(sr);
        }

        public void RemoveSalles(SallersRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSalles (DateTime initialDate, DateTime finalDate)
        {

            return Sales.Where(sr => sr.Data >= initialDate && sr.Data <= finalDate).Sum(sr => sr.Amount);
        }

        





            
    }
}
