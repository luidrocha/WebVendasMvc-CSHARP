﻿using System;
using System.Collections.Generic;
using WebVendasMvc.Models;

namespace WebVendasMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

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

            return 0;

         // return Sellers.Sum

        }
    }
}

