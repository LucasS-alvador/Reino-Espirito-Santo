using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo
{
    public class DBConnection
    {
        public const string CONNECTION_STRING = "Server=localhost;Database=igreja;User ID=root;Password=@1@senac2021;";

        public static bool TestarConexao()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
