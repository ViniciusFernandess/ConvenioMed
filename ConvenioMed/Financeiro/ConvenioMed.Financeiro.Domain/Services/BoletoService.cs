using ConvenioMed.Financeiro.Domain.Entities;
using ConvenioMed.Financeiro.Domain.Interfaces;
using ConvenioMed.Financeiro.Domain.Interfaces.Repository;
using System;

namespace ConvenioMed.Financeiro.Domain.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _repo;

        public BoletoService(IBoletoRepository repo)
        {
            _repo = repo;
        }

        public Boleto GerarBoleto(Guid IdCliente, Guid IdMedico)
        {
            //regra de negocio pra gerar boleto 

            var valor = decimal.Parse(new Random().Next(2,200).ToString());
            var dataVenc = DateTime.Now.AddDays(5);

            var boleto = new Boleto(IdCliente, valor, dataVenc);

            return boleto;
        }

        public Boleto BaixarBoleto(Guid idBoleto)
        {
            //regra de negocio pra baixar boleto 

            var boleto = _repo.Get(idBoleto).Result;

            var estahVencido = boleto.DataVencimento.Date < DateTime.Now.Date;

            if (!estahVencido)
                boleto.DataPagamento = DateTime.Now;

            return boleto;
        }
    }
}
