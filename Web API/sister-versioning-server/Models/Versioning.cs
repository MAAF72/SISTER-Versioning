namespace sister_versioning_server.Models
{
    public class Versioning
    {
        public Versioning() { }

        public Versioning(string version, string link, string description)
        {
            Version = version;
            Link = link;
            Description = description;
        }

        public string Version { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
