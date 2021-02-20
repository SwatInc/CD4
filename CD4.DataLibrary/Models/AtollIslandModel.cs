using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    //Shadows dbo.Atolls
    public class AtollIslandModel : AtollModel
    {
        private string island;

        public string Island { get; set; }

    }
}
