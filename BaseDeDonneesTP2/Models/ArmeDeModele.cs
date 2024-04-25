using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("ArmeDeModele", Schema = "Modeles")]
    public partial class ArmeDeModele
    {
        [Key]
        [Column("ArmeDeModeleID")]
        public int ArmeDeModeleId { get; set; }
        [Column("ModeleID")]
        public int? ModeleId { get; set; }
        [Column("ArmeID")]
        public int? ArmeId { get; set; }

        [ForeignKey("ArmeId")]
        [InverseProperty("ArmeDeModeles")]
        public virtual Arme? Arme { get; set; }
        [ForeignKey("ModeleId")]
        [InverseProperty("ArmeDeModeles")]
        public virtual Modele? Modele { get; set; }
    }
}
