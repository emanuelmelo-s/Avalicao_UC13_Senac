using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contratos
{
    public interface ICadastroAlunoRepository
    {
        Task<List<Aluno>> GetAlunos();

        Task<Aluno> GetAlunoById(int id);

        Task<Aluno> AddAluno(Aluno aluno);

        Task<int> UpdateAluno(int id, Aluno alunoAlterado);

        Task DeleteAluno(int id);
    }
}
