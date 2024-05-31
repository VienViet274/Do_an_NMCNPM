using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_NMCNPM.Models
{
    public class Conference
    {
        [Key]
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? URLnextPage { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Venue { get; set; }
        public string? ConferenceDates { get; set; }
        public string? Deadline { get; set; }
        public string? Category { get; set; }
        public string? Topics { get; set; }
        public string? Organizer { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public int WebsiteCraw_ID { get; set; }
        [ForeignKey("WebsiteCraw_ID")]
        public Website_Destination Web_Des { get; set; }

    }
}
