using System;

namespace AtividadeAvaliativa.Models.Cliente
{
    public class ClienteModel
    {
        public string tipo { get; set; }
        public int documento { get; set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public DateTime dataModificacao { get; set; }
    }
}