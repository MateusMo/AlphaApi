using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ILinkTreeService
    {
        Task<LinkTree> CreateLinkTree(LinkTree LinkTree);
        Task<LinkTree> GetLinkTreeById(int id);
        Task<IEnumerable<LinkTree>> GetAllLinkTrees();
        Task<LinkTree> UpdateLinkTree(LinkTree LinkTree);
        Task DeleteLinkTree(int id);
    }
}
