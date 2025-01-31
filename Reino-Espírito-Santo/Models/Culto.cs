using System.Numerics;
using Microsoft.AspNetCore.SignalR;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Reino_Espírito_Santo.Models
{
    public class Culto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int PastorID { get; set; }
        public string Link {  get; set; }
        
        public Culto(int id, DateTime data, int pastorID, string link)
        {
            this.Id = id;
            this.Data = data;
            this.PastorID = pastorID;
            this.Link = link;
        }
        public Culto()
        {
            this.Id = -1;
            this.Data = DateTime.MinValue;
            this.PastorID = -1;
            this.Link = "placeholder";
        }
        public static Culto Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM CULTO WHERE ID = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Culto
                    {
                        Id = reader.GetInt32("ID"),
                        Data = reader.GetDateTime("DATA"),
                        PastorID = reader.GetInt32("PASTORID"),
                        Link = reader.GetString("LINK"),
                    };
                }
            }
            return null;
        }
        public static List<Culto> GetAll()
        {
            var result = new List<Culto>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var query = "SELECT * FROM CULTOS";
                var cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Culto()
                    {
                        Id = reader.GetInt32("ID"),
                        Data = reader.GetDateTime("DATA"),
                        PastorID = reader.GetInt32("PASTORID"),
                        Link = reader.GetString("LINK"),
                    });
                }
            }

            return result;
        }

        public static void Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", id));
                cmd.CommandText = @$"DELETE FROM CULTOS WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
        public static void Create(Culto c)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO CULTOS (DATA, PASTORID, LINK) 
                                    VALUES (@pDATA, @pPASTORID, @pLINK)";

                cmd.Parameters.Add(new MySqlParameter("pDATA", c.Data));
                cmd.Parameters.Add(new MySqlParameter("pPASTORID", c.PastorID));
                cmd.Parameters.Add(new MySqlParameter("pLINK", c.Link));

                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE CULTOS SET DATA = @pDATA, PASTORID = @pPASTORID, LINK = @pLINK
                                    WHERE ID = @pID";

                cmd.Parameters.Add(new MySqlParameter("pID", Id));
                cmd.Parameters.Add(new MySqlParameter("pDATA", Data));
                cmd.Parameters.Add(new MySqlParameter("pPASTORID", PastorID));
                cmd.Parameters.Add(new MySqlParameter("pLINK", Link));

                cmd.ExecuteNonQuery();
            }
        }

    }
}

