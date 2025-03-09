using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NetCoreMVC.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Display(Name = "Gönderi Adı"), StringLength(150)]
        public string Name { get; set; }
        [Display(Name = "İçerik")]
        public string? Content { get; set; }
        [Display(Name = "Resim"), StringLength(150)]
        public string? Image { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public Category? Category { get; set; } // 1 postun 1 tane kategorisi olacak
    }
}
