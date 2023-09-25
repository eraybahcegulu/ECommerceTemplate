using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerceTemplate.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]*$", ErrorMessage = "Product Type can only contain letters.")]
        [MaxLength(25)]
        [DisplayName("Product Type")]
        public string Type { get; set; }
    }
}
