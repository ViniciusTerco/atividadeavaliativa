using System;
using System.Collections.Generic;
using AtividadeAvaliativa.Models.Evento;

namespace AtividadeAvaliativa.Models.Cliente
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string tipo { get; set; }
        public int documento { get; set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public DateTime dataModificacao { get; set; }
        public ICollection<EventoModel> Eventos { get; set; }
        public string email { get; set; }

        public ClienteModel()
        {
            Id = new Guid();
            Eventos = new List<EventoModel>();
        }
    }
}