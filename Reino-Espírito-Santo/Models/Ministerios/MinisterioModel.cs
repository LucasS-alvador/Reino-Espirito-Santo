
using Reino_Espírito_Santo.DataBase.Entidades;

﻿using Reino_Espírito_Santo.Models.Auxiliares;
﻿using MySql.Data.MySqlClient;


namespace Reino_Espírito_Santo.Models.Ministerios
{
    public class MinisterioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long auxiliarId { get; set; }
        public DateTime DataInicio { get; set; }

        public string AuxiliarNome { get; set; }

        public MinisterioModel() { }

        
        public MinisterioModel( Ministerio ministerio)
        {
            Id = ministerio.Id;
            Nome = ministerio.Nome;
            Descricao = ministerio.Descricao;
            auxiliarId = ministerio.AuxiliarId;
            DataInicio = ministerio.DataInicio;
        }

        public Ministerio getEntidade()
        {
            return new Ministerio()
            {
                Id = Id,
                Nome = Nome,
                Descricao = Descricao,
                AuxiliarId = auxiliarId
            };
        }


    }
}

