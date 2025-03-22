using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTrack.DBL.Models
{
    public class ClientModel
    {
          public int ClientId { get; set; }
            public string? ClientName { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? Address { get; set; }

            public int CountryId { get; set; }
        public string? CountryName { get; set; } 

        public int StatusId { get; set; }
        public string? StatusName { get; set; } 
        public int ProductId { get; set; } 
        }

    }

