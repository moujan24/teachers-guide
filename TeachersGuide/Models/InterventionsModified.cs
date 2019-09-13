using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class InterventionsModified
    {
        public long id { get; set; }

        public long BPTid { get; set; }

        public string title { get; set; }

        public string interventionKey { get; set; }

        public string description { get; set; }

        public string articleLink { get; set; }
    }
}
