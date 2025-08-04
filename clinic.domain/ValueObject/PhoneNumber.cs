using System.ComponentModel.DataAnnotations;

namespace clinic.domain.ValueObject
{
    public class PhoneNumber
    {
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3,4}[- ]?[0-9]{4}$", ErrorMessage = "Wrong format.")]
        public string Number { get; set; }
    }
}
