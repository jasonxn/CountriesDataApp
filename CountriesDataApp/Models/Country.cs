namespace CountriesDataApp.Models
{
    public class Country
    {
        public int Id { get; set; } 
        public string CommonName { get; set; }
        public string OfficialName { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }
        public string FlagPngUrl { get; set; }
        public string Code { get; set; }
    }
}
