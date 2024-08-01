using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Ranking
    {
        public int Id { get; set; }
        public int Photo { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public int Clicks { get; set; }
    }
}
