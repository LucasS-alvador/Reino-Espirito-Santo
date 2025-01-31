using System;
using System.Numerics;
using MySql.Data;
using MySql.Data.MySqlClient;
using Reino_Espírito_Santo.DataBase;

namespace Reino_Espírito_Santo.Models.Auxiliares
{
    public class AuxiliarModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }

        public static AuxiliarModel Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM AUXILIARES WHERE ID = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new AuxiliarModel
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Funcao = reader.GetString("FUNCAO"),
                        Telefone = reader.GetString("TELEFONE"),
                    };
                }
            }
            return null;
        }
        public static List<AuxiliarModel> GetAll()
        {
            var result = new List<AuxiliarModel>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT * FROM AUXILIARES";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AuxiliarModel()
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Funcao = reader.GetString("FUNCAO"),
                        Telefone = reader.GetString("TELEFONE"),
                    });
                }
            }

            return result;
        }
        public static void Create(AuxiliarModel c)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO AUXILIARES (NOME, FUNCAO, TELEFONE) 
                                    VALUES (@pNOME, @pFUNCAO, @pTELEFONE)";

                cmd.Parameters.Add(new MySqlParameter("pNOME", c.Nome));
                cmd.Parameters.Add(new MySqlParameter("pFUNCAO", c.Funcao));
                cmd.Parameters.Add(new MySqlParameter("pTELEFONE", c.Telefone));

                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE AUXILIARES SET NOME = @pNOME, FUNCAO = @pFUNCAO, TELEFONE = @pTELEFONE
                                    WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", Id));
                cmd.Parameters.Add(new MySqlParameter("pNOME", Nome));
                cmd.Parameters.Add(new MySqlParameter("pFUNCAO", Funcao));
                cmd.Parameters.Add(new MySqlParameter("pTELEFONE", Telefone));

                cmd.ExecuteNonQuery();

            }

        }
        public static void Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", id));
                cmd.CommandText = @$"DELETE FROM AUXILIARES WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
