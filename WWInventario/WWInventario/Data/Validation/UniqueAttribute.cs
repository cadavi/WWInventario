using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Validation
{
    public class UniqueAttribute : ValidationAttribute   
    {
        private string uniqueValue;
        public UniqueAttribute(string value)
        {
            uniqueValue = value;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string msg;

            if (value is String && (String) value == "Laptop")
            {
                    msg = base.ErrorMessage ??
                        $"{validationContext.DisplayName} existe este tipo de dispositivo.";

                    return new ValidationResult(msg);
            }

            return ValidationResult.Success;
        }
    }
}
