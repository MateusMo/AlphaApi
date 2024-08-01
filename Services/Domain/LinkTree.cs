using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class LinkTree : AbstractLink
    {
        //Navegação
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
