using BaseDeDonneesTP2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BaseDeDonneesTP2.ViewModel
{
    public class FiltreUnitesVM
    {
        public List<VwAttributsDunite> Unites { get; set; } = null!;

        public string Faction { get; set; } = "Toutes";

        public List<SelectListItem> Factions { get; } = new List<SelectListItem>
        {
            new SelectListItem{ Value = "Toutes", Text = "Toutes"},
            new SelectListItem{ Value = "Space Marines", Text = "Space Marines"},
            new SelectListItem{ Value = "Chaos Space Marines", Text = "Chaos Space Marines"},
            new SelectListItem{ Value = "Astra Militarum", Text = "Astra Militarum"},
            new SelectListItem{ Value = "Adeptus Mechanicus", Text = "Adeptus Mechanicus"},
            new SelectListItem{ Value = "Adepta Sororitas", Text = "Adepta Sororitas"},
            new SelectListItem{ Value = "Aeldari", Text = "Aeldari"},
        };

        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        public string Ordre { get; set; } = "Faction";
        public List<SelectListItem> Ordres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Faction", Text = "Par faction" },
            new SelectListItem { Value = "CoutEnPoint", Text = "Par coût en point" },
            new SelectListItem { Value = "NomUnite", Text = "Par nom d'unité" }
        };
        public string TypeOrdre { get; set; } = "DESC";

        public List<SelectListItem> TypesOrdre { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "ASC", Text = "Croissant" },
            new SelectListItem { Value = "DESC", Text = "Décroissant" }
        };

        public string? NomUnite { get; set; }
    }
}
