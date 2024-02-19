using Dashboard.Domain.Data;
using Dashboard.Domain.ViewModels;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dashboard.Domain.Models;

namespace Dashboard.Repository.SaleRepository
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        private readonly IMapper _mapper;
        public SaleRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<SaleViewModel>> GetAll()
        {
            var sales = await _context.Sale
                .ToListAsync();

            var saleViewModels = _mapper.Map<List<SaleViewModel>>(sales);

            return saleViewModels;
        }

        public async Task<Sale> GetById(int id)
        {
            return await _context.Sale
                .Include(x => x.SaleItems)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}