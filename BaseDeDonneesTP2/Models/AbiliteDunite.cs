using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("AbiliteDUnite", Schema = "Unites")]
    public partial class AbiliteDunite
    {
        [Key]
        [Column("AbiliteDUniteID")]
        public int AbiliteDuniteId { get; set; }
        [Column("AbiliteID")]
        public int? AbiliteId { get; set; }
        [Column("UniteID")]
        public int? UniteId { get; set; }

        [ForeignKey("AbiliteId")]
        [InverseProperty("AbiliteDunites")]
        public virtual Abilite? Abilite { get; set; }
        [ForeignKey("UniteId")]
        [InverseProperty("AbiliteDunites")]
        public virtual Unite? Unite { get; set; }
    }
}
