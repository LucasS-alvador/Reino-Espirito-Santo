using Reino_Espírito_Santo.Models.Auxiliares;
﻿using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo.Models.Ministerio
{
    public class MinisterioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long auxiliarId { get; set; }
        public DateTime DataInicio { get; set; }

        // Nova propriedade para armazenar o nome do auxiliar
        public string AuxiliarNome { get; set; }

        public static MinisterioModel Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM MINISTERIOS WHERE ID = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new MinisterioModel
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        auxiliarId = reader.GetInt32("AUXILIARID"),
                        Descricao = reader.GetString("DESCRICAO"),
                        DataInicio = reader.GetDateTime("DATAINICIO"),
                    };
                }
            }
            return null;
        }
        public static List<MinisterioModel> GetAll()
        {
            var result = new List<MinisterioModel>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT * FROM MINISTERIOS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new MinisterioModel()
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        auxiliarId = reader.GetInt32("AUXILIARID"),
                        Descricao = reader.GetString("DESCRICAO"),
                        DataInicio = reader.GetDateTime("DATAINICIO"),
                    });
                }
            }

            return result;
        }
    }
}

