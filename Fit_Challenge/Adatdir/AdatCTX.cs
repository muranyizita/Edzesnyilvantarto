using System;
using System.Collections.Generic;
using Fit_Challenge;
using Microsoft.EntityFrameworkCore;

namespace Fit_Challenge.Adatdir;

public partial class AdatCTX : DbContext
{
    public AdatCTX()
    {
    }

    public AdatCTX(DbContextOptions<AdatCTX> options)
        : base(options)
    {
    }

    public virtual DbSet<Edze> Edzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\Documents\\Fit_Challenge.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Edze>(entity =>
        {
            entity.HasKey(e => e.EdzesId).HasName("PK__tmp_ms_x__F7E487D0C30BED7C");

            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KezdIdopont).HasPrecision(4);
            entity.Property(e => e.Leiras).HasColumnType("text");
            entity.Property(e => e.SportAg)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SportFajta)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.VegIdopont).HasPrecision(4);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
