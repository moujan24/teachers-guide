using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
