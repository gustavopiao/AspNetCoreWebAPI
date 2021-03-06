using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {        
        public readonly IRepository _repo;
        public AlunoController(IRepository repository) { 
            _repo = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            
            if (_repo.SaveChanges()){
                return Ok(aluno);
            }
                                        
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest ("Aluno não encontrado");

            _repo.Update(aluno);
            
            if (_repo.SaveChanges()){
                return Ok(aluno);
            }
                                        
            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest ("Aluno não encontrado");

            _repo.Update(aluno);
            
            if (_repo.SaveChanges()){
                return Ok(aluno);
            }
                                        
            return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest ("Aluno não encontrado");

            _repo.Delete(aluno);
            
            if (_repo.SaveChanges()){
                return Ok("Aluno removido");
            }
                                        
            return BadRequest("Aluno não removido");
        }
    }
}