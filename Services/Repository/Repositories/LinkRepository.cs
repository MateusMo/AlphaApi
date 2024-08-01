using Services.Data;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository.Repositories
{
    public class LinkRepository : GenericRepository<Link>,ILinkRepository
    {
        public LinkRepository(AlphaContext context) : base(context)
        {
            
        }
    }
}
