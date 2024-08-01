using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public abstract class AbstractLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Clicks { get; set; }
    }
}
