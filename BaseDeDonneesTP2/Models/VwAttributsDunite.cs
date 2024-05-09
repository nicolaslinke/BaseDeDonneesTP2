using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Keyless]
    public partial class VwAttributsDunite
    {
        [Column("UniteID")]
        public int UniteId { get; set; }
        [Column("Nom de faction")]
        [StringLength(30)]
        public string? NomDeFaction { get; set; }
        [Column("Nom de l'unit�")]
        [StringLength(30)]
        public string? NomDeLUnit { get; set; }
        [Column("Co�t en point")]
        public int? CoTEnPoint { get; set; }
        [Column("FactionID")]
        public int? FactionId { get; set; }
    }
}
