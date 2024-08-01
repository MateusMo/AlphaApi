using Services.Data;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository.Repositories
{
    public class LinkTreeRepository : GenericRepository<LinkTree>,ILinkTreeRepository
    {
        public LinkTreeRepository(AlphaContext context) : base(context)
        {
            
        }
    }
}
