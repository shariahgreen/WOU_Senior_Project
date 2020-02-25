namespace Peak_Performance.Models
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
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

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

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}