using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Application.Dtos.AuthDtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
