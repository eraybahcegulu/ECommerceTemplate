using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceTemplate.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name cannot be left blank.")]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Features")]
        public string? Features { get; set; }

        [Required(ErrorMessage = "Product Price cannot be left blank.")]
        [Range(0, 9999999)]
        [DisplayName("Price")]
        public double Price { get; set; }


        [ForeignKey("ProductTypeId")]
        [ValidateNever]
        public ProductType ProductType { get; set; }

        [ValidateNever]
        [DisplayName("Product Type")]
        public int ProductTypeId { get; set; }

        [ValidateNever]
		[DisplayName("Product Image")]
		public string ImgUrl { get; set; }
    }
}
