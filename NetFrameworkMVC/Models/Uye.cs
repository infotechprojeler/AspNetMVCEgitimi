using System;
using System.ComponentModel.DataAnnotations;// Validation işlemleri için gerekli kütüphane
using System.ComponentModel.DataAnnotations.Schema; 

namespace NetFrameworkMVC.Models
{
    [Table(name: "Uyeler")] // Aşağıdaki uye sınıfından oluşacak olun sql tablosunun adı uyeler olsun
	public class Uye
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez!"), StringLength(50)] // Her attribute altındaki property için geçerlidir
        public string Ad { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50)]
        public string Soyad { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi"), StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Kullanıcı Adı"), StringLength(50)]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), StringLength(15, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 5)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string Sifre { get; set; }
        [Phone(ErrorMessage = "Geçersiz Telefon Formatı"), StringLength(10)]
        public string Telefon { get; set; }
        [Display(Name = "TC Kimlik Numarası"), StringLength(11)] // Ekranda TcKimlikNo yerine TC Kimlik Numarası yazısı yazsın
        [MinLength(11, ErrorMessage = "TC Numarası 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "TC Numarası 11 Karakter Olmalıdır!")]
        public string TcKimlikNo { get; set; }
        [Display(Name = "Şifreyi Tekrar Giriniz!"), StringLength(15, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 5)]
        public string SifreTekrar { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }
    }
}