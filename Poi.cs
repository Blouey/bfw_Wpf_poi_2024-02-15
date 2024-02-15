namespace Wpf_PointOfInterest_2024_02_15;

public class Poi
{
    private int PID;
    private string Name;
    private string Breitengrad;
    private string Laengengrad;
    private string Bemerkung;
    private string Link;
    
    public Poi(int pid, string name, string breitengrad, string laengengrad, string bemerkung, string link)
    {
        PID = pid;
        Name = name;
        Breitengrad = breitengrad;
        Laengengrad = laengengrad;
        Bemerkung = bemerkung;
        Link = link;
    }
    
    public int GetPid()
    {
        return PID;
    }
    
    public string GetName()
    {
        return Name;
    }
    
    public string GetBreitengrad()
    {
        return Breitengrad;
    }
    
    public string GetLaengengrad()
    {
        return Laengengrad;
    }
    
    public string GetBemerkung()
    {
        return Bemerkung;
    }
    
    public string GetLink()
    {
        return Link;
    }
    
    
}