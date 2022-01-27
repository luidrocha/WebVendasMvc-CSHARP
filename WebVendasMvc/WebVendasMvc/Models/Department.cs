using System;
using System.Collections.Generic;
using WebVendasMvc.Models;
using System.Linq;

namespace WebVendasMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); // Um departamento tem varios vendedores

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);

        }

        public double TotalSalles(DateTime inicial, DateTime final)
        {

            return Sellers.Sum(Seller => Seller.TotalSalles(inicial, final)); // Faz o somatório da lista de vendedores

         // return Sellers.Sum

        }
    }
}

