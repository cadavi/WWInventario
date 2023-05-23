using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class Sucursal:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } = null!;

        [MaxLength(250)]
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = null!;

        //Relationships
        [Display(Name = "Compañia")]
        public int CompaniaId { get; set; }
        [ForeignKey("CompaniaId")]
        public Compania Compania { get; set; } = null!;
    }
}
