using ConvenioMed._Core.Domain.Entities;
using System;

namespace ConvenioMed.Financeiro.Domain.Entities
{
    public class Boleto : Entity
    {
        public Boleto(Guid idCliente, decimal valor, DateTime dataVencimento)
        {
            IdCliente = idCliente;
            Valor = valor;
            DataVencimento = dataVencimento;
        }

        public Guid IdCliente { get; set; }
        public decimal Valor { get; set; } 
        public DateTime DataVencimento { get; set; } 
        public DateTime? DataPagamento { get; set; } 
    } 
} 
