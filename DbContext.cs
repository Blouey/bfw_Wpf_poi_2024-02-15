using System.Data.SQLite;

namespace Wpf_PointOfInterest_2024_02_15;

public class DbContext
{
    private const string ConnectionString = @"Data Source=C:\Repos\DataBase\SQLite_poi\poiDb";

    /// <summary>
    ///   Get all Poi from the database
    /// </summary>
    public void ConsoleAllPoi()
    {
        // connect sqlite db


        var connection = new SQLiteConnection(ConnectionString);

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM poi";

        connection.Open();

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(reader["PID"] + " "
                                            + reader["Name"] + " "
                                            + reader["Breitengrad"] + " "
                                            + reader["Laengengrad"] + " "
                                            + reader["Bemerkung"] + " "
                                            + reader["Link"]
            );
        }

        connection.Close();
    }

    /// <summary>
    ///  Get all Poi.Names from the database
    /// </summary>
    /// <returns>  List of all Poi.Names </returns>
    public List<string> GetAllPoiNames()
    {
        List<string> poiNames = new List<string>();

        var connection = new SQLiteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT Name FROM poi";

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                poiNames.Add(reader["Name"].ToString()!);
            }
        }

        connection.Close();

        return poiNames;
    }

    /// <summary>
    /// Get a Poi by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns> Poi </returns>
    public Poi GetPoiByName(string name)
    {
        Poi poi = null!;

        var connection = new SQLiteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM poi WHERE Name = @name";
        command.Parameters.AddWithValue("@name", name);

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                poi = new Poi(
                    Convert.ToInt32(reader["PID"]),
                    reader["Name"].ToString()!,
                    reader["Breitengrad"].ToString()!,
                    reader["Laengengrad"].ToString()!,
                    reader["Bemerkung"].ToString()!,
                    reader["Link"].ToString()!
                );
            }
        }
        connection.Close();

        return poi;
    }
    
    
}