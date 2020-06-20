using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class AuthorizeDetailEventArgs : EventArgs
    {
        public string UserRole { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<string> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
    }
}
