using JpWebApp.Data.Mapeamento;
using JpWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JpWebApp.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {
            CriarTabelas();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        }

        public DbSet<Aluno> Aluno { get; set; }

        public void CriarTabelas()
        {
            var createAlunoQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Aluno' AND xtype = 'U')
                CREATE TABLE Aluno (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Matricula VARCHAR(50) NOT NULL,
                    Nome VARCHAR(100) NOT NULL,
                    Cpf VARCHAR(14) NOT NULL,
                    Data_De_Nascimento DATE NOT NULL,
                    CEP VARCHAR(9) NULL,
                    Logradouro VARCHAR(100) NULL,
                    Cidade VARCHAR(100) NULL,
                    Estado VARCHAR(2) NULL,
                    Bairro VARCHAR(100) NULL,
                    Numero VARCHAR(50) NULL,
                    IdTurma INT NULL
                );
                """;
            this.Database.ExecuteSqlRaw(createAlunoQuery);

        }
    }

}
