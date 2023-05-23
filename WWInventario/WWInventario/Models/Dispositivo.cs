using System.ComponentModel.DataAnnotations;
using WWInventario.Data;
using WWInventario.Data.Base;
using WWInventario.Data.Validation;

namespace WWInventario.Models
{
    public class Dispositivo : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Tipo dispositivo")]
        public string Tipo { get; set; } = null!;
    }
}
