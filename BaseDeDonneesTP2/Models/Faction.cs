using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("Faction", Schema = "Factions")]
    public partial class Faction
    {
        public Faction()
        {
            Unites = new HashSet<Unite>();
        }

        [Key]
        [Column("FactionID")]
        public int FactionId { get; set; }
        [StringLength(30)]
        public string? Nom { get; set; }

        [InverseProperty("Faction")]
        public virtual ICollection<Unite> Unites { get; set; }
    }
}
