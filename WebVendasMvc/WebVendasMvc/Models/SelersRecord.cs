using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Models
{
    public class SelersRecord
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Amount { get; set; }
        public Seller Seller { get; set; }

        public SelersRecord()
        {

        }

        public SelersRecord(int id, DateTime data, double amount, Seller seller)
        {
            Id = id;
            Data = data;
            Amount = amount;
            Seller = seller;
        }
    }
}
