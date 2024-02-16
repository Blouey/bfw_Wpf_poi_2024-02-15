namespace Wpf_PointOfInterest_2024_02_15;

public interface IAccessible
{
    int InsertPoi(Poi poi);
    List<Poi> GetAllPoi();
    Poi GetPoiById(int id);
    Poi GetPoiByName(string name);
    bool UpdatePoi(Poi poi);
    bool DeletePoi(Poi poi);
    bool DeletePoiByName(string name);
    bool DeletePoiById(int id);
    List<string> GetAllPoiNames();
    void ConsoleAllPoi();
}