namespace Countries.Objects
{
    public class Country
    {
        public Name Name { get; set; }
        public string Capital { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
}
