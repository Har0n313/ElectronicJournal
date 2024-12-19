using ElectronicJournal.Domain.Primitives.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Application.Dtos.AuthDtos
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string Emaile { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
