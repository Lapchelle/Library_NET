using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }


        public string Address { get; set; }

        public string? Phone_number { get; set; }

        public string   Password { get; set; } = string.Empty;

        public List<string>? Roles { get; set; }
        
    }
}