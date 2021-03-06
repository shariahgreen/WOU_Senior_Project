namespace SwimElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Time
    {
        public int ID { get; set; }

        [Column("Time")]
        public TimeSpan? Time1 { get; set; }

        public int? PersonID { get; set; }

        public int? EventID { get; set; }

        public virtual Event Event { get; set; }

        public virtual Person Person { get; set; }
    }
}
