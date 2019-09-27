using System.ComponentModel.DataAnnotations;

namespace TeachersGuide.Models
{
    public class InterventionsModified
    {
        public long id { get; set; }

        [Required]
        public long BPTid { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string interventionKey { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string articleLink { get; set; }

    }
}
