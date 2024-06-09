namespace BasketballAPI_Swager.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }
    public class Response
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool Nattionnal { get; set; }
        public Country Country { get; set; }
    }
    public class BasketballTeam
    {
        public List<Response> response { get; set; }
    }
}
