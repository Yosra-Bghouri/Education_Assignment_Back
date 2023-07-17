using System.ComponentModel.DataAnnotations;

namespace Education_Assignments_App.Dtos
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public String Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        

    }
}
