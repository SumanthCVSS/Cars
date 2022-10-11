using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Company
    {
        [Key]
        public string Name { get; set; }

        public string CEO { get; set; }
        public long staff { get; set; }
        public string Country { get; set; }
        public int pincode { get; set; }
    }
}
