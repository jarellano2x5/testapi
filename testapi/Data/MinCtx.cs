using System;
using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Data
{
    public partial class MinCtx : DbContext
    {
        public MinCtx(DbContextOptions<MinCtx> options) : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Status> Statues { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<Tipe> Tipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.HasKey(e => e.IdCountry);
                entity.Property(e => e.Acronym).IsRequired()
                    .HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Language).IsRequired()
                    .HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired()
                    .HasMaxLength(50).IsUnicode(false);
            });

            builder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");
                entity.HasKey(e => e.IdShop);
                entity.Property(e => e.RFC).IsRequired()
                    .HasMaxLength(13).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired()
                    .HasMaxLength(300).IsUnicode(false);
                entity.Property(e => e.Alias).IsRequired()
                    .HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Zip).IsRequired()
                    .HasMaxLength(5).IsUnicode(false);
                entity.Property(e => e.TagLine).IsRequired()
                    .HasMaxLength(150).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_Shop_Country");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Shop_Status");
            });

            builder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");
                entity.HasKey(e => e.IdStatus);
                entity.Property(e => e.Name).IsRequired()
                    .HasMaxLength(20).IsUnicode(false);
            });

            builder.Entity<Tariff>(entity =>
            {
                entity.ToTable("Tariff");
                entity.HasKey(e => e.IdTariff);
                entity.Property(e => e.Initial).IsRequired()
                    .HasMaxLength(6).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired()
                    .HasMaxLength(30).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Tariffies)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_Tariff_Country");
            });

            builder.Entity<Tipe>(entity =>
            {
                entity.ToTable("Tipe");
                entity.HasKey(e => e.IdType);
                entity.Property(e => e.Name).IsRequired()
                    .HasMaxLength(30).IsUnicode(false);
            });
        }
    }
}
