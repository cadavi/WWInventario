using System.ComponentModel.DataAnnotations;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class Compania : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Debes especificar la compañia")]
        [Display(Name = "Compañia")]
        public string Nombre { get; set; } = null!;

        [MaxLength(100)]
        [Display(Name = "País")]
        [Required(ErrorMessage = "Debes especificar el país")]
        public string Pais { get; set; } = null!;

        [Display(Name = "Logo")]
        public string LogoPath { get; set; } = null!;
    }
}
