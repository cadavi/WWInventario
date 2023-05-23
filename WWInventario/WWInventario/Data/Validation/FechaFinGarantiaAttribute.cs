using System.ComponentModel.DataAnnotations;

namespace WWInventario.Data.Validation
{
	public class FechaFinGarantiaAttribute : ValidationAttribute
	{
		private DateTime _fechaIniGarantia;

		public FechaFinGarantiaAttribute(DateTime fechaIniGarantia)
		{
			_fechaIniGarantia = fechaIniGarantia;
		}

		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if(value is DateTime)
			{
				DateTime dateToCheck = (DateTime)value;

				if( dateToCheck >= _fechaIniGarantia){
					return ValidationResult.Success;
				}
			}

			string msg = base.ErrorMessage ??
				$"{validationContext.DisplayName} debe ser mayor que la fecha de inicio de la garantia.";

			return new ValidationResult(msg);
		}
	}
}
