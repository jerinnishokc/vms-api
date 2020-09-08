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
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Vehicle__DD7012641435F1A2");

                entity.ToTable("Vehicle", "vms");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookedUserName)
                    .HasColumnName("booked_user_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookedUserUid)
                    .HasColumnName("booked_user_uid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasColumnName("booking_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.RegId)
                    .IsRequired()
                    .HasColumnName("reg_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("vendor_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendor_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
