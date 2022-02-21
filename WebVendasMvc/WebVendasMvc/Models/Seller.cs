using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace WebVendasMvc.Models
{

    public class Seller
    {
        public int Id { get; set; }

        // informa que o campo é obrigatorio / {0} pega automaticamento o nome do atributo
        // {2} minimo e {1} maximo
        [Required(ErrorMessage = "{0} Obrigatorio")] // {0} pega o atributo
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter no minimo {2} caracteres e no máximo {1}")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Email inválido")]
        [DataType(DataType.EmailAddress)] // Formata o E-mail ja com link
        public string Email { get; set; }

        // do pacote using System.ComponentModel.DataAnnotations / Formatar a label no HTML
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)] // Formata a Data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Formata a data dia/mes/ano
        public DateTime BirthDate { get; set; }

        public Department Department { get; set; } // Um vendedor pode esta em um departamento
        public int DepartmentId { get; set; } // O complilador infere, Usado para criar uma chave Estrangeira inteira não nulla

        [Required]
        [Range(100.0, 5000.0, ErrorMessage ="{0} Deve está entre {1} e {2}")]
        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formata o valor com 2 casas decimais. O (Zero) indica o valor do atributo
        public double BaseSalary { get; set; }
        public ICollection<SallersRecord> Sales { get; set; } = new List<SallersRecord>();


        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
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

        public double TotalSalles(DateTime initialDate, DateTime finalDate)
        {

            return Sales.Where(sr => sr.Data >= initialDate && sr.Data <= finalDate).Sum(sr => sr.Amount);
        }








    }
}
