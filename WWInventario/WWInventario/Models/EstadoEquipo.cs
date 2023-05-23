using System.ComponentModel.DataAnnotations;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class EstadoEquipo : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Estatus del equipo")]
        public string Estado { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de cambio estatus")]
        public DateTime FechaModificacion { get; set; }

        //TODO
        //Se debe agregar el usuario que crea el registro y
        //el usuario que en dado caso pudo actualizar el registro
    }
}
