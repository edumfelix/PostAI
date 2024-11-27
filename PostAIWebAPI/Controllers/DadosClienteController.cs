using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PostAIWebAPI.Controllers.Data.ValueObject;
using PostAIWebAPI.Repository;

namespace PostAIWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DadosClienteController : ControllerBase
    {
        private IDadosClienteRepository _repository;

        public DadosClienteController(IDadosClienteRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosClienteVO>>> FindAll()
        {
            var students = await _repository.FindAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DadosClienteVO>> FindById(long id)
        {
            var student = await _repository.FindById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<DadosClienteVO>> Create(DadosClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var student = await _repository.Create(vo);
            return Ok(student);
        }
        [HttpPut]
        public async Task<ActionResult<DadosClienteVO>> Update(DadosClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var student = await _repository.Update(vo);
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }

}
