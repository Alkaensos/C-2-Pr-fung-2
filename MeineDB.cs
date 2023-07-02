using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pruefung2.Model;

namespace Pruefung2
{
    public class MeineDB
    {
        public string connectionString = "Data Source=(local);Initial Catalog=MeineDB;Integrated Security=True";

        public void CreateTableIfNotExists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createFussballspieler = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Fussballspieler')
                         BEGIN
                             CREATE TABLE Fussballspieler
                             (
                                Id INT IDENTITY(1,1) NOT NULL,
                                Nachname NVARCHAR(255),
                                Vorname NVARCHAR(255),
                                Strasse NVARCHAR(255),
                                PLZ NVARCHAR(255),
                                Ort NVARCHAR(255),
                                Telefonnummer NVARCHAR(255),
                                Hoehe decimal(19,4),
                                Geburtsdatum datetime,
                                Nummer int,
                                Position NVARCHAR(255),
                                AnzahlSpiele int,
                                AnzahlTore int,
                                TeamID int
                             )  ON [PRIMARY]
                         END";

                using (SqlCommand command = new SqlCommand(createFussballspieler, connection))
                {
                    command.ExecuteNonQuery();
                }
                string createTeams = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Teams')
                         BEGIN
                             CREATE TABLE Teams
                             (
                                Id INT IDENTITY(1,1) NOT NULL,
                                Name NVARCHAR(255),
                                Strasse NVARCHAR(255),
                                PLZ NVARCHAR(255),
                                Ort NVARCHAR(255),
                                Telefonnummer NVARCHAR(255)
                             )  ON [PRIMARY]
                         END";

                using (SqlCommand command = new SqlCommand(createTeams, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetFussballspieler()
        {
            string query = "SELECT * FROM Fussballspieler";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable fussballspieler = new DataTable("Fussballspieler");
                        adapter.Fill(fussballspieler);
                        return fussballspieler;
                    }
                }
            }
        }
        public void UpdateTeam(Team selectedTeam)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "UPDATE Teams SET Name = @Name, Strasse = @Strasse, PLZ = @PLZ, Ort = @Ort, Telefonnummer = @Telefonnummer WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", selectedTeam.Id);
                    command.Parameters.AddWithValue("@Name", selectedTeam.Name);
                    command.Parameters.AddWithValue("@Strasse", selectedTeam.Strasse);
                    command.Parameters.AddWithValue("@PLZ", selectedTeam.PLZ);
                    command.Parameters.AddWithValue("@Ort", selectedTeam.Ort);
                    command.Parameters.AddWithValue("@Telefonnummer", selectedTeam.Telefonnummer);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateSpieler(Spieler selectedSpieler)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "UPDATE Spieler SET " +
                                  "Nachname = @Nachname, " +
                                  "Vorname = @Vorname, " +
                                  "Strasse = @Strasse, " +
                                  "PLZ = @PLZ, " +
                                  "Ort = @Ort, " +
                                  "Telefonnummer = @Telefonnummer,  " +
                                  "Hoehe = @Hoehe, " +
                                  "Geburtsdatum = @Geburtsdatum, " +
                                  "Nummer = @Nummer, " +
                                  "Position = @Position, " +
                                  "AnzahlSpiele = @AnzahlSpiele, " + 
                                  "AnzahlTore = @AnzahlTore " +
                                  "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", selectedSpieler.Id);
                    command.Parameters.AddWithValue("@Nachname", selectedSpieler.Nachname);
                    command.Parameters.AddWithValue("@Vorname", selectedSpieler.Vorname);
                    command.Parameters.AddWithValue("@Strasse", selectedSpieler.Strasse);
                    command.Parameters.AddWithValue("@PLZ", selectedSpieler.PLZ);
                    command.Parameters.AddWithValue("@Ort", selectedSpieler.Ort);
                    command.Parameters.AddWithValue("@Telefonnummer", selectedSpieler.Telefonnummer);
                    command.Parameters.AddWithValue("@Hoehe", selectedSpieler.Hoehe);
                    command.Parameters.AddWithValue("@Geburtsdatum", selectedSpieler.Geburtsdatum);
                    command.Parameters.AddWithValue("@Nummer", selectedSpieler.Nummer);
                    command.Parameters.AddWithValue("@Position", selectedSpieler.Position);
                    command.Parameters.AddWithValue("@AnzahlSpiele", selectedSpieler.AnzahlSpiele);
                    command.Parameters.AddWithValue("@AnzahlTore", selectedSpieler.AnzahlTore);

                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetTeams()
        {
            string query = "SELECT * FROM Teams";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable fussballspieler = new DataTable("Fussballspieler");
                        adapter.Fill(fussballspieler);
                        return fussballspieler;
                    }
                }
            }
        }
    }
}
