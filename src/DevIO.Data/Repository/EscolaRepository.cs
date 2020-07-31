using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Escola> ObterEscolaEndereco(Guid id)
        {
            return await Db.Escolas.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Escola> ObterEscolaTurmasEndereco(Guid id)
        {
            return await Db.Escolas.AsNoTracking()
                .Include(c => c.Turmas)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}