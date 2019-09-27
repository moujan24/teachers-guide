using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersGuide.Models;

namespace TeachersGuide.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<FeedBack> feedBacks { get; set; }
    }
}
