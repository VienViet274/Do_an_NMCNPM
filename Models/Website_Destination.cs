using System.ComponentModel.DataAnnotations;

namespace Do_an_NMCNPM.Models
{
    public class Website_Destination
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Website_Link { get; set; }
    }
}
