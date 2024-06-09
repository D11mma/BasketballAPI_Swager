namespace BasketballAPI_Swager.Model
{
    public class Country1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class Response1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Logo { get; set; }
        public Country1 Country { get; set; }
    }

    public class BasketballLeague
    {
        public List<Response1> Response { get; set; }
    }
}
