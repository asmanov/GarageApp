using System;
using System.Collections.Generic;
using GarageApp.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Api.Persistence;

public partial class GarageAppContext : DbContext
{
    public GarageAppContext()
    {
    }

    public GarageAppContext(DbContextOptions<GarageAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandTrac> BrandTracs { get; set; }

    public virtual DbSet<Garage> Garages { get; set; }

    public virtual DbSet<GarageView> GarageViews { get; set; }

    public virtual DbSet<ModelTrac> ModelTracs { get; set; }

    public virtual DbSet<Refueling> Refuelings { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Tguser> Tgusers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Asmanov1978;Database=testGarage");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandTrac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brandTracs_pkey");

            entity.ToTable("brand_tracs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Garage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("garage_pkey");

            entity.ToTable("garage");

            entity.Property(e => e.Id)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.FuelTank).HasColumnName("fuel_tank");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Sites).HasColumnName("sites");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Vin)
                .HasMaxLength(20)
                .HasColumnName("vin");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(entity => entity.Image).HasColumnName("image");

            entity.HasOne(d => d.ModelNavigation).WithMany(p => p.Garages)
                .HasForeignKey(d => d.Model)
                .HasConstraintName("FK_modelTrack");

            entity.HasOne(d => d.SitesNavigation).WithMany(p => p.Garages)
                .HasForeignKey(d => d.Sites)
                .HasConstraintName("fk_sites");
        });

        modelBuilder.Entity<GarageView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("garage_view");

            entity.Property(e => e.ГодВыпуска).HasColumnName("Год выпуска");
            entity.Property(e => e.Марка).HasMaxLength(15);
            entity.Property(e => e.Модель).HasMaxLength(15);
            entity.Property(e => e.Номер)
                .HasMaxLength(11)
                .IsFixedLength();
        });

        modelBuilder.Entity<ModelTrac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modelTracs_pkey");

            entity.ToTable("model_tracs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandName).HasColumnName("brand_name");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.MaxMass).HasColumnName("max_mass");
            entity.Property(e => e.ModelName)
                .HasMaxLength(15)
                .HasColumnName("model_name");
            entity.Property(e => e.ServMass).HasColumnName("serv_mass");

            entity.HasOne(d => d.BrandNameNavigation).WithMany(p => p.ModelTracs)
                .HasForeignKey(d => d.BrandName)
                .HasConstraintName("brandName");
        });

        modelBuilder.Entity<Refueling>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refueling_pkey");

            entity.ToTable("refueling");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Equipment)
                .HasMaxLength(12)
                .HasColumnName("equipment");
            entity.Property(e => e.Site).HasColumnName("site");
            entity.Property(e => e.Tguser).HasColumnName("tguser");
            entity.Property(e => e.Volume)
                .HasPrecision(6, 2)
                .HasColumnName("volume");

            entity.HasOne(d => d.EquipmentNavigation).WithMany(p => p.Refuelings)
                .HasForeignKey(d => d.Equipment)
                .HasConstraintName("fk_garage");

            entity.HasOne(d => d.SiteNavigation).WithMany(p => p.Refuelings)
                .HasForeignKey(d => d.Site)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_site");

            entity.HasOne(d => d.TguserNavigation).WithMany(p => p.Refuelings)
                .HasForeignKey(d => d.Tguser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tguser");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sites_pkey");

            entity.ToTable("sites");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tguser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("tgUser_pkey");

            entity.ToTable("tguser");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Access)
                .HasDefaultValue(false)
                .HasColumnName("access");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .HasColumnName("last_name");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
