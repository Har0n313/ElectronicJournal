using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Application.Dtos.AuthDtos
{
    public class RegisterRequest
    {
        public FullName FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }

}
