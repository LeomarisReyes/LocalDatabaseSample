using System;
using SQLite;

namespace LocalDatabaseSample.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int    ID        { get; set; }
        public string Name      { get; set; }
        public string LastName  { get; set; }
        public string Telephone { get; set; }
    }
}
