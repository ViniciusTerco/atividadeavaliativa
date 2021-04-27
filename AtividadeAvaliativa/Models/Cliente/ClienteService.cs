using System.Collections.Generic;
using System.Linq;
using AtividadeAvaliativa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AtividadeAvaliativa.Models.Cliente
{
    public class ClienteService
    {

        private readonly DataBaseContext _dataBaseContext;

        public ClienteService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<ClienteModel> ObterClientes()
        {
            return _dataBaseContext.Clientes
                .Include(ClienteModel => ClienteModel.Eventos)
                .ToList();
        }

        public List<ClienteModel> ObterClientesComFiltro(string filtroNome, string filtroEmail, bool apenasComEventos)
        {
            var listaClientes = _dataBaseContext.Clientes
                .Include(model => model.Eventos)
                .AsQueryable();
                

            if (filtroNome != null)
            {
                listaClientes = listaClientes.Where(model => model.nome.Contains(filtroNome));
            }
            
            if (filtroEmail != null)
            {
                listaClientes = listaClientes.Where(model => model.email.Contains(filtroEmail));
            }
            
            if (apenasComEventos != null)
            {
                listaClientes = listaClientes.Where(model => model.Eventos.Count > 0);
            }
            
            return listaClientes.ToList();
        }
    }
}