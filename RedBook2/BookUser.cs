using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBook2
{
    [Table("BookUser")]
    public class BookUser
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string OldName { get; set; }
        public int Population { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ViewImage { get; set; }
    }
}