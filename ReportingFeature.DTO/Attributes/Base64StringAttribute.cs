using System.ComponentModel.DataAnnotations;

namespace ReportingFeature.API.Attributes
{
    public class Base64StringAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Value = value as string;
            try
            {
                if (Value is not null)
                {
                    byte[] decodedBytes = Convert.FromBase64String(Value);
                    // If successful, it's likely base64
                }
                return ValidationResult.Success;
                // Attempt to decode the string

            }
            catch (FormatException)
            {
                // Decoding failed, not base64
                return new ValidationResult(ErrorMessage = "Base64 Not On the Correct Format");
            }
        }
      
    }
}
