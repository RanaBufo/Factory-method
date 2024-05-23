using System.ComponentModel.DataAnnotations;

namespace MilaLaba.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Date { get; set; }
        public string number { get; set; }
        public string e_mail { get; set; }
    }
}
