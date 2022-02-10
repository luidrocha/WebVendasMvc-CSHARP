
using System.Collections.Generic;



namespace WebVendasMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        // Classe composta para ser apresentada na View, pode-se usar dados de varias outras classes
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; } // Para montar a lista de Departmentos combo


    }
}
