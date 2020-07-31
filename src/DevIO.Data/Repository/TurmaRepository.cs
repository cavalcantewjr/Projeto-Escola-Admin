using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(MeuDbContext context) : base(context) { }


        public async Task<Turma> ObterTurmaEscola(Guid id)
        {
            return await Db.Turmas.AsNoTracking().Include(f => f.Escola)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Turma>> ObterTurmaPorEscola(Guid id)
        {
            return await Db.Turmas.AsNoTracking().Include(f => f.Escola)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public Task<IEnumerable<Turma>> ObterTurmasEscola()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Turma>> ObterTurmasEscola()
        //{
        //    return await Buscar(p => p.Id == );
        //}
    }
}