namespace Peak_Performance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Athlete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [StringLength(200)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public int TeamID { get; set; }

        public string FitBitUserID { get; set; }

        public string FitBitAccessToken { get; set; }

        public virtual Person Person { get; set; }

        public virtual Team Team { get; set; }
    }
}