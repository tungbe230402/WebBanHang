using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Adv")]
    public class Advs : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tham số tự tăng 1,2,3...
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }
        public string Description { get; set; }
        
        [AllowHtml]
        public string Detail { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string Link { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
    }
}