using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBook2
{
    [Table("Deleted")]
    public class Deleted 
    {
        public int deletedID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
