﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Drawing.Printing;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product() 
        { 
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key] //hoa_chinh
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //số_tự_tăng
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [AllowHtml]

        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }    
        public bool IsSale { get; set; }    
        public bool Feature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }
        [StringLength(250)]
        public string SaleTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}