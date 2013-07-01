using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Entities.Collections;
using Cadmus.DataAccess;
using Cadmus.Entities;

namespace Cadmus.WCF.Logic
{
    public class DataAccess
    {
        static DataAccess _instance;
        public static DataAccess Instance
        {
            get
            {
                return (_instance ?? (_instance = new DataAccess()));
            }
        }

        private EstadosDB dbEstado;
        private CidadesDB dbCidade;

        public DataAccess()
        {
            dbEstado = new EstadosDB();
            dbCidade = new CidadesDB();
        }

        #region Estado

        public EstadosList GetEstados()
        {
            return dbEstado.GetEstados();
        }

        public Estado GetEstado(int codigo)
        {
            return dbEstado.GetEstado(codigo);
        }

        public int SaveEstado(Estado estado)
        {
            return dbEstado.SaveEstado(estado);
        }

        public int UpdateEstado(Estado estado)
        {
            return dbEstado.UpdateEstado(estado);
        }

        public void DeleteEstado(Estado estado)
        {
            dbEstado.DeleteEstado(estado);
        }

        #endregion

        #region Cidades

        public CidadesList GetCidades()
        {
            return dbCidade.GetCidades();
        }

        public Cidade GetCidade(int codigo)
        {
            return dbCidade.GetCidade(codigo);
        }

        public int SaveCidade(Cidade cidade)
        {
            return dbCidade.SaveCidade(cidade);
        }

        public int UpdateCidade(Cidade cidade)
        {
            return dbCidade.UpdateCidade(cidade);
        }

        public void DeleteCidade(Cidade cidade)
        {
            dbCidade.DeleteCidade(cidade);
        }

        #endregion
    }
}
