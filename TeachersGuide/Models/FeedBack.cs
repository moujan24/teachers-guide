using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class FeedBack
    {
        public long Id { get; set; }
        public string Comment { get; set; }

        [Required]
        public string Rate { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
