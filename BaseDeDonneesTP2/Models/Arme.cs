using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("Arme", Schema = "Armes")]
    public partial class Arme
    {
        public Arme()
        {
            ArmeDeModeles = new HashSet<ArmeDeModele>();
            ArmeDistances = new HashSet<ArmeDistance>();
            ArmeRapproches = new HashSet<ArmeRapproche>();
        }

        [Key]
        [Column("ArmeID")]
        public int ArmeId { get; set; }
        [StringLength(30)]
        public string? Nom { get; set; }
        public int? Attaques { get; set; }
        public int? Force { get; set; }
        [Column("PenetrationDArmure")]
        public int? PenetrationDarmure { get; set; }
        public int? Degats { get; set; }

        [InverseProperty("Arme")]
        public virtual ICollection<ArmeDeModele> ArmeDeModeles { get; set; }
        [InverseProperty("Arme")]
        public virtual ICollection<ArmeDistance> ArmeDistances { get; set; }
        [InverseProperty("Arme")]
        public virtual ICollection<ArmeRapproche> ArmeRapproches { get; set; }
    }
}
