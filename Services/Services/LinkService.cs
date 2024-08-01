using Services.Domain;
using Services.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _LinkRepository;

        public LinkService(ILinkRepository LinkRepository)
        {
            _LinkRepository = LinkRepository;
        }

        // Create
        public async Task<Link> CreateLink(Link Link)
        {
            return await _LinkRepository.Create(Link);
        }

        // Read
        public async Task<Link> GetLinkById(int id)
        {
            return await _LinkRepository.GetById(id);
        }

        // ReadAll
        public async Task<IEnumerable<Link>> GetAllLinks()
        {
            return await _LinkRepository.GetAll();
        }

        // Update
        public async Task<Link> UpdateLink(Link Link)
        {
            return await _LinkRepository.Update(Link);
        }

        // Delete
        public async Task DeleteLink(int id)
        {
            await _LinkRepository.Deactivate(id);
        }
    }
}
