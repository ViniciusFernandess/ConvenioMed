using ConvenioMed._Core.Domain.Entities;
using System;

namespace ConvenioMed.Financeiro.Domain.Entities
{
    public class Boleto : Entity
    {
        public decimal Valor { get; set; } 
        public DateTime DataVencimento { get; set; } 
        public DateTime? DataPagamento { get; set; } 
    } 
} 
