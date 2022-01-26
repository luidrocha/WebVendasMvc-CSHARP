using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Saller { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department  { get; set; }
        public decimal BaseSalary { get; set; }
        public ICollection<SelersRecord> Selles { get; set; } = new List<SelersRecord>();


        public Seller()
        {

        }
        public Seller(int id, string seller, string email, DateTime birthDate, decimal baseSalary, Department department)
        {
            Id = id;
            Saller = seller;
            Email = email;
            BirthDate = birthDate;
            Department = department;
            BaseSalary = baseSalary;
        }

        public void AddSSalles(SelersRecord sr)
        {

            Selles.Add(sr);
        }

        public void RemoveSalles(SelersRecord sr)
        {
            Selles.Remove(sr);
        }

        public double TotalSalles (DateTime initial, DateTime final)
        {

            return Selles.Where(sr => sr.Data >= initial && sr.Data <= final).Sum(sr => sr.Amount);
        }

        





            
    }
}
