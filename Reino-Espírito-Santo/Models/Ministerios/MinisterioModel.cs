using Reino_Espírito_Santo.Models.Auxiliares;

namespace Reino_Espírito_Santo.Models.Ministerio
{
    public class MinisterioModel
    {
            public long Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public long auxiliarId { get; set; }
            public DateTime DataInicio { get; set; }

            // Nova propriedade para armazenar o nome do auxiliar
            public string AuxiliarNome { get; set; }
        }

    }

