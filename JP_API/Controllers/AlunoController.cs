using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Aplication.Interface;
using Modelo.Domain;

namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;

        public AlunoController(IAlunoApplication alunoRepositorio)
        {
            _alunoApplication = alunoRepositorio;
        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id) 
        {
            try
            {
                Aluno aluno = await _alunoApplication.BuscarAluno(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /*
        [HttpGet("aa")]
        public string AA() 
        {
            return "aa";
        }
        */

    }
}
