using Services.Domain;
using Services.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LinkTreeService : ILinkTreeService
    {
        private readonly ILinkTreeRepository _LinkTreeRepository;

        public LinkTreeService(ILinkTreeRepository LinkTreeRepository)
        {
            _LinkTreeRepository = LinkTreeRepository;
        }

        // Create
        public async Task<LinkTree> CreateLinkTree(LinkTree LinkTree)
        {
            return await _LinkTreeRepository.Create(LinkTree);
        }

        // Read
        public async Task<LinkTree> GetLinkTreeById(int id)
        {
            return await _LinkTreeRepository.GetById(id);
        }

        // ReadAll
        public async Task<IEnumerable<LinkTree>> GetAllLinkTrees()
        {
            return await _LinkTreeRepository.GetAll();
        }

        // Update
        public async Task<LinkTree> UpdateLinkTree(LinkTree LinkTree)
        {
            return await _LinkTreeRepository.Update(LinkTree);
        }

        // Delete
        public async Task DeleteLinkTree(int id)
        {
            await _LinkTreeRepository.Deactivate(id);
        }
    }
}
