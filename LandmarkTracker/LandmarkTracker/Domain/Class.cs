using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkTracker.Domain
{
    public class Landmark
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
