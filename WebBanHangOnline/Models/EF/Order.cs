using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Order")]
    public class Order
    {
        public Order() 
        { 
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key] //khoa_chinh
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ố_tự_tăng
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public decimal  TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int TypePayment { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get;set; }
    }
}