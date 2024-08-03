using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Link : AbstractLink
    {
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Clicks { get; set; } = 0;
        public bool Expires { get; set; } = false;
        public DateTime? ExpirationDate { get; set; }
        public bool HasPassword { get; set; } = false;
        public string Password { get; set; } = string.Empty;
        public bool HasMessage { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        //Navegação
        public int? LinkTreeId { get; set; }
        public LinkTree LinkTree { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
