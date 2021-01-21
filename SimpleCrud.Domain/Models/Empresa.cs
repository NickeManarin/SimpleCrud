using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Domain.Models
{
    public class Empresa
    {
        public long Id { get; set; }

        [Required, StringLength(255, MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string Site { get; set; }

        [Required]
        public int QuantidadeFuncionarios { get; set; }
    }
}