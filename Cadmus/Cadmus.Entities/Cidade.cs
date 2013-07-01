using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cadmus.Entities
{
    [DataContractAttribute()]
    public class Cidade
    {
        [DataMember()]
        public int Codigo { get; set; }

        [DataMember()]
        public string Estado { get; set; }

        [DataMember()]
        public int codEstado { get; set; }

        [DataMember()]
        public string Nome { get; set; }

        [DataMember()]
        public bool Capital { get; set; }
    }
}
