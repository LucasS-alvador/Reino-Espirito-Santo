namespace Reino_Espírito_Santo.Models.Ministerio
{
    public class MinisterioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int auxiliarId { get; set; } // Líder responsável pelo ministério
        public DateTime DataInicio { get; set; } // Data de início do ministério

    }
}
