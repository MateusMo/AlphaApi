using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Post
    {
        public int Id { get; set; }
        //Navegação
        public int UserId { get; set; }
        public User User { get; set; }
        public int? LinkId { get; set; }
        public Link? Link { get; set; }
        public int? LinkTreeId { get; set; }
        public LinkTree? LinkTree { get; set; }
    }
}
