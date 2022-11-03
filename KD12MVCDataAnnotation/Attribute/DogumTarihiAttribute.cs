using System.ComponentModel.DataAnnotations;

namespace KD12MVCDataAnnotation.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter , AllowMultiple = false)]
    public class DogumTarihiAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime dogumTarihi = (DateTime)value;
                int sonuc = DateTime.Now.Year - dogumTarihi.Year;
                if(dogumTarihi < DateTime.Now && sonuc > 18)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
