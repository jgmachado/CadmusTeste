using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cadmus.Entities.Interfaces;
using Cadmus.Entities.Collections;
using Cadmus.WCF.Logic;
using Cadmus.Entities;

namespace Cadmus.WCF
{
    public class WcfService : IWebService
    {
        #region Estados

        public Estado GetEstado(int codigo)
        {
            return DataAccess.Instance.GetEstado(codigo);
        }

        public EstadosList GetEstados()
        {
            return DataAccess.Instance.GetEstados();
        }

        public int SaveEstado(Estado estado)
        {
            return DataAccess.Instance.SaveEstado(estado);
        }

        public int UpdateEstado(Estado estado)
        {
            return DataAccess.Instance.UpdateEstado(estado);
        }

        public void DeleteEstado(Estado estado)
        {
            DataAccess.Instance.DeleteEstado(estado);
        }

        #endregion

        #region Cidades

        public Cidade GetCidade(int codigo)
        {
            return DataAccess.Instance.GetCidade(codigo);
        }

        public CidadesList GetCidades()
        {
            return DataAccess.Instance.GetCidades();
        }

        public int SaveCidade(Cidade cidade)
        {
            return DataAccess.Instance.SaveCidade(cidade);
        }

        public int UpdateCidade(Cidade cidade)
        {
            return DataAccess.Instance.UpdateCidade(cidade);
        }

        public void DeleteCidade(Cidade cidade)
        {
            DataAccess.Instance.DeleteCidade(cidade);
        }

        #endregion

    }
}
