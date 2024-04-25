using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("ArmeRapproche", Schema = "Armes")]
    public partial class ArmeRapproche
    {
        [Key]
        [Column("ArmeRapprocheID")]
        public int ArmeRapprocheId { get; set; }
        [Column("ArmeID")]
        public int? ArmeId { get; set; }
        public int? AbiliteDeFrappe { get; set; }

        [ForeignKey("ArmeId")]
        [InverseProperty("ArmeRapproches")]
        public virtual Arme? Arme { get; set; }
    }
}
