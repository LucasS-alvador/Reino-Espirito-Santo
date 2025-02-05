using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo.DataBase
{
    public class DBConnection
    {
        //@1@senac2021
        public const string CONNECTION_STRING = "Server=localhost;Database=igreja;User ID=root;Password=root;";

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
