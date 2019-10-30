using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("loginUsuario")]
        [StringLength(100)]
        public string LoginUsuario { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(100)]
        public string Senha { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("foto")]
        [StringLength(100)]
        public string Foto { get; set; }
        [Column("departamento")]
        [StringLength(100)]
        public string Departamento { get; set; }
        [Column("tipoUsuario")]
        [StringLength(15)]
        public string TipoUsuario { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
