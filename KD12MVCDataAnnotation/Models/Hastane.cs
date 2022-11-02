using System.ComponentModel.DataAnnotations;

namespace KD12MVCDataAnnotation.Models
{
    public class Hastane
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hastane Adı Boş Geçilemez")]
        public string HastaneAdı { get; set; }
        public List<Calisan> Calisanlar { get; set; }
        public Hastane()
        {
            Calisanlar = new List<Calisan>();
        }

    }
}
