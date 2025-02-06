using MySql.Data.MySqlClient;
using Reino_Espírito_Santo.DataBase;
using Reino_Espírito_Santo.Models.Auxiliares;
using System;

namespace Reino_Espírito_Santo.Models.Dizimo
{
    public class DizimoModel : EntidadeBase<DizimoModel>
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Adicionado { get; set; }

        public decimal AntigoAdd1 { get; set; }
        public decimal AntigoAdd2 { get; set; }
        public decimal AntigoAdd3 { get; set; }

        public override List<string> Fields => new List<string>()
        {
            "ID",
            "TOTAL",
            "ADICIONADO",
            "ANTIGOADD1",
            "ANTIGOADD2",
            "ANTIGOADD3"
        };

        public override string TableName => "DIZIMOS";
        public override DizimoModel Fill(MySqlDataReader reader)
        {
            var aux = new DizimoModel();

            aux.Id = reader.GetInt32("ID");
            aux.Total = reader.GetDecimal("TOTAL");
            aux.Adicionado = reader.GetDecimal("ADICIONADO");
            aux.AntigoAdd1 = reader.GetDecimal("ANTIGOADD1");
            aux.AntigoAdd2 = reader.GetDecimal("ANTIGOADD2");
            aux.AntigoAdd3 = reader.GetDecimal("ANTIGOADD3");

            return aux;
        }
        public override void FillParameters(MySqlParameterCollection parameters)
        {
            parameters.Add(new MySqlParameter("pTOTAL", Total));
            parameters.Add(new MySqlParameter("pADICIONADO", Adicionado));
            parameters.Add(new MySqlParameter("pAntigoAdd1", AntigoAdd1));
            parameters.Add(new MySqlParameter("pAntigoAdd2", AntigoAdd2));
            parameters.Add(new MySqlParameter("pAntigoAdd3", AntigoAdd3));
        }
    }
}