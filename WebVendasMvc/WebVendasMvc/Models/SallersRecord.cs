using System;
using WebVendasMvc.Models.Enums;


namespace WebVendasMvc.Models
{
    public class SallersRecord
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Amount { get; set; }

        public StatusVenda Status { get; set; }
        public Seller Seller { get; set; } // Cada venda tem um vendedor

        public SallersRecord()
        {

        }

        public SallersRecord(int id, DateTime data, double amount, StatusVenda status, Seller seller)
        {
            Id = id;
            Data = data;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
