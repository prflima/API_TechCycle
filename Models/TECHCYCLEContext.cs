using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_TechCycle.Models
{
    public partial class TECHCYCLEContext : DbContext
    {
        public TECHCYCLEContext()
        {
        }

        public TECHCYCLEContext(DbContextOptions<TECHCYCLEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=TECHCYCLE; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.IdAnuncio)
                    .HasName("PK__Anuncio__0BC1EC3E545340FA");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .HasConstraintName("FK__Anuncio__idAvali__440B1D61");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Anuncio__idProdu__44FF419A");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PK__Avaliaca__2A0C8312511DC80D");

                entity.Property(e => e.TipoAvaliacao).IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C9DFE59F1");

                entity.Property(e => e.NomeCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__C74515DA99B8D75C");

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdAnuncio)
                    .HasConstraintName("FK__Comentari__idAnu__47DBAE45");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comentari__idUsu__48CFD27E");
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.IdInteresse)
                    .HasName("PK__Interess__EC19CAE598BF9205");

                entity.Property(e => e.Aprovado).IsUnicode(false);

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdAnuncio)
                    .HasConstraintName("FK__Interesse__idAnu__4CA06362");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Interesse__idUsu__4BAC3F29");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__703318120882A24E");

                entity.Property(e => e.NomeMarca).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C37770BF6C");

                entity.Property(e => e.CodIdentificacao).IsUnicode(false);

                entity.Property(e => e.Modelo).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.Property(e => e.Processador).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produto__idCateg__3E52440B");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Produto__idMarca__3D5E1FD2");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A604EE73BB");

                entity.Property(e => e.Departamento).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.LoginUsuario).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.TipoUsuario).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
