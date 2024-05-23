using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Keyless]
    public partial class VwDataSheet
    {
        [Column("UniteID")]
        public int UniteId { get; set; }
        [StringLength(30)]
        public string? NomUnite { get; set; }
        public int? CoutEnPoint { get; set; }
        public int? NbModele { get; set; }
        [StringLength(30)]
        public string? NomModele { get; set; }
        public int? Mouvement { get; set; }
        public int? Endurance { get; set; }
        public int? Sauvegarde { get; set; }
        public int? Pv { get; set; }
        public int? Commandement { get; set; }
        public int? ControleObjectif { get; set; }
        public byte[]? Photo { get; set; }
    }
}
