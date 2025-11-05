using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain;

namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {
            
        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id) 
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.Id = id;
                aluno.Nome = "Katia";
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
