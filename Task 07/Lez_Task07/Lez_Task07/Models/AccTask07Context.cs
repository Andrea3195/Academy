using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lez_Task07.Models;

public partial class AccTask07Context : DbContext
{
    public AccTask07Context()
    {
    }

    public AccTask07Context(DbContextOptions<AccTask07Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-14\\SQLEXPRESS;Database=acc_task07;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB659750458D726");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.DataCre).HasColumnName("data_cre");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
