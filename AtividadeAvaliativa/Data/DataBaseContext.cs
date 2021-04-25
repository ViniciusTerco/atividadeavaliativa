using Microsoft.EntityFrameworkCore;

namespace AtividadeAvaliativa.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
    }
}
