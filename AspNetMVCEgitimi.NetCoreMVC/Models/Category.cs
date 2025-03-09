using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NetCoreMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(150)]
        public string Name { get; set; }
        [Display(Name = "Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Resim"), StringLength(150)]
        public string? Image { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public IList<Post>? Posts { get; set; } // 1 kategorinin birden fazla postu olabilir.
    }
}
