using CadastroAluno.Contratos;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
  

    public class CadastroClienteRepository : ICadastroAlunoRepository
    {
        private readonly CadastroAlunoContext _context;
            
        public CadastroClienteRepository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            if (aluno == null) 
                return 0;

            aluno.AtualizarDados(alunoAlterado.Nome, alunoAlterado.Turma);
            aluno.AtualizaMedia(alunoAlterado.Media);

            _context.Entry(aluno).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(int id)
        {
            var cliente = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            _context.Aluno.Remove(cliente);
            await _context.SaveChangesAsync();
        }

    }
}
