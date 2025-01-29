using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo.Models.Dizimo
{
    public class DizimoModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Adicionado { get; set; }

        public decimal AntigoAdd1 { get; set; }
        public decimal AntigoAdd2 { get; set; }
        public decimal AntigoAdd3 { get; set; }
        public static DizimoModel Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM DIZIMOS WHERE ID = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new DizimoModel
                    {
                        Id = reader.GetInt32("ID"),
                        Total = reader.GetDecimal("TOTAL"),
                        Adicionado = reader.GetDecimal("Adicionado"),
                        AntigoAdd1 = reader.GetDecimal("ANTIGOADD1"),
                        AntigoAdd2 = reader.GetDecimal("ANTIGOADD2"),
                        AntigoAdd3 = reader.GetDecimal("ANTIGOADD3"),
                    };
                }
            }
            return null;
        }
        public static List<DizimoModel> GetAll()
        {
            var result = new List<DizimoModel>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT * FROM DIZIMOS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DizimoModel()
                    {
                        Id = reader.GetInt32("ID"),
                        Total = reader.GetDecimal("TOTAL"),
                        Adicionado = reader.GetDecimal("Adicionado"),
                        AntigoAdd1 = reader.GetDecimal("ANTIGOADD1"),
                        AntigoAdd2 = reader.GetDecimal("ANTIGOADD2"),
                        AntigoAdd3 = reader.GetDecimal("ANTIGOADD3"),
                    });
                }
            }

            return result;
        }
    }
}
