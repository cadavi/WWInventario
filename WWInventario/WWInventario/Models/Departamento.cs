using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class Departamento:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre del departamento")]
        public string Nombre { get; set; } = null!;

        //Relationships

        //Sucursal
        public int SucursalId { get; set; }
        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; } = null!;
    }
}
