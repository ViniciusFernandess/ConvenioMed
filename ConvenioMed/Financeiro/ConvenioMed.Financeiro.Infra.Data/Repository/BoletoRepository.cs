using ConvenioMed._Core.Infra.Data.Repository;
using ConvenioMed.Financeiro.Domain.Entities;
using ConvenioMed.Financeiro.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.Infra.Data.Repository
{
    public class BoletoRepository : RepositoryBase<Boleto>, IBoletoRepository
    {
        public async Task<Boleto> Get(Guid id)
        {
            var boleto = new Boleto(Guid.NewGuid(), 10, DateTime.Now.AddDays(5));
            boleto.Id = Guid.NewGuid();
            boleto.DataCadastro = DateTime.Now;

            return boleto;
        }
    }
}
