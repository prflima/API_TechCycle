using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("idMarca")]
        public int IdMarca { get; set; }
        [Column("nomeMarca")]
        [StringLength(50)]
        public string NomeMarca { get; set; }

        [InverseProperty("IdMarcaNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
