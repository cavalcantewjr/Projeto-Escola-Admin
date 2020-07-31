using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Escola : Entity
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<Turma> Turmas { get; set; }
    }
}