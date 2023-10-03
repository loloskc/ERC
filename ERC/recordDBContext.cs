using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERC
{
    public partial class recordDBContext : DbContext
    {
        public recordDBContext()
        {
        }

        public recordDBContext(DbContextOptions<recordDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ElectricityBill> ElectricityBills { get; set; }
        public virtual DbSet<ResultDatum> ResultData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data source=recordDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricityBill>(entity =>
            {
                entity.ToTable("electricity_bill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gvc).HasColumnName("gvc");

                entity.Property(e => e.GvcE).HasColumnName("gvc_e");

                entity.Property(e => e.Hvc).HasColumnName("hvc");

                entity.Property(e => e.Ii).HasColumnName("ii");

                entity.Property(e => e.IiNight).HasColumnName("ii_night");

                entity.Property(e => e.QuantityHuman).HasColumnName("quantity_human");
            });

            modelBuilder.Entity<ResultDatum>(entity =>
            {
                entity.ToTable("result_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gvc).HasColumnName("gvc");

                entity.Property(e => e.GvcE).HasColumnName("gvc_e");

                entity.Property(e => e.Hvc).HasColumnName("hvc");

                entity.Property(e => e.Ii).HasColumnName("ii");

                entity.Property(e => e.QuantityHuman).HasColumnName("quantity_human");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
