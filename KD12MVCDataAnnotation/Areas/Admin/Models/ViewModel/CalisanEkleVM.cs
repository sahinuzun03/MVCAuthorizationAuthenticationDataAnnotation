using KD12MVCDataAnnotation.Models.Enums;
using KD12MVCDataAnnotation.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KD12MVCDataAnnotation.Attribute;

namespace KD12MVCDataAnnotation.Areas.Admin.Models.ViewModel
{
    public class CalisanEkleVM
    {

        [Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Soyad Boş Geçilemez")]
        public string KullaniciSoyadi { get; set; }

        [DataType(DataType.EmailAddress)]
        public string KullaniciMail { get; set; }

        [DataType(DataType.Password)]
        public string KullaniciSifre { get; set; }

        [DataType(DataType.DateTime)]
        [DogumTarihi(ErrorMessage = "Çalışan 18 yaşından küçük olamaz!!")]
        public DateTime KullaniciDogumTarihi { get; set; }
        public Roles KullaniciRolu { get; set; }
    }
}
