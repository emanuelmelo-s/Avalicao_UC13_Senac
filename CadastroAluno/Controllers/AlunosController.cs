using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Contratos;

namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {

        private readonly ICadastroAlunoRepository _CadastroClienteRepository;

        public AlunosController(ICadastroAlunoRepository CadastroClienteRepository)
        {
            _CadastroClienteRepository = CadastroClienteRepository;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _CadastroClienteRepository.GetAlunos());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int id)
        {      

            var aluno = await _CadastroClienteRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                 await _CadastroClienteRepository.AddAluno(aluno);
                
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluno = _CadastroClienteRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await _CadastroClienteRepository.UpdateAluno(id, aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var aluno = await _CadastroClienteRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _CadastroClienteRepository.GetAlunoById(id);
            await _CadastroClienteRepository.DeleteAluno(id);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
