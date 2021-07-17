using System.Collections.Generic;

namespace ConvenioMed._Core.Domain.Entities
{
    public class RequestResult
    {
        public RequestResult(bool sucesso, List<string> erros)
        {
            Sucesso = sucesso;
            Erros = erros;
        } 

        public bool Sucesso { get; set; } 
        public List<string> Erros { get; set; }  
    } 
} 
