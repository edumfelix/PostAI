using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostAIWebAPI.Controllers.Data.ValueObject;
using PostAIWebAPI.Models;
using PostAIWebAPI.Data;

namespace PostAIWebAPI.Repository
{
    public class DadosClienteRepository : IDadosClienteRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public DadosClienteRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DadosClienteVO>> FindAll()
        {
            List<DadosCliente> dadosClientes = await _context.DadosClientes.ToListAsync();
            return _mapper.Map<List<DadosClienteVO>>(dadosClientes);
        }
        public async Task<DadosClienteVO> FindById(long id)
        {
            DadosCliente? dadosCliente = await _context.DadosClientes
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<DadosClienteVO>(dadosCliente);
        }
        public async Task<DadosClienteVO> Create(DadosClienteVO vo)
        {
            DadosCliente dadosCliente = _mapper.Map<DadosCliente>(vo);
            _context.DadosClientes.Add(dadosCliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<DadosClienteVO>(dadosCliente);
        }
        public async Task<DadosClienteVO> Update(DadosClienteVO vo)
        {
            DadosCliente dadosCliente = _mapper.Map<DadosCliente>(vo);
            _context.DadosClientes.Update(dadosCliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<DadosClienteVO>(dadosCliente);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                DadosCliente? dadosCliente = await _context.DadosClientes
                    .Where(s => s.Id == id)
                    .FirstOrDefaultAsync();

                if (dadosCliente == null) return false;

                _context.DadosClientes.Remove(dadosCliente);
                await _context.SaveChangesAsync(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
