using MySql.Data;
using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo.Models.Missionarios
{
    public class MissionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public static MissionarioModel Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM MISSIONARIOS WHERE ID = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new MissionarioModel
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Telefone = reader.GetString("TELEFONE"),
                    };
                }
            }
            return null;
        }

        public static List<MissionarioModel> GetAll()
        {
            var result = new List<MissionarioModel>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT * FROM MISSIONARIOS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new MissionarioModel()
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("NOME"),
                        Telefone = reader.GetString("TELEFONE"),
                    });
                }
            }

            return result;
        }
    }
}
