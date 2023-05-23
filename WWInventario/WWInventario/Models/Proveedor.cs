using System.ComponentModel.DataAnnotations;
using WWInventario.Data.Base;
using WWInventario.Data.Validation;

namespace WWInventario.Models
{
    public class Proveedor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string RNC { get; set; } = null;

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre proveedor")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Dirección")]
        [MaxLength(200)]
        public string? Direccion { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Correo principal")]
        public string EmailPrincipal { get; set; } = null!;

        [MaxLength(100)]
        [Display(Name = "Correo secundario")]
        public string? EmailSecundario { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Telefono principal")]
        public string TelefonoPrincipal { get; set; } = null!;

        [MaxLength(10)]
        [Display(Name = "Telefono secundario")]
        public string? TelefonoSecundario { get; set; }
    }
}
