using System;
using System.Runtime;
using AtividadeAvaliativa.Models.Situacao;
using AtividadeAvaliativa.Models.Tipo;

namespace AtividadeAvaliativa.Models.Evento
{
    public class EventoModel
    {
        public EventoTipo tipo { get; set; }
        public string descricao { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public string horaInicial { get; set; }
        public string horaFinal { get; set; }
        public EventoSituacao situacao { get; set; }
        public string descricaoLocal { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public DateTime dataModificacao { get; set; }
        
    }
}