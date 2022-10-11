using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name="Company")]
        public virtual string Name { get; set; }

        [ForeignKey("Name")]        
        public string Fuel { get; set; }
        public int Generation { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
