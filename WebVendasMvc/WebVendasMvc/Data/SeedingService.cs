using System;
using WebVendasMvc.Models;
using WebVendasMvc.Models.Enums;
using System.Linq;
using System.Globalization;


// Serviço para popular a base

namespace WebVendasMvc.Data
{
    public class SeedingService
    {
        private WebVendasMvcContext _context;

        // Quando SeedingService service for criado recebebe uma instancia do contexto tambem

        public SeedingService(WebVendasMvcContext context)
        {

            _context = context;


        }
        // Metodo para popular a tabela
        public void Seed()
        {
            // Testa pra ver se existe algum registro na tabela 

            if (_context.Department.Any() || _context.Seller.Any() ||
                _context.SellersRecord.Any())
            {

                return; // Corta a execucao do metodo. faz nada.
            }

            // Cria os departamentos e instancia

            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Escritorio");
            Department d4 = new Department(4, "Ferramentas");
            Department d5 = new Department(5, "Jardins");

            // Cria os vendedores e instancia

            Seller s1 = new Seller(1, "Jose Luis", "luidrocha@yahoo.com.br", new DateTime(1974, 06, 7), 1900.00, d1);
            Seller s2 = new Seller(2, "Luis Guilherme", "Guilherme@yahoo.com.br", new DateTime(2013, 06, 20), 1200.00, d1);
            Seller s3 = new Seller(3, "Sara Rocha", "Sara@yahoo.com.br", new DateTime(1997, 06, 16), 1700.00, d1);
            Seller s4 = new Seller(4, "Neia Araujo", "NeiaMota@yahoo.com.br", new DateTime(1978, 08, 20), 1950.00, d2);
            Seller s5 = new Seller(5, "Baruck Rocha", "Baruck@yahoo.com.br", new DateTime(2021, 04, 11), 500.00, d2);
            Seller s6 = new Seller(6, "Lucas Araujo", "Lucas@yahoo.com.br", new DateTime(1993, 10, 11), 1100.00, d4);
            Seller s7 = new Seller(7, "Teka", "Teka@yahoo.com.br", new DateTime(1973, 12, 18), 1100.00, d4);

            // cria a venda e instancia

            SallersRecord sr1 = new SallersRecord(1, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s1);
            SallersRecord sr2 = new SallersRecord(2, new DateTime(2020, 01, 03), 1800.00, StatusVenda.Billed, s1);
            SallersRecord sr3 = new SallersRecord(3, new DateTime(2020, 01, 03), 800.00, StatusVenda.Canceled, s1);
            SallersRecord sr4 = new SallersRecord(4, new DateTime(2020, 01, 04), 890.00, StatusVenda.Billed, s1);
            SallersRecord sr5 = new SallersRecord(5, new DateTime(2020, 01, 04), 200.00, StatusVenda.Billed, s1);
            SallersRecord sr6 = new SallersRecord(6, new DateTime(2020, 01, 05), 3800.00, StatusVenda.Billed, s1);

            SallersRecord sr7 = new SallersRecord(7, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s2);
            SallersRecord sr8 = new SallersRecord(8, new DateTime(2020, 01, 03), 2900.00, StatusVenda.Billed, s2);
            SallersRecord sr9 = new SallersRecord(9, new DateTime(2020, 01, 04), 800.00, StatusVenda.Billed, s2);
            SallersRecord sr10 = new SallersRecord(10, new DateTime(2020, 01, 05), 280.00, StatusVenda.Billed, s2);
            SallersRecord sr11 = new SallersRecord(11, new DateTime(2020, 01, 05), 2500.00, StatusVenda.Billed, s2);

            SallersRecord sr12 = new SallersRecord(12, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s3);
            SallersRecord sr13 = new SallersRecord(13, new DateTime(2020, 01, 03), 2900.00, StatusVenda.Billed, s3);
            SallersRecord sr14 = new SallersRecord(14, new DateTime(2020, 01, 04), 800.00, StatusVenda.Billed, s3);
            SallersRecord sr15 = new SallersRecord(15, new DateTime(2020, 01, 04), 280.00, StatusVenda.Billed, s3);
            SallersRecord sr16 = new SallersRecord(16, new DateTime(2020, 01, 05), 500.00, StatusVenda.Billed, s3);

            SallersRecord sr17 = new SallersRecord(17, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s4);
            SallersRecord sr18 = new SallersRecord(18, new DateTime(2020, 01, 03), 900.00, StatusVenda.Billed, s4);
            SallersRecord sr19 = new SallersRecord(19, new DateTime(2020, 01, 04), 800.00, StatusVenda.Billed, s4);
            SallersRecord sr20 = new SallersRecord(20, new DateTime(2020, 01, 04), 280.00, StatusVenda.Billed, s4);
            SallersRecord sr21 = new SallersRecord(21, new DateTime(2020, 01, 05), 500.00, StatusVenda.Billed, s4);

            SallersRecord sr22 = new SallersRecord(22, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s5);
            SallersRecord sr23 = new SallersRecord(23, new DateTime(2020, 01, 04), 900.00, StatusVenda.Billed, s5);
            SallersRecord sr24 = new SallersRecord(24, new DateTime(2020, 01, 04), 1800.00, StatusVenda.Billed, s5);
            SallersRecord sr25 = new SallersRecord(25, new DateTime(2020, 01, 04), 5280.00, StatusVenda.Billed, s5);
            SallersRecord sr26 = new SallersRecord(26, new DateTime(2020, 01, 05), 1500.00, StatusVenda.Billed, s5);

            SallersRecord sr27 = new SallersRecord(27, new DateTime(2020, 01, 03), 2800.00, StatusVenda.Billed, s6);
            SallersRecord sr28 = new SallersRecord(28, new DateTime(2020, 01, 04), 900.00, StatusVenda.Billed, s6);
            SallersRecord sr29 = new SallersRecord(29, new DateTime(2020, 01, 04), 1800.00, StatusVenda.Canceled, s6);
            SallersRecord sr30 = new SallersRecord(30, new DateTime(2020, 01, 04), 5280.00, StatusVenda.Billed, s6);
            SallersRecord sr31 = new SallersRecord(31, new DateTime(2020, 01, 05), 1500.00, StatusVenda.Canceled, s6); 

            
            

            _context.Department.AddRange(d1, d2, d3, d4, d5); // Permite adicionar varios elementos
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7);

            _context.SellersRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10,
                sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20,
                sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29, sr30, sr31);

          

            _context.SaveChanges(); // Confirmaas alterações no banco de dados semelhando ao COMMIT.

        }


    }
}
