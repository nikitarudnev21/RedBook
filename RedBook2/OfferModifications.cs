using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBook2
{
    [Table("Modifications")]
    public class OfferModifications
    {
        [PrimaryKey, AutoIncrement, Column("_ModificationId")]
        public int ModificationId { get; set; }
        public string OldName { get; set; }
        public int OldPopulation { get; set; }
        public string OldType { get; set; }
        public string OldDescription { get; set; }
        public string OldCategory { get; set; }
        public string OldViewImage { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ViewImage { get; set; }
    }
}