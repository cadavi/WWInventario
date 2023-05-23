using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.ViewModels
{
    public class NewSucursalVM : IEntityBase
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } = null!;

        [MaxLength(250)]
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Compañia")]
        public int CompaniaId { get; set; }
    }
}
