using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Atividade_05_08.Domains
{
    [Table(nameof(Products))]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "Decimal")]
        public decimal Price { get; set; }

    }
}
