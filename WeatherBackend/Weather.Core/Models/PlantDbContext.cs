using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Weather.Core.Models;

public partial class PlantDbContext : DbContext
{
    public PlantDbContext()
    {
    }

    public PlantDbContext(DbContextOptions<PlantDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plant> Plants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=PlantDB;User ID=SA;Password=nomad513;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>(entity =>
        {
            entity.ToTable("Plant");

            entity.Property(e => e.PlantId).HasColumnName("Plant_ID");
            entity.Property(e => e.PlantDescription).IsUnicode(false);
            entity.Property(e => e.PlantName).HasMaxLength(255);
            entity.Property(e => e.WeatherTypeFk).HasColumnName("WeatherType_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
