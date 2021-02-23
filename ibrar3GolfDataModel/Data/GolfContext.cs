using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ibrar3GolfDataModel.Models;

namespace ibrar3GolfDataModel.Data
{
    public partial class GolfContext : DbContext
    {
        public GolfContext()
        {
        }

        public GolfContext(DbContextOptions<GolfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ibrar3_Golf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecurringDay)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RecurringRule)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_User");
            });

            modelBuilder.Entity<Scores>(entity =>
            {
                entity.Property(e => e.DatePlayed).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scores_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
