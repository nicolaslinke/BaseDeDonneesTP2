using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("Unite", Schema = "Unites")]
    public partial class Unite
    {
        public Unite()
        {
            AbiliteDunites = new HashSet<AbiliteDunite>();
            ModeleDansUnites = new HashSet<ModeleDansUnite>();
        }

        [Key]
        [Column("UniteID")]
        public int UniteId { get; set; }
        [Column("FactionID")]
        public int? FactionId { get; set; }
        [StringLength(30)]
        public string? Nom { get; set; }
        public int? CoutEnPoint { get; set; }

        [ForeignKey("FactionId")]
        [InverseProperty("Unites")]
        public virtual Faction? Faction { get; set; }
        [InverseProperty("Unite")]
        public virtual ICollection<AbiliteDunite> AbiliteDunites { get; set; }
        [InverseProperty("Unite")]
        public virtual ICollection<ModeleDansUnite> ModeleDansUnites { get; set; }
    }
}
