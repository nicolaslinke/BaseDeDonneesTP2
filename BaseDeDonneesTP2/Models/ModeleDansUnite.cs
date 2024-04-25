using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Table("ModeleDansUnite", Schema = "Unites")]
    public partial class ModeleDansUnite
    {
        [Key]
        [Column("ModeleDansUniteID")]
        public int ModeleDansUniteId { get; set; }
        [Column("UniteID")]
        public int? UniteId { get; set; }
        [Column("ModeleID")]
        public int? ModeleId { get; set; }
        public int? NbModele { get; set; }

        [ForeignKey("ModeleId")]
        [InverseProperty("ModeleDansUnites")]
        public virtual Modele? Modele { get; set; }
        [ForeignKey("UniteId")]
        [InverseProperty("ModeleDansUnites")]
        public virtual Unite? Unite { get; set; }
    }
}
