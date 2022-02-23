using System;
using WebVendasMvc.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebVendasMvc.Models
{
    public class SallersRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
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
