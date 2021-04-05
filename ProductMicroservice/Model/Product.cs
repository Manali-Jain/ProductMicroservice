using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(12,3)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
