using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression(@"^([0-9a-zA-Z,&])+$", ErrorMessage = "Product Category can only contain letters, numbers, comma(,) and empersand(&)")]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1-100 item(s).")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(250)]
        public string ShortDesc { get; set; }

        [StringLength(1000)]
        public string LongDesc { get; set; }

        [ScaffoldColumn(false)]
        public string ProductImagePath { get; set; }

        [NotMapped]
        [FileExtensions("jpg,jpeg,png", ErrorMessage = "Only .jpg, .jpeg, and .png extensions are allowed.")]
        public HttpPostedFileBase ProductImage { get; set; }

        [Phone]
        public string DealerPhone { get; set; }

        [ProductRegion("Asia, Europe")]
        public string ProductRegion { get; set; } //in which regions the product is currently available
    }
}