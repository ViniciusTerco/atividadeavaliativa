using System;
using AtividadeAvaliativa.Models.Evento;
using AtividadeAvaliativa.Models.Situacao;

namespace AtividadeAvaliativa.Models.Convidado
{
    public class ConvidadoModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public int documento { get; set; }
        public DateTime dataNascimento { get; set; }
        public EventoModel evento { get; set; }
        public ConvidadoSituacao situacao { get; set; }
        public string observacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public DateTime dataModificacao { get; set; }
        
    }
}