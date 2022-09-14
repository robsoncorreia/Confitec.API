using Confitec.Entidade.Mensagem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Entidade.Entidade
{
    public class Usuario : Notifica
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
