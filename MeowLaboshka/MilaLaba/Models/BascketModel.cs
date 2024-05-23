using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MilaLaba.Models
{
    public class BascketModel
    {
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdPlant { get; set; }
        public int col { get; set; }
        public int price { get; set; }
    }
}
