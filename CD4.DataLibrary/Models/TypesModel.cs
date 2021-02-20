using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class TypesModel
    {
        public TypesModel()
        {
            GenericModelsList = new List<Type>();
        }
        public List<Type> GenericModelsList { get; set; }
    }
}
