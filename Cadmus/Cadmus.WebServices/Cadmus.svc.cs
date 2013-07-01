using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cadmus.Entities.Interfaces;
using Cadmus.Entities.Collections;
using Cadmus.Entities.Config;

namespace Cadmus.WebServices
{
    public class Cadmus : IWebService
    {
        public EstadosList GetEstados()
        {
            throw new NotImplementedException();
        }
    }
}
