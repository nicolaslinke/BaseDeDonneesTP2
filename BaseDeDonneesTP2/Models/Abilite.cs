using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("Abilite", Schema = "Abilites")]
    public partial class Abilite
    {
        public Abilite()
        {
            AbiliteDunites = new HashSet<AbiliteDunite>();
        }

        [Key]
        [Column("AbiliteID")]
        public int AbiliteId { get; set; }
        [StringLength(30)]
        public string? Nom { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }

        [InverseProperty("Abilite")]
        public virtual ICollection<AbiliteDunite> AbiliteDunites { get; set; }
    }
}
