using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDonneesTP2.Models
{
    [Keyless]
    [Table("Description", Schema = "Abilites")]
    public partial class Description
    {
        [Column("Description")]
        public string? Description1 { get; set; }
    }
}
