using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class FallaEquipo : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; } 


        //Relationships

        //Equipo
        public int EstadoEquipoId { get; set; }
        [ForeignKey("EstadoEquipoId")]
        public EstadoEquipo Estado { get; set; } = null!;

        //Usuario
        //TODO

    }
}
