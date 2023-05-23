using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWInventario.Data.Base;

namespace WWInventario.Models
{
    public class Usuario:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string EikonId { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string ApellidoPaterno { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string ApellidoMaterno { get; set; } = null!;

        //Relationships

        //Departamento
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; } = null!;

    }
}
