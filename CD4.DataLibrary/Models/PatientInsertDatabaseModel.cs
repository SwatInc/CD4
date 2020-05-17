using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
	public class PatientInsertDatabaseModel
	{
		public string Fullname { get; set; }
		public string NidPp { get; set; }
		public string Birthdate { get; set; }
		public int GenderId { get; set; }
		public int AtollId { get; set; }
		public int CountryId { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
	}
}
