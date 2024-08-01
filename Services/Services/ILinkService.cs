using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ILinkService
    {
        Task<Link> CreateLink(Link Link);
        Task<Link> GetLinkById(int id);
        Task<IEnumerable<Link>> GetAllLinks();
        Task<Link> UpdateLink(Link Link);
        Task DeleteLink(int id);
    }
}
