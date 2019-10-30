using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Interesse
    {
        [Key]
        [Column("idInteresse")]
        public int IdInteresse { get; set; }
        [Column("idUsuario")]
        public int? IdUsuario { get; set; }
        [Column("idAnuncio")]
        public int? IdAnuncio { get; set; }
        [Column("aprovado")]
        [StringLength(5)]
        public string Aprovado { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(Anuncio.Interesse))]
        public virtual Anuncio IdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Interesse))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
