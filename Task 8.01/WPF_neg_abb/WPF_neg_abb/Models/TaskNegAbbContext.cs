using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_neg_abb.Models;

public partial class TaskNegAbbContext : DbContext
{
    public TaskNegAbbContext()
    {
    }

    public TaskNegAbbContext(DbContextOptions<TaskNegAbbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Gallerium> Galleria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<PrezzoOffertum> PrezzoOfferta { get; set; }

    public virtual DbSet<PrezzoPieno> PrezzoPienos { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-05\\SQLEXPRESS;Database=task_neg_abb;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C02038A7FE56");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DCA0E68C96").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Gallerium>(entity =>
        {
            entity.HasKey(e => e.GalleriaId).HasName("PK__Galleria__EC91D0256E4F7491");

            entity.Property(e => e.GalleriaId).HasColumnName("galleriaID");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Galleria)
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Galleria__prodot__5BAD9CC8");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E5EFAC5FC2");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataOrdine)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("data_ordine");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.QuantitaProdotti).HasColumnName("quantita_prodotti");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine__prodotto__607251E5");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine__utenteRI__5F7E2DAC");
        });

        modelBuilder.Entity<PrezzoOffertum>(entity =>
        {
            entity.HasKey(e => e.PrezzoOffertaId).HasName("PK__Prezzo_O__EE6D5556444223CE");

            entity.ToTable("Prezzo_Offerta");

            entity.Property(e => e.PrezzoOffertaId).HasColumnName("prezzo_offertaID");
            entity.Property(e => e.DataFine).HasColumnName("data_fine");
            entity.Property(e => e.DataInizio).HasColumnName("data_inizio");
            entity.Property(e => e.Valore).HasColumnName("valore");
        });

        modelBuilder.Entity<PrezzoPieno>(entity =>
        {
            entity.HasKey(e => e.PrezzoPienoId).HasName("PK__Prezzo_P__5C94DD6275A33324");

            entity.ToTable("Prezzo_Pieno");

            entity.Property(e => e.PrezzoPienoId).HasColumnName("prezzo_pienoID");
            entity.Property(e => e.Valore).HasColumnName("valore");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB65975B5D52AE6");

            entity.ToTable("Prodotto");

            entity.HasIndex(e => e.CodiceProdotto, "UQ__Prodotto__C2FA4F82FF0BBA3F").IsUnique();

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.CodiceProdotto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codice_prodotto");
            entity.Property(e => e.Colore)
                .HasMaxLength(100)
                .HasColumnName("colore");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.IsDisponibile)
                .HasDefaultValue(true)
                .HasColumnName("isDisponibile");
            entity.Property(e => e.PrezzoOffertaRif).HasColumnName("prezzo_offertaRIF");
            entity.Property(e => e.PrezzoPienoRif).HasColumnName("prezzo_pienoRIF");
            entity.Property(e => e.QuantitaProdotto).HasColumnName("quantita_prodotto");
            entity.Property(e => e.Taglia)
                .HasMaxLength(100)
                .HasColumnName("taglia");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prodotto__catego__56E8E7AB");

            entity.HasOne(d => d.PrezzoOffertaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.PrezzoOffertaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prodotto__prezzo__58D1301D");

            entity.HasOne(d => d.PrezzoPienoRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.PrezzoPienoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prodotto__prezzo__57DD0BE4");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22533C72694B");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.CodiceUtente, "UQ__Utente__E19255D248F4D8DD").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codice_utente");
            entity.Property(e => e.Cognome)
                .HasMaxLength(100)
                .HasColumnName("cognome");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
