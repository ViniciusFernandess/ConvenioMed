using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace ConvenioMed._Core.Domain.Commands
{
    public abstract class Command<T> : IRequest<T>
    {
        private readonly List<string> Erros = new List<string>();

        public bool IsValid()
        {
            return !Erros.Any(); 
        } 

        public List<string> GetErros()
        {
            return Erros;
        } 

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        } 
    } 
} 
