namespace CountriesDataApp.DTOs
{
    public class CountryDto
    {
        public NameDto Name { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }
        public List<string> Capital { get; set; }
        public FlagDto Flags { get; set; }
        public string Cca3 { get; set; }

    }

    public class NameDto
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }

    public class FlagDto
    {
        public string Png { get; set; }
        public string Svg { get; set; }

    }
}
