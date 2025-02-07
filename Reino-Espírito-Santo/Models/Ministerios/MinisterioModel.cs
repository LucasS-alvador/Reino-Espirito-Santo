
using Reino_Espírito_Santo.DataBase.Entidades;

﻿using Reino_Espírito_Santo.Models.Auxiliares;
﻿using MySql.Data.MySqlClient;


namespace Reino_Espírito_Santo.Models.Ministerios
{
    public class MinisterioModel : EntidadeBase<MinisterioModel>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long auxiliarId { get; set; }
        public DateTime DataInicio { get; set; }
        public string AuxiliarNome { get; set; }

        public override List<string> Fields => new List<string>()
        {
            "ID",
            "NOME",
            "DESCRICAO",
            "ID_AUXILIAR",
            "DT_INICIO"
        };

        public override string TableName => "MINISTERIOS";

        public override MinisterioModel Fill(MySqlDataReader reader)
        {
            var min = new MinisterioModel();

            min.Id = reader.GetInt64("ID");
            min.Nome = reader.GetString("NOME");
            min.Descricao = reader.GetString("DESCRICAO");
            min.auxiliarId = reader.GetInt64("ID_AUXILIAR");
            min.DataInicio = reader.GetDateTime("DT_INICIO");

            return min;
        }

        public override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pNOME", Nome));
            parameters.Add(new MySqlParameter("pDESCRICAO", Descricao));
            parameters.Add(new MySqlParameter("pID_AUXILIAR",auxiliarId));
            parameters.Add(new MySqlParameter("pDT_INICIO",DataInicio));

        }
    }
}

