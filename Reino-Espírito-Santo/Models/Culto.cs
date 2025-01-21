namespace Reino_Espírito_Santo.Models
{
    public class Culto
    {
        public int Id { get; set; }
        public DateTime Data;
        public int PastorID;
        public string Link;
        
        public Culto(int id, DateTime data, int pastorID, string link)
        {
            this.Id = id;
            this.Data = data;
            this.PastorID = pastorID;
            this.Link = link;
        }
        public Culto()
        {
            this.Id = -1;
            this.Data = DateTime.MinValue;
            this.PastorID = -1;
            this.Link = "placeholder";
        }
    }
}
