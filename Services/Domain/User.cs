using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }
        public bool IsPremium { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Navegação
        public ICollection<LinkTree> LinkTrees { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
