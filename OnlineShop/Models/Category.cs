using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CategoryId { get; set; }
        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string CategoryName { get; set; }
    }
}