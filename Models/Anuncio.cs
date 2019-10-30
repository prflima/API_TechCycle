using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Anuncio
    {
        public Anuncio()
        {
            Comentario = new HashSet<Comentario>();
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("idAnuncio")]
        public int IdAnuncio { get; set; }
        [Column("foto")]
        [StringLength(100)]
        public string Foto { get; set; }
        [Column("preco", TypeName = "decimal(5, 2)")]
        public decimal? Preco { get; set; }
        [Column("dataExpiracao", TypeName = "date")]
        public DateTime? DataExpiracao { get; set; }
        [Column("idAvaliacao")]
        public int? IdAvaliacao { get; set; }
        [Column("idProduto")]
        public int? IdProduto { get; set; }

        [ForeignKey(nameof(IdAvaliacao))]
        [InverseProperty(nameof(Avaliacao.Anuncio))]
        public virtual Avaliacao IdAvaliacaoNavigation { get; set; }
        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Anuncio))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [InverseProperty("IdAnuncioNavigation")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [InverseProperty("IdAnuncioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
