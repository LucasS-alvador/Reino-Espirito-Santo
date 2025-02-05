using System.Numerics;
using Microsoft.AspNetCore.SignalR;
using MySql.Data;
using MySql.Data.MySqlClient;
using Reino_Espírito_Santo.DataBase;

namespace Reino_Espírito_Santo.Models
{
    public class Culto : EntidadeBase<Culto>
    {
        public DateTime Data { get; set; }
        public int PastorID { get; set; }
        public string Link {  get; set; }

        public override string TableName => "CULTOS";

        public override List<string> Fields => new List<string>()
        {
            "ID",
            "DATA",
            "PASTORID",
            "LINK",
        };

        public Culto(int id, DateTime data, int pastorID, string link)
        {
            this.ID = id;
            this.Data = data;
            this.PastorID = pastorID;
            this.Link = link;
        }
        public Culto()
        {
            this.ID = -1;
            this.Data = DateTime.MinValue;
            this.PastorID = -1;
            this.Link = "placeholder";
        }
        public override Culto Fill(MySqlDataReader reader)
        {
            var aux = new Culto();
            aux.ID = reader.GetInt32("ID");
            aux.Data = reader.GetDateTime("DATA");
            aux.PastorID = reader.GetInt32("PASTORID");
            aux.Link = reader.GetString("LINK");

            return aux;
        }
        public override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pID", ID));
            parameters.Add(new MySqlParameter("pDATA", Data));
            parameters.Add(new MySqlParameter("pPASTORID", PastorID));
            parameters.Add(new MySqlParameter("pLINK", Link));
        }
    }
}

