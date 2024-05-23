using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MilaLaba.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [property: Required]
        public string Name { get; set; }

        [property: Required]
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string number { get; set; }
        public string e_mail { get; set; }
        public ICollection<Basket>? Basket { get; } = new List<Basket>();

    }
}
