using System.ComponentModel.DataAnnotations;

namespace WebApiAut.Validations
{
    public class MayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeraletra = value.ToString()[0].ToString();
            if (primeraletra != primeraletra.ToUpper())
            {
                return new ValidationResult("La primera letra tiene que ser mayuscula");
            }

            return ValidationResult.Success;
        }
    }
}
