using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Reino_Espírito_Santo.Models.Auxiliares;

namespace Reino_Espírito_Santo.DataBase.Entidades
{
    public class Ministerio
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long AuxiliarId { get; set; } // 'AUXILIAR_ID' é o nome da coluna na tabela
        public DateTime DataInicio { get; set; } // 'DT_INICIO' é o nome da coluna na tabela

        // Método para obter um único Ministério pelo ID
        public static Ministerio Get(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = $"SELECT ID, NOME, DESCRICAO, ID_AUXILIAR, DT_INICIO FROM MINISTERIOS WHERE ID = @ID";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Ministerio
                    {
                        Id = reader.GetInt64("ID"),
                        Nome = reader.GetString("NOME"),
                        Descricao = reader.GetString("DESCRICAO"),
                        AuxiliarId = reader.GetInt64("ID_AUXILIAR"), // Usando 'ID_AUXILIAR'
                        DataInicio = reader.GetDateTime("DT_INICIO") // Usando 'DT_INICIO'
                    };
                }
            }

            return null;
        }

        // Método para obter todos os Ministérios
        public static List<Ministerio> GetAll()
        {
            var result = new List<Ministerio>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT ID, NOME, DESCRICAO, ID_AUXILIAR, DT_INICIO FROM MINISTERIOS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Ministerio()
                    {
                        Id = reader.GetInt64("ID"),
                        Nome = reader.GetString("NOME"),
                        Descricao = reader.GetString("DESCRICAO"),
                        AuxiliarId = reader.GetInt64("ID_AUXILIAR"), // Usando 'ID_AUXILIAR'
                        DataInicio = reader.GetDateTime("DT_INICIO") // Usando 'DT_INICIO'
                    });
                }
            }

            return result;
        }

        // Método para criar um novo Ministério
        public void Create()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO MINISTERIOS (NOME, DESCRICAO, ID_AUXILIAR, DT_INICIO) 
                                    VALUES (@pNOME, @pDESCRICAO, @pID_AUXILIAR, @pDT_INICIO)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pDESCRICAO", Descricao));
                cmd.Parameters.Add(new MySqlParameter("pID_AUXILIAR", AuxiliarId)); // Usando 'ID_AUXILIAR'
                cmd.Parameters.Add(new MySqlParameter("pDT_INICIO", DataInicio)); // Usando 'DT_INICIO'

                cmd.ExecuteNonQuery();
            }
        }

        // Método para atualizar os dados de um Ministério
        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE MINISTERIOS SET NOME = @pNOME, DESCRICAO = @pDESCRICAO, 
                                     ID_AUXILIAR = @pID_AUXILIAR, DT_INICIO = @pDT_INICIO 
                                     WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", Id));
                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pDESCRICAO", Descricao));
                cmd.Parameters.Add(new MySqlParameter("pID_AUXILIAR", AuxiliarId)); // Usando 'ID_AUXILIAR'
                cmd.Parameters.Add(new MySqlParameter("pDT_INICIO", DataInicio)); // Usando 'DT_INICIO'

                cmd.ExecuteNonQuery();
            }
        }

        // Método para deletar um Ministério
        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", Id));
                cmd.CommandText = @$"DELETE FROM MINISTERIOS WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
