using System;

namespace AtividadeAvaliativa.Models.Teste
{
    public class TesteService
    {
        public void RealizaAlgumaOperacao(string texto)
        {
            if (texto.Equals("Dar Erro"))
            {
                throw new Exception("Deu Erro");
            }
        }
    }
}