using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Entities.Collections;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Cadmus.Entities.Interfaces
{
    [ServiceContract]
    public interface IWebService
    {
        #region Estados

        [OperationContract]
        Estado GetEstado(int codigo);

        [OperationContract]
        EstadosList GetEstados();

        [OperationContract]
        int SaveEstado(Estado estado);

        [OperationContract]
        int UpdateEstado(Estado estado);

        [OperationContract]
        void DeleteEstado(Estado estado);

        #endregion

        #region Cidades

        [OperationContract]
        Cidade GetCidade(int codigo);

        [OperationContract]
        CidadesList GetCidades();

        [OperationContract]
        int SaveCidade(Cidade cidade);

        [OperationContract]
        int UpdateCidade(Cidade cidade);

        [OperationContract]
        void DeleteCidade(Cidade cidade);

        #endregion

    }
}
