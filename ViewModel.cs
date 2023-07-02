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
        private Spieler _selectedSpieler;
        private DataRowView _selectedSpielerRow;
        private Team _selectedTeam;

        public ICommand UpdateSpielerCommand { get; }

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
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged("SelectedTeam");
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
    }
}

