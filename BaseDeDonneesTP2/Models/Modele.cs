using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("Modele", Schema = "Modeles")]
    public partial class Modele
    {
        public Modele()
        {
            ArmeDeModeles = new HashSet<ArmeDeModele>();
            ModeleDansUnites = new HashSet<ModeleDansUnite>();
        }

        [Key]
        [Column("ModeleID")]
        public int ModeleId { get; set; }
        [StringLength(30)]
        public string? Nom { get; set; }
        public int? Endurance { get; set; }
        public int? Pv { get; set; }
        public int? Mouvement { get; set; }
        public int? Commandement { get; set; }
        public int? Sauvegarde { get; set; }
        public int? Co { get; set; }

        [InverseProperty("Modele")]
        public virtual ICollection<ArmeDeModele> ArmeDeModeles { get; set; }
        [InverseProperty("Modele")]
        public virtual ICollection<ModeleDansUnite> ModeleDansUnites { get; set; }
    }
}
