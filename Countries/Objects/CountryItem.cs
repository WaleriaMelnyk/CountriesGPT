namespace Countries.Objects
{
    public class CountryItem
    {
        public Name name { get; set; }
        public string[] capital { get; set; }
        public int population { get; set; }
        public bool independent { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
    }
}