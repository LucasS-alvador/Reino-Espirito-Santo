using System;
using System.Numerics;
using MySql.Data;
using MySql.Data.MySqlClient;
using Reino_Espírito_Santo.DataBase;

namespace Reino_Espírito_Santo.Models.Auxiliares
{
    public class AuxiliarModel : EntidadeBase<AuxiliarModel>
    {
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
        public override List<string> Fields => new List<string>()
        {
            "ID",
            "NOME",
            "FUNCAO",
            "TELEFONE",
        };
        public override string TableName => "AUXILIARES";

        public override AuxiliarModel Fill(MySqlDataReader reader)
        { 
            var aux = new AuxiliarModel();

            aux.ID = reader.GetInt32("ID");
            aux.Nome = reader.GetString("NOME");
            aux.Funcao = reader.GetString("FUNCAO");
            aux.Telefone = reader.GetString("TELEFONE");

            return aux;
        }

        public override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNome", Nome));
            parameters.Add(new MySqlParameter("pFUNCAO", Funcao));
            parameters.Add(new MySqlParameter("pTELEFONE", Telefone));
        }
    }
}
