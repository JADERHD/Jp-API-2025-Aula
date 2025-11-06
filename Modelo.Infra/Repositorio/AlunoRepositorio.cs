using Dapper;
using Modelo.Domain;
using Modelo.Infra.Repositorio.interfaces;

namespace Modelo.Infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        DbConnectionFactory _dbConnectionFactory;

        public AlunoRepositorio(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void AtualizarAluno(Aluno aluno)
        {
         
        }

        public void Excluir(Aluno aluno)
        {
        
        }

        public async Task<Aluno> BuscarAluno(int ID)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "select * from Aluno where Id = @Id";

            var aluno = await connnection.QueryFirstOrDefaultAsync<Aluno>(sql, new { Id = ID });

            return aluno;
        }

        public IEnumerable<Aluno> GetAlunos()
        {
           return null;
        }

        public void NovoAluno(Aluno aluno)
        {
        }

        public IEnumerable<Aluno> GetAlunosComNome(string buscar)
        {
            return null;
        }
    }
}
