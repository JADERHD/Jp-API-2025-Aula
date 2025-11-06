using Modelo.Domain;

namespace Modelo.Infra.Repositorio.interfaces
{
    public interface IAlunoRepositorio
    {
        IEnumerable<Aluno> GetAlunos();

        IEnumerable<Aluno> GetAlunosComNome(string buscar);

        Task<Aluno> BuscarAluno(int ID);

        void NovoAluno(Aluno aluno);

        void AtualizarAluno(Aluno aluno);

        void Excluir(Aluno aluno);
    }
}
