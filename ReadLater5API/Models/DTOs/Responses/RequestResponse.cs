using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5API.Models.DTOs.Responses
{
    public class RequestResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
