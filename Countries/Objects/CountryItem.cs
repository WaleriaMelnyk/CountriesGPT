namespace Countries.Objects
{
    public class CountryItem
    {
        public Name Name { get; set; }
        public string[] Capital { get; set; }
        public int Population { get; set; }
        public bool Independent { get; set; }
        public int Area { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
}