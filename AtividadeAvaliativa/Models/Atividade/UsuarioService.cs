using AtividadeAvaliativa.Data;

namespace AtividadeAvaliativa.Models.Atividade
{
    public class UsuarioService
    {
        private readonly DataBaseContext _dataBaseContext;

        public UsuarioService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}