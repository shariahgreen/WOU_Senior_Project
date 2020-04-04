namespace Peak_Performance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExcerciseMuscleGroup
    {
        [Key]
        public int ExcerciseMuscleGroupsId { get; set; }

        public int MuscleGroupID { get; set; }

        public int ExerciseID { get; set; }

        public virtual Exercis Exercis { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
