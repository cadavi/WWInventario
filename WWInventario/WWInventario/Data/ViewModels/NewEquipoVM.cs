using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWInventario.Data;
using WWInventario.Data.Base;
using WWInventario.Data.Validation;
using WWInventario.Models;

namespace WWInventario.Models
{
    public class NewEquipoVM 
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Serial")]
        [Required]
        public string SerialNo { get; set; } = null!;

        [MaxLength(20)]
        [Display(Name = "Modelo")]
        [Required]
        public string Modelo { get; set; } = null!;

        [MaxLength(20)]
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de compra")]
        public DateTime FechaCompra { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha inicio de garantia")]
        public DateTime FechaInicioGarantia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha fin de garantia")]
        //[FechaFinGarantia]
        public DateTime FechaFinGarantia { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de asignación")]
        public DateTime? FechaAsignacion { get; set; }

        //Relationships

        //Dispositivo
        [Required(ErrorMessage = "Debes especificar el dispositivo")]
        [Display(Name = "Tipo de dispositivo")]
        public int DispositivoId { get; set; }

        //EstadoEquipo
        [Required(ErrorMessage = "Debes especificar el estado del dispositivo")]
        [Display(Name = "Estatus del equipo")]
        public int EstadoEquipoId { get; set; }

        //Usuario
        [Display(Name = "Equipo asignado a")]
        public int? UsuarioResponsableId { get; set; }

    }
}
