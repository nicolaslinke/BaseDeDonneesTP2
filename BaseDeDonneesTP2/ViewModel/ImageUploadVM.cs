using BaseDeDonneesTP2.Models;

namespace BaseDeDonneesTP2.ViewModel
{
    public class ImageUploadVM
    {
        public IFormFile? FormFile { get; set; }

        public Unite Unite { get; set; } = null!;
    }
}
