using KD12MVCDataAnnotation.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KD12MVCDataAnnotation.Models.Enums;

namespace KD12MVCDataAnnotation.Models
{
    public class Calisan : IKullanici
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad Boş Geçilemez")]
        public string Soyad { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DogumTarihi { get; set; }
        public int? HastaneID { get; set; }
        public Hastane? Hastane { get; set; }
        public Roles Role { get; set; }
    }
}
