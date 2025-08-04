using System.ComponentModel.DataAnnotations;

namespace clinic.domain.ValueObject
{
    public class PhoneNumber
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Number { get; set; }
    }
}
