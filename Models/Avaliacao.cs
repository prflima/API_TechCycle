using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Anuncio = new HashSet<Anuncio>();
        }

        [Key]
        [Column("idAvaliacao")]
        public int IdAvaliacao { get; set; }
        [Column("descricaoAvaliacao", TypeName = "text")]
        public string DescricaoAvaliacao { get; set; }
        [Column("tipoAvaliacao")]
        [StringLength(15)]
        public string TipoAvaliacao { get; set; }

        [InverseProperty("IdAvaliacaoNavigation")]
        public virtual ICollection<Anuncio> Anuncio { get; set; }
    }
}
