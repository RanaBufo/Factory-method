using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MilaLaba.Models
{
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [property: Required]
        public int IdPerson { get; set; }

        [property: Required]
        public int IdPlant { get; set; }


        [property: Required]
        public int col { get; set; }

        [property: Required]
        public int price { get; set; }

        public Plant? Plant { get; } = null!;

        public Person? Person { get; set; } = null!;
    }
}
