namespace Matrosca.API.DTOs
{
    public class LoteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public int Quantity { get; set; }
    }
}