using PostAIWebAPI.Controllers.Data.ValueObject;

namespace PostAIWebAPI.Repository
{
    public interface IDadosClienteRepository
    {
        Task<IEnumerable<DadosClienteVO>> FindAll();
        Task<DadosClienteVO> FindById(long id);
        Task<DadosClienteVO> Create(DadosClienteVO vo);
        Task<DadosClienteVO> Update(DadosClienteVO vo);
        Task<bool> Delete(long id);
    }
}
