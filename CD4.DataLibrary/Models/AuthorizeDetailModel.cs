using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class AuthorizeDetailModel
    {
        public string UserRole { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ClaimsCsv { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
    }
}
