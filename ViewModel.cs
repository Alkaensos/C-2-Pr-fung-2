using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Pruefung2.Model;

namespace Pruefung2
{
    public class ViewModel : ObservableObject
    {
        private DataTable _fussballspieler;
        private MeineDB fussballspieler;
        private DataTable _teams;
        private MeineDB teams;
        private DataRowView _selectedSpielerRow;
        private DataRowView _selectedTeamRow;

        public ICommand UpdateSpielerCommand { get; }
        public ICommand UpdateTeamCommand { get; }

        public DataTable Fussballspieler
        {
            get { return _fussballspieler; }
            set
            {
                _fussballspieler = value;
                OnPropertyChanged("Fussballspieler");
            }
        }
        public DataTable Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged("Teams");
            }
        }
        public ViewModel()
        {
            fussballspieler = new MeineDB();
            SelectFussballspieler();
            teams = new MeineDB();
            SelectTeams();
            UpdateSpielerCommand = new RelayCommand(param => UpdateSpieler(), param => SelectedSpieler != null);
            UpdateTeamCommand = new RelayCommand(param => UpdateTeam(), param => SelectedTeam != null);
        }


        public DataRowView SelectedSpielerRow
        {
            get { return _selectedSpielerRow; }
            set
            {
                _selectedSpielerRow = value;
                OnPropertyChanged("SelectedSpielerRow");
                OnPropertyChanged("SelectedSpieler");
            }
        }
        public DataRowView SelectedTeamRow
        {
            get { return _selectedTeamRow; }
            set
            {
                _selectedTeamRow = value;
                OnPropertyChanged("SelectedTeamRow");
                OnPropertyChanged("SelectedTeam");
            }
        }

        public Spieler SelectedSpieler
        {
            get
            {
                if (SelectedSpielerRow == null)
                    return null;

                return new Spieler
                {
                    Id = (int)SelectedSpielerRow["id"],
                    Nachname = (string)SelectedSpielerRow["Nachname"],
                    Vorname = (string)SelectedSpielerRow["Vorname"],
                    Strasse = (string)SelectedSpielerRow["Strasse"],
                    PLZ = (string)SelectedSpielerRow["PLZ"],
                    Ort = (string)SelectedSpielerRow["Ort"],
                    Telefonnummer = (string)SelectedSpielerRow["Telefonnummer"],
                    Hoehe = (double)(decimal)SelectedSpielerRow["Hoehe"],
                    Geburtsdatum = (DateTime)SelectedSpielerRow["Geburtsdatum"],
                    Nummer = (int)SelectedSpielerRow["Nummer"],
                    Position = (string)SelectedSpielerRow["Position"],
                    AnzahlSpiele = (int)SelectedSpielerRow["AnzahlSpiele"],
                    AnzahlTore = (int)SelectedSpielerRow["AnzahlTore"],
                    TeamID = (int)SelectedSpielerRow["TeamID"]
                };
            }
        }
        public Team SelectedTeam
        {
            get
            {
                if (SelectedTeamRow == null)
                    return null;

                return new Team
                {
                    Id = (int)SelectedTeamRow["id"],
                    Name = (string)SelectedTeamRow["Name"],
                    Strasse = (string)SelectedTeamRow["Strasse"],
                    PLZ = (string)SelectedTeamRow["PLZ"],
                    Ort = (string)SelectedTeamRow["Ort"],
                    Telefonnummer = (string)SelectedTeamRow["Telefonnummer"]
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SelectFussballspieler()
        {
            Fussballspieler = fussballspieler.GetFussballspieler();
        }

        private void SelectTeams()
        {
            Teams = teams.GetTeams();
        }

        //private void UpdateTeam()
        //{
        //    var meineDb = new MeineDB();
        //    meineDb.UpdateTeam(SelectedTeam);
        //}
        private void UpdateSpieler()
        {
            System.Diagnostics.Debug.WriteLine("UpdateSpieler wurde aufgerufen");
            var meineDb = new MeineDB();
            meineDb.UpdateSpieler(SelectedSpieler);

        }
        private void UpdateTeam()
        {
            System.Diagnostics.Debug.WriteLine("UpdateTeam wurde aufgerufen");
            var meineDb = new MeineDB();
            meineDb.UpdateTeam(SelectedTeam);

        }
    }
}

