using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Subscribe")]
    public class Subscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tham số tự tăng 1,2,3...
        public int Id { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Bạn bắt buộc phải nhập Email!")]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}