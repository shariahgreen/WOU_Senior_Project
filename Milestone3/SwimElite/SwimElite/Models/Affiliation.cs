namespace SwimElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Affiliation")]
    public partial class Affiliation
    {
        public int ID { get; set; }

        public int? PersonID { get; set; }

        public int? TeamID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Team Team { get; set; }
    }
}
