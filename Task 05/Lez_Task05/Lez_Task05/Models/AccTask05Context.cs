using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lez_Task05.Models;

public partial class AccTask05Context : DbContext
{
    public AccTask05Context()
    {
    }

    public AccTask05Context(DbContextOptions<AccTask05Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Partecipante> Partecipantes { get; set; }

    public virtual DbSet<Risorsa> Risorsas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-14\\SQLEXPRESS;Database=acc_task05;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__DE07229CFCC4CD2E");

            entity.ToTable("Evento");

            entity.HasIndex(e => new { e.DataEvento, e.Luogo }, "UQ__Evento__8E13433748293C70").IsUnique();

            entity.Property(e => e.EventoId).HasColumnName("eventoID");
            entity.Property(e => e.CapMax).HasColumnName("capMax");
            entity.Property(e => e.DataEvento).HasColumnName("dataEvento");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descrizione");
            entity.Property(e => e.Luogo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("luogo");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Partecipante>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__59BAFC0E1288B58D");

            entity.ToTable("Partecipante");

            entity.HasIndex(e => new { e.CodiceBiglietto, e.EventoRif }, "UQ__Partecip__1484218F3120B086").IsUnique();

            entity.Property(e => e.PartecipanteId).HasColumnName("partecipanteID");
            entity.Property(e => e.CodiceBiglietto)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("codiceBiglietto");
            entity.Property(e => e.Contatto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("contatto");
            entity.Property(e => e.EventoRif).HasColumnName("eventoRIF");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.EventoRifNavigation).WithMany(p => p.Partecipantes)
                .HasForeignKey(d => d.EventoRif)
                .HasConstraintName("FK__Partecipa__event__3B75D760");
        });

        modelBuilder.Entity<Risorsa>(entity =>
        {
            entity.HasKey(e => e.RisorsaId).HasName("PK__Risorsa__31473C999026B8FA");

            entity.ToTable("Risorsa");

            entity.Property(e => e.RisorsaId).HasColumnName("risorsaID");
            entity.Property(e => e.Atrezzatura)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("atrezzatura");
            entity.Property(e => e.Cibo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cibo");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("costo");
            entity.Property(e => e.EventoRif).HasColumnName("eventoRIF");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fornitore");
            entity.Property(e => e.Quantita).HasColumnName("quantita");

            entity.HasOne(d => d.EventoRifNavigation).WithMany(p => p.Risorsas)
                .HasForeignKey(d => d.EventoRif)
                .HasConstraintName("FK__Risorsa__eventoR__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
