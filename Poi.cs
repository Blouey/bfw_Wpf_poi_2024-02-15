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
        Breitengrad = breitengrad.Replace(',', '.');
        Laengengrad = laengengrad.Replace(',', '.');
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

    public override string ToString()
    {
        return "Poi{\n" +
               "\tPID=" + PID + ",\n" +
               "\tName='" + Name + "', \n" +
               "\tBreitengrad='" + Breitengrad + "', \n" +
               "\tLaengengrad='" + Laengengrad + "', \n" +
               "\tBemerkung='" + Bemerkung + "', \n" +
               "\tLink='" + Link + "', \n" +
               '}';
    }
}