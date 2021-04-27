using System;
using AtividadeAvaliativa.Models.Cliente;
using AtividadeAvaliativa.Models.Evento;
using Buffet.Models.Acesso;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAvaliativa.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario,Papel,Guid>
    {
        public DbSet<ClienteModel> Clientes { get; set; }
        
        public DbSet<EventoModel> Eventos { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
    }
}
