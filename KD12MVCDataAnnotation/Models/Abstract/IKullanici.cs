using KD12MVCDataAnnotation.Models.Enums;

namespace KD12MVCDataAnnotation.Models.Abstract
{
    public interface IKullanici
    {
        int Id { get; set; }
        string Ad { get; set; }
        string Soyad { get; set; }
        string EmailAdress { get;set; }
        string Sifre { get; set; }
        DateTime DogumTarihi { get; set; }

        Roles Role { get;set;}
    }
}
