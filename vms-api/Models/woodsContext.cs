using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vms_api.Models
{
    public partial class woodsContext : DbContext
    {
        public woodsContext()
        {
        }

        public woodsContext(DbContextOptions<woodsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-CT80891E;Initial Catalog=woods;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle", "vms");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasColumnName("booking_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VehId)
                    .HasColumnName("veh_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasColumnName("vendor")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
