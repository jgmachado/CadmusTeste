using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Cadmus.Entities.Collections;
using Cadmus.Entities.Config;
using System.Data;
using Cadmus.Entities;
using System.Data.Common;
using System.Runtime.Serialization;
using System.IO;

namespace Cadmus.DataAccess
{
  public class EstadosDB
  {
    public Estado GetEstado(int codigo)
    {
        Estado temp = null;
        try
        {
            using (var conn = new SqlConnection(Config.DbConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT Codigo, Pais, Nome, Sigla, Regiao FROM Estados WHERE Codigo = @Codigo";
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            temp = FillDataRecord(reader);
                        }
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return temp;
    }


    public EstadosList GetEstados()
    {
        EstadosList tempList = null;
        try
        {
            using (var conn = new SqlConnection(Config.DbConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT Codigo, Pais, Nome, Sigla, Regiao FROM Estados";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        tempList = new EstadosList();
                        while (reader.Read())
                        {
                            tempList.Add(FillDataRecord(reader));
                        }
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return tempList;
    }

    public int SaveEstado(Estado estado)
    {
        int result = 0;

        using (SqlConnection conn = new SqlConnection(Config.DbConnectionString))
        {
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = transaction;

                    cmd.CommandText = "INSERT INTO Estados (Pais, Nome, Sigla, Regiao) VALUES (@Pais, @Nome, @Sigla, @Regiao)";

                    //cmd.Parameters.AddWithValue("@Codigo", estado.Codigo);
                    cmd.Parameters.AddWithValue("@Pais", estado.Pais);
                    cmd.Parameters.AddWithValue("@Nome", estado.Nome);
                    cmd.Parameters.AddWithValue("@Sigla", estado.Sigla);
                    cmd.Parameters.AddWithValue("@Regiao", estado.Regiao);

                    DbParameter returnValue;
                    returnValue = cmd.CreateParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    result = Convert.ToInt32(returnValue.Value);
                    conn.Close();

                    SerializeXML(estado);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }

        return result;
    }

    public int UpdateEstado(Estado estado)
    {
        int result = 0;
        using (SqlConnection conn = new SqlConnection(Config.DbConnectionString))
        {
            SqlTransaction transaction = null;
           

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = transaction;

                    cmd.CommandText = "UPDATE Estados SET Pais = @Pais, Nome = @Nome, Sigla = @Sigla, Regiao = @Regiao WHERE Codigo = @Codigo";

                    cmd.Parameters.AddWithValue("@Codigo", estado.Codigo);
                    cmd.Parameters.AddWithValue("@Pais", estado.Pais);
                    cmd.Parameters.AddWithValue("@Nome", estado.Nome);
                    cmd.Parameters.AddWithValue("@Sigla", estado.Sigla);
                    cmd.Parameters.AddWithValue("@Regiao", estado.Regiao);

                    DbParameter returnValue;
                    returnValue = cmd.CreateParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    result = Convert.ToInt32(returnValue.Value);
                    conn.Close();

                    SerializeXML(estado);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }
        return result;
    }

    public void DeleteEstado(Estado estado)
    {
        using (SqlConnection conn = new SqlConnection(Config.DbConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            try
            {
                cmd.CommandText = "DELETE FROM Estados WHERE Codigo = @Codigo";

                cmd.Parameters.AddWithValue("@Codigo", estado.Codigo);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                SerializeXML(estado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    private static void SerializeXML(Estado estado)
    {
        using (FileStream writer = new FileStream("c:/temp/cadmusEstado.xml", FileMode.Append, FileAccess.Write))
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Estado));
            ser.WriteObject(writer, estado);
        }
    }

    private static Estado FillDataRecord(IDataRecord myDataRecord)
    {
        var estado = new Estado
        {
            Codigo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Codigo")),
            Nome = myDataRecord.GetString(myDataRecord.GetOrdinal("Nome")),
            Pais = myDataRecord.GetString(myDataRecord.GetOrdinal("Pais")),
            Regiao = myDataRecord.GetString(myDataRecord.GetOrdinal("Regiao")),
            Sigla = myDataRecord.GetString(myDataRecord.GetOrdinal("Sigla")),
        };

        return estado;
    }

  }
}
