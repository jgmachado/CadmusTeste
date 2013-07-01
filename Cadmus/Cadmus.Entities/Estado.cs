using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Cadmus.Entities
{
    [DataContractAttribute()]
    public class Estado
    {
        [DataMember()]
        public int Codigo { get; set; }

        [DataMember()]
        [Display(Name = "País")]
        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string Pais { get; set; }

        [DataMember()]
        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string Nome { get; set; }

        [DataMember()]
        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string Sigla { get; set; }

        [DataMember()]
        [Display(Name = "Região")]
        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string Regiao { get; set; }
    }
}
