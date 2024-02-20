namespace Wpf_PointOfInterest_2024_02_15;

public class Poi
{
    public int PID { get; set;}
    public string Name { get; set;}
    public string Breitengrad { get; set;}
    public string Laengengrad { get; set;}
    public string Bemerkung { get; set;}
    public string Link { get; set;}

    public Poi()
    {
    }

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