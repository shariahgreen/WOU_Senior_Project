namespace Peak_Performance.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Peak_Performance.Models;

    public partial class PeakPerformanceContext : DbContext
    {
        public PeakPerformanceContext()
            : base("name=PeakPerformanceContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Complex> Complexes { get; set; }
        public virtual DbSet<ComplexItem> ComplexItems { get; set; }
        public virtual DbSet<ExcerciseMuscleGroup> ExcerciseMuscleGroups { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Athlete>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Teams)
                .WithOptional(e => e.Coach)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Complex>()
                .HasMany(e => e.ComplexItems)
                .WithRequired(e => e.Complex)
                .HasForeignKey(e => e.ComplexId);

            modelBuilder.Entity<Exercis>()
                .HasMany(e => e.ComplexItems)
                .WithRequired(e => e.Exercis)
                .HasForeignKey(e => e.ExerciseID);

            modelBuilder.Entity<Exercis>()
                .HasMany(e => e.ExcerciseMuscleGroups)
                .WithRequired(e => e.Exercis)
                .HasForeignKey(e => e.ExerciseID);

            modelBuilder.Entity<MuscleGroup>()
                .HasMany(e => e.ExcerciseMuscleGroups)
                .WithRequired(e => e.MuscleGroup)
                .HasForeignKey(e => e.MuscleGroupID);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workout>()
                .HasMany(e => e.Complexes)
                .WithOptional(e => e.Workout)
                .HasForeignKey(e => e.WorkoutID)
                .WillCascadeOnDelete();
        }
    }
}
