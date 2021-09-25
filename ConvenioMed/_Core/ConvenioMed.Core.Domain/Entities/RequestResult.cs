using System.Collections.Generic;

namespace ConvenioMed._Core.Domain.Entities
{
    public class RequestResult
    {
        public RequestResult(bool sucesso, string mensagem, List<string> erros)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Erros = erros;
        }

        public bool Sucesso { get; set; } 
        public string Mensagem { get; set; }  
        public List<string> Erros { get; set; }
    } 
} 
