using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("ArmeDistance", Schema = "Armes")]
    public partial class ArmeDistance
    {
        [Key]
        [Column("ArmeDistanceID")]
        public int ArmeDistanceId { get; set; }
        [Column("ArmeID")]
        public int? ArmeId { get; set; }
        public int? Porte { get; set; }
        public int? AbiliteDeTire { get; set; }

        [ForeignKey("ArmeId")]
        [InverseProperty("ArmeDistances")]
        public virtual Arme? Arme { get; set; }
    }
}
