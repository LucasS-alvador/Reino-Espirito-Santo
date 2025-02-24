using Reino_Espírito_Santo.DataBase;
using MySql.Data.MySqlClient;
using System.Data;

namespace Reino_Espírito_Santo.Models
{
    public abstract class EntidadeBase<T>
    {
        public long ID { get; set; }
        public abstract string TableName { get; }
        public abstract List<String> Fields { get;}
        public abstract T Fill(MySqlDataReader reader);
        public abstract void FillParameters(MySqlParameterCollection parameters);
        public T Get(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM {TableName} WHERE ID = @ID";
                var command = new MySqlCommand(querry, conn);
                command.Parameters.Add(new MySqlParameter("ID", id));

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Fill(reader);
                }

            }
            return default(T);
        }


        public List<T> GetAll()
        {
            var result = new List<T>();

            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();
                var querry = $"SELECT * FROM {TableName}";
                var command = new MySqlCommand(querry, conn);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Fill(reader));
                }

            }
            return result;
        }

        // Add a object to the database with the caller's vallues
        public void Create()
        {
            using (var conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                var EliminateID = Fields;
                EliminateID.Remove("ID");
                conn.Open();

                var cmd = conn.CreateCommand();
                FillParameters(cmd.Parameters);
                cmd.CommandText = @$"INSERT INTO {TableName} ({string.Join(",", EliminateID)}) VALUES ({string.Join(", ", EliminateID.Select(campo => $"@p{campo}"))})";
                cmd.ExecuteNonQuery();
            }
        }

        // Update a object in the database with the caller's vallues
        public void Update(long id)
        {
            using (var conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                var EliminateID = Fields;
                EliminateID.Remove("ID");   
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @$"UPDATE {TableName} SET {string.Join(", ", EliminateID.Select(campo => $"{campo} = @p{campo}"))}
                                   WHERE ID = @pID";
                cmd.Parameters.Add(new MySqlParameter("pID", id));
                FillParameters(cmd.Parameters);

                cmd.ExecuteNonQuery();
            }

        }
        public void Delete(long id)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.CONNECTION_STRING))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.Parameters.Add(new MySqlParameter("pID", id));
                cmd.CommandText = @$"DELETE FROM {TableName} WHERE ID = @pID";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
