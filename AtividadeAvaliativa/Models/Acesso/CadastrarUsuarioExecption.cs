using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Acesso
{
    public class CadastrarUsuarioExecption :Exception
    {
        public IEnumerable<IdentityError> Erros { get; set; }

        public CadastrarUsuarioExecption(IEnumerable<IdentityError> erros)
        {
            Erros = erros;
        }
    }
}