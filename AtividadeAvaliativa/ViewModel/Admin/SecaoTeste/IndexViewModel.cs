using System.Collections;
using System.Collections.Generic;

namespace AtividadeAvaliativa.ViewModel.Admin
{
    public class IndexViewModel
    {
        
        public string FormMensagemSucesso { get; set; }
        
        public string[] FormMensagensErro { get; set; }

        public ICollection<Cliente> ListaCliente { get; set; }

        public Filtros Filtro { get; set; }

        public IndexViewModel()
        {
            ListaCliente = new List<Cliente>();
        }
        
        public class Cliente
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string QtdEventos { get; set; }
            
        }
        
        public class Filtros
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public bool ApenasComEventos { get; set; }
        }
    }
}