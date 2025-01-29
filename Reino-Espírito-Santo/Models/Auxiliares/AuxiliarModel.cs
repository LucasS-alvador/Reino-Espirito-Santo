using MySql.Data;
using MySql.Data.MySqlClient;

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
    }
}
