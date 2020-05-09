using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class GenericTwoListModel
    {
        public GenericTwoListModel GetLists<T,U>()
        {
            T1 = new List<T>();
            U1 = new List<U>();

            return this;
        }

        public dynamic T1 { get; set; }
        public dynamic U1 { get; set; }
    }
}
