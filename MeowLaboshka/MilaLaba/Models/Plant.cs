using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MilaLaba.Models
{
    public class Plant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [property: Required]
        public string Name { get; set; }

        [property: Required]
        public int price { get; set; }
        [property: Required]
        public int col { get; set; }
        public ICollection<Basket>? Basket { get; } = new List<Basket>();
    }
}
