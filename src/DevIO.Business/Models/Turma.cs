using System;

namespace DevIO.Business.Models
{
    public class Turma : Entity
    {
        public Guid EscolaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Escola Escola { get; set; }
    }
}