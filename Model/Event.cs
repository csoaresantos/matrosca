namespace Matrosca.API.Model
{
    public class Event
    {
        public int EventId { get; set; }

        public string Local { get; set; }

        public string DataEvent { get; set; }

        public string Theme { get; set; }

        public int PeopleQty { get; set; }

        public string Lote { get; set; }
    }
}