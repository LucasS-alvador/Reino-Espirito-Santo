<<<<<<< HEAD
using Reino_Espírito_Santo.DataBase.Entidades;
=======
﻿using Reino_Espírito_Santo.Models.Auxiliares;
﻿using MySql.Data.MySqlClient;
>>>>>>> c9bfaf7ff9c45cea5043e7835070a67eaef4c75e

namespace Reino_Espírito_Santo.Models.Ministerios
{
    public class MinisterioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long auxiliarId { get; set; }
        public DateTime DataInicio { get; set; }
<<<<<<< HEAD
        public string AuxiliarNome { get; set; }

        public MinisterioModel()
=======

        // Nova propriedade para armazenar o nome do auxiliar
        public string AuxiliarNome { get; set; }

        public static MinisterioModel Get(int id)
>>>>>>> c9bfaf7ff9c45cea5043e7835070a67eaef4c75e
        {

        }
        
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

