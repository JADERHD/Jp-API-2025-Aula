using Modelo.Aplication.Interface;
using Modelo.Domain;
using Modelo.Infra.Repositorio.interfaces;

namespace Modelo.Aplication
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<Aluno> BuscarAluno(int ID)
        {
            return await _alunoRepositorio.BuscarAluno(ID);
        }

    }
}
