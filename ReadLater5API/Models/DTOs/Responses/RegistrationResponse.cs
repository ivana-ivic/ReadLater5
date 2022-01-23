using ReadLater5API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5API.Models.DTOs.Responses
{
    public class RegistrationResponse : RequestResponse
    {
        public string Token { get; set; }
    }
}
