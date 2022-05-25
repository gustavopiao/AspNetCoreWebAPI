using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplina { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<AlunoDisciplina>().HasKey(AD => new{AD.AlunoId , AD.DisciplinaId});
        }
    }
}