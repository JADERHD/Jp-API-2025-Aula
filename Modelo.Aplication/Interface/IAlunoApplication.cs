using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Domain;

namespace Modelo.Aplication.Interface
{
    public interface IAlunoApplication
    {
        Task<Aluno> BuscarAluno(int ID);
    }
}
