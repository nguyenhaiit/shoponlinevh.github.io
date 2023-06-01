using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_ProductImage")]
    public class ProductImage
    {
        [Key] //khoa_chinh
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ố_tự_tăng
        public int Id { get; set; }
        public int ProductId {get; set;}
        public string Image { get; set;}
        public decimal Price { get; set;}
        public string Quantity { get; set;}
        public bool IsDefault { get; set;}
        public virtual Product Product { get; set;}
    }
}