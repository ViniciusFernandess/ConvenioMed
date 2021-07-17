using System;
using System.ComponentModel.DataAnnotations;

namespace ConvenioMed._Core.Domain.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; } 
        public DateTime DataCadastro { get; set; } 
    } 
} 
