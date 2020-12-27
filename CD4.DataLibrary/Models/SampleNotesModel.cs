using System;

namespace CD4.DataLibrary.Models
{
    public class SampleNotesModel
    {
        public int Id { get; set; }
        public string CIN { get; set; }
        public string Note { get; set; }
        public bool IsAttended { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
