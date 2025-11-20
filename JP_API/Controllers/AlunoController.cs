using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        private readonly ICepService _cepService;
     
        public AlunoController(IAlunoApplication alunoApplication, ICepService cepService)
        {
            _alunoApplication = alunoApplication;
            _cepService = cepService;
        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id) 
        {
            try
            {
                Aluno aluno = await _alunoApplication.BuscarAluno(id);
                Retorno<Aluno> retorno = new Retorno<Aluno>(aluno, true, "Aluno retornado com sucesso!", 200);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Retorno retorno = new Retorno(false, "Erro ao retornar os alunos!", 400);
                return BadRequest(retorno);
            }

        }

        [HttpPost("AdicionarAluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody]Aluno aluno)
        {
            try
            {
                await _alunoApplication.AdicionarAluno(aluno);
                Retorno<Aluno> retorno = new Retorno<Aluno>(aluno, true, "Aluno criado com sucesso!", 200);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Retorno retorno = new Retorno(false, "Erro ao adicionar o aluno!", 400);
                return BadRequest(retorno);
            }

        }
        [HttpPatch("AtualizarAluno")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno)
        {
            try
            {
                var aluno1 = await _alunoApplication.AtualizarAluno(aluno);
                Retorno<Aluno> retorno = new Retorno<Aluno>(aluno1, true, "Aluno editado com sucesso!", 200);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                Retorno retorno = new Retorno(false, "Erro ao editar o aluno!", 400);
                return BadRequest(retorno);
            }

        }

        [HttpDelete("DeletarAluno/{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            try
            {
                bool res = await _alunoApplication.Excluir(id);

                var cont = (new { FoiExcluido = res });
                Retorno<object> retorno = new Retorno<object>( cont, true, "Aluno excluido com sucesso!", 200);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Retorno retorno = new Retorno(false, "Erro ao excluido o aluno!", 400);
                return BadRequest(retorno);
            }

        }



        [HttpGet("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep) 
        {

            try
            {
                var endereco = await _cepService.BuscarfEnderecoPorCep(cep);
                Retorno<Endereco> retorno = new Retorno<Endereco>(endereco, true, "Busca Realizada com Sucesso", 200);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Retorno retorno = new Retorno(false, "Erro ao buscar CEP", 400);
                return BadRequest(retorno);
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
