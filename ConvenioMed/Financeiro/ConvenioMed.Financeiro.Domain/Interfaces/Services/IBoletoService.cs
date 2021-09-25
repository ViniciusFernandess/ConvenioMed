using ConvenioMed.Financeiro.Domain.Entities;
using System;

namespace ConvenioMed.Financeiro.Domain.Interfaces
{
    public interface IBoletoService
    {
        Boleto GerarBoleto(Guid idCliente, Guid idMedico);
        Boleto BaixarBoleto(Guid idBoleto);
    }
}
