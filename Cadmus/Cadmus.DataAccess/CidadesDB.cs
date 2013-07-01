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
    public class CidadesDB
    {
        public Cidade GetCidade(int codigo)
        {
            Cidade temp = null;
            try
            {
                using (var conn = new SqlConnection(Config.DbConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT c.Codigo, e.Nome as Estado, e.Codigo as codEstado, c.Nome, c.Capital FROM Cidades c INNER JOIN Estados e ON c.Estado = e.Codigo WHERE c.Codigo = @Codigo";
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


        public CidadesList GetCidades()
        {
            CidadesList tempList = null;
            try
            {
                using (var conn = new SqlConnection(Config.DbConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT c.Codigo, e.Nome as Estado, e.Codigo as codEstado, c.Nome, c.Capital FROM Cidades c INNER JOIN Estados e ON c.Estado = e.Codigo";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            tempList = new CidadesList();
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

        public int SaveCidade(Cidade cidade)
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

                        cmd.CommandText = "INSERT INTO Cidades (Estado, Nome, Capital) VALUES (@Estado, @Nome, @Capital)";

                        //cmd.Parameters.AddWithValue("@Codigo", estado.Codigo);
                        cmd.Parameters.AddWithValue("@Estado", cidade.Estado);
                        cmd.Parameters.AddWithValue("@Nome", cidade.Nome);
                        cmd.Parameters.AddWithValue("@Capital", cidade.Capital);

                        DbParameter returnValue;
                        returnValue = cmd.CreateParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        result = Convert.ToInt32(returnValue.Value);
                        conn.Close();

                        SerializeXML(cidade);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            return result;
        }

        public int UpdateCidade(Cidade cidade)
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

                        cmd.CommandText = "UPDATE Cidades SET Estado = @Estado, Nome = @Nome, Capital = @Capital WHERE Codigo = @Codigo";

                        cmd.Parameters.AddWithValue("@Codigo", cidade.Codigo);
                        cmd.Parameters.AddWithValue("@Estado", cidade.Estado);
                        cmd.Parameters.AddWithValue("@Nome", cidade.Nome);
                        cmd.Parameters.AddWithValue("@Capital", cidade.Capital);

                        DbParameter returnValue;
                        returnValue = cmd.CreateParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        result = Convert.ToInt32(returnValue.Value);
                        conn.Close();

                        SerializeXML(cidade);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return result;
        }

        public void DeleteCidade(Cidade cidade)
        {
            using (SqlConnection conn = new SqlConnection(Config.DbConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "DELETE FROM Cidades WHERE Codigo = @Codigo";

                    cmd.Parameters.AddWithValue("@Codigo", cidade.Codigo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    SerializeXML(cidade);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private static void SerializeXML(Cidade cidade)
        {
            using (FileStream writer = new FileStream("c:/temp/cadmusCidade.xml", FileMode.Append, FileAccess.Write))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Cidade));
                ser.WriteObject(writer, cidade);
            }
        }

        private static Cidade FillDataRecord(IDataRecord myDataRecord)
        {
            var cidade = new Cidade
            {
                Codigo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Codigo")),
                Estado = myDataRecord.GetString(myDataRecord.GetOrdinal("Estado")),
                codEstado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("codEstado")),
                Nome = myDataRecord.GetString(myDataRecord.GetOrdinal("Nome")),
                Capital = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Capital")),
            };

            return cidade;
        }
    }
}
