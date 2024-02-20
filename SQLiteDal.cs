using System.Data.SqlClient;
using System.Data.SQLite;

namespace Wpf_PointOfInterest_2024_02_15;

    class SQLiteDal : IAccessible
    {
        private readonly SQLiteConnection _conn;
        public SQLiteDal(string connectionString)
        {
          _conn = new SQLiteConnection(connectionString);    
        }

        /// <summary>
        /// Delete a poi by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> true if the object was deleted </returns>
        public bool DeletePoiById(int id)
        {
            // Sql command-string to delete a poi by id
            string deleteSql = "DELETE FROM poi WHERE PID = @id";
            
            // Sql command to delete a poi by id
            SQLiteCommand cmd = new SQLiteCommand(deleteSql, _conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            // Open the connection
            _conn.Open();
            
            // Execute the command
            int anzahl = cmd.ExecuteNonQuery();
            
            // Close the connection
            _conn.Close();
            
            // Return true if the number of rows affected is greater than 0
            return anzahl > 0;
        }

        /// <summary>
        /// Insert a new poi into the database
        /// </summary>
        /// <param name="poi"></param>
        /// <returns> the id of the new poi </returns>
        public int InsertPoi(Poi poi)
        {
            string insertSql = "INSERT INTO poi (Name, Breitengrad, Laengengrad, Bemerkung, Link) VALUES (@Name, @Breitengrad, @Laengengrad, @Bemerkung, @Link; SELECT last_insert_rowid()";
            SQLiteCommand cmd = new SQLiteCommand(insertSql, _conn);
            cmd.Parameters.AddWithValue("@Name", poi.GetName());
            cmd.Parameters.AddWithValue("@Breitengrad", poi.GetBreitengrad());
            cmd.Parameters.AddWithValue("@Laengengrad", poi.GetLaengengrad());
            cmd.Parameters.AddWithValue("@Bemerkung", poi.GetBemerkung());
            cmd.Parameters.AddWithValue("@Link", poi.GetLink());
            _conn.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            
            _conn.Close();
            
            return id;
        }

        /// <summary>
        ///  Get all Poi from the database
        /// </summary>
        /// <returns>  List of all Poi </returns>
        public List<Poi> GetAllPoi()
        {
            string selectSql = "SELECT * FROM poi";
            SQLiteCommand cmd = new SQLiteCommand(selectSql, _conn);
            _conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Poi> pois = new List<Poi>();
            while (reader.Read())
            {
                Poi p = new Poi();
                p.PID = Convert.ToInt32(reader["PID"]);
                p.Name = reader["Name"].ToString();
                p.Breitengrad = reader["Breitengrad"].ToString();
                p.Laengengrad = reader["Laengengrad"].ToString();
                p.Bemerkung = reader["Bemerkung"].ToString();
                p.Link = reader["Link"].ToString();
                pois.Add(p);
            }
            _conn.Close();
            return pois;
        }

        /// <summary>
        /// Get a Poi by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Poi </returns>
        public Poi GetPoiById(int id)
        {
            string selectSql = "SELECT * FROM poi WHERE PID = @id";
            SQLiteCommand cmd = new SQLiteCommand(selectSql, _conn);
            cmd.Parameters.AddWithValue("@id", id);
            _conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            Poi poi = null!;
            while (reader.Read())
            {
                poi = new Poi(
                    Convert.ToInt32(reader["PID"]),
                    reader["Name"].ToString(),
                    reader["Breitengrad"].ToString(),
                    reader["Laengengrad"].ToString(),
                    reader["Bemerkung"].ToString(),
                    reader["Link"].ToString()
                );
            }
            _conn.Close();
            return poi;
        }

        /// <summary>
        /// Get a Poi by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Poi </returns>
        public Poi GetPoiByName(string name)
        {
            string selectSql = "SELECT * FROM poi WHERE Name = @name";
            SQLiteCommand cmd = new SQLiteCommand(selectSql, _conn);
            cmd.Parameters.AddWithValue("@name", name);
            _conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            Poi poi = null!;
            while (reader.Read())
            {
                poi = new Poi(
                    Convert.ToInt32(reader["PID"]),
                    reader["Name"].ToString(),
                    reader["Breitengrad"].ToString(),
                    reader["Laengengrad"].ToString(),
                    reader["Bemerkung"].ToString(),
                    reader["Link"].ToString()
                );
            }
            _conn.Close();
            return poi;
        }

        /// <summary>
        /// Update a Poi
        /// </summary>
        /// <param name="poi"></param>
        /// <returns> true if the object was updated </returns>
        public bool UpdatePoi(Poi poi)
        {
            string updateSql = "UPDATE poi SET Name = @Name, Breitengrad = @Breitengrad, Laengengrad = @Laengengrad, Bemerkung = @Bemerkung, Link = @Link WHERE PID = @PID";
            SQLiteCommand cmd = new SQLiteCommand(updateSql, _conn);
            cmd.Parameters.AddWithValue("@Name", poi.GetName());
            cmd.Parameters.AddWithValue("@Breitengrad", poi.GetBreitengrad());
            cmd.Parameters.AddWithValue("@Laengengrad", poi.GetLaengengrad());
            cmd.Parameters.AddWithValue("@Bemerkung", poi.GetBemerkung());
            cmd.Parameters.AddWithValue("@Link", poi.GetLink());
            cmd.Parameters.AddWithValue("@PID", poi.GetPid());
            _conn.Open();
            int anzahl = cmd.ExecuteNonQuery();
            _conn.Close();
            return anzahl > 0;
        }

        /// <summary>
        /// Delete a Poi
        /// </summary>
        /// <param name="poi"></param>
        /// <returns> true if the object was deleted </returns>
        public bool DeletePoi(Poi poi)
        {
            return DeletePoiById(poi.GetPid());
        }

        /// <summary>
        /// Delete a Poi by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns> true if the object was deleted </returns>
        public bool DeletePoiByName(string name)
        {
            string deleteSql = "DELETE FROM poi WHERE Name = @name";
            SQLiteCommand cmd = new SQLiteCommand(deleteSql, _conn);
            cmd.Parameters.AddWithValue("@name", name);
            _conn.Open();
            int anzahl = cmd.ExecuteNonQuery();
            _conn.Close();
            return anzahl > 0;
        }

        /// <summary>
        /// Get all Poi names
        /// </summary>
        /// <returns> List of all Poi names </returns>
        public List<string> GetAllPoiNames()
        {
            List<string> poiNames = new List<string>();
            string selectSql = "SELECT Name FROM poi";
            SQLiteCommand cmd = new SQLiteCommand(selectSql, _conn);
            _conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                poiNames.Add(reader["Name"].ToString()!);
            }
            _conn.Close();
            return poiNames;
        }

        /// <summary>
        /// Print all Poi to the console
        /// </summary>
        /// <returns> void </returns>
        public void ConsoleAllPoi()
        {
            List<Poi> pois = GetAllPoi();
            foreach (var poi in pois)
            {
                Console.WriteLine(poi);
            }
        }
    }
