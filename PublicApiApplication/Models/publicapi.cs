internal class Publicapi
{
    public string API { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }

    public Publicapi(string api, string description, string link)
    {
        API = api;
        Description = description;
        Link = link;
    }
}
