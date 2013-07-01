using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Entities.Config;
using Cadmus.Entities.Interfaces;
using Cadmus.Entities.Collections;
using Cadmus.Entities;

namespace Cadmus.Business
{
    public class EstadosPlatform : BaseWebServicePlatform<IWebService>
    {
        static EstadosPlatform _instance;
        public static EstadosPlatform Instance
        {
            get
            {
                return (_instance ?? (_instance = new EstadosPlatform()));
            }
        }

        public EstadosPlatform()
            : base(Config.WebServicesCadmusUrl)
        {
        }

        public EstadosList GetEstados()
        {
            return wcf.GetEstados();
        }

        public Estado GetEstado(int codigo)
        {
            return wcf.GetEstado(codigo);
        }

        public int SaveEstado(Estado estado)
        {
            return wcf.SaveEstado(estado);
        }

        public int UpdateEstado(Estado estado)
        {
            return wcf.UpdateEstado(estado);
        }

        public void DeleteEstado(Estado estado)
        {
            wcf.DeleteEstado(estado);
        }

  }
}
