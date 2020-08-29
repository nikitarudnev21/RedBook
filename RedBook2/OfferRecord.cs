using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBook2
{
    [Table("MyOfferRecord")]
    public class OfferRecord
    {
        [PrimaryKey, AutoIncrement, Column("_OfferId")]
        public int OfferId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ViewImage { get; set; }
      //  public string OldDescription { get; set; }
        //public bool Approved { get; set; } = false;
    }
}
