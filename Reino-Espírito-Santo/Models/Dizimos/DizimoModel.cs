namespace Reino_Espírito_Santo.Models.Dizimo
{
    public class DizimoModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Adicionado { get; set; }

        // Lista de contribuições anteriores
        public List<decimal> AdicionadosAntigos { get; set; } = new List<decimal>();
    }
}
