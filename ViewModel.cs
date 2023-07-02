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
        private Team _selectedTeam;

        public ICommand UpdateSpielerCommand { get; }
        public ViewModel()
        {
            fussballspieler = new MeineDB();
            teams = new MeineDB();
            UpdateSpielerCommand = new RelayCommand(param => UpdateSpieler(), param => SelectedSpieler != null);
        }
        public DataTable Fussballspieler
        {
            get { return _fussballspieler; }
            set
            {
                _fussballspieler = value;
                OnPropertyChanged("Fussballspieler");
            }
        }
        public Spieler SelectedSpieler
        {
            get { return _selectedSpieler; }
            set
            {
                _selectedSpieler = value;
                RaisePropertyChanged();
                //OnPropertyChanged("SelectedSpieler");
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
            var meineDb = new MeineDB();
            meineDb.UpdateSpieler(SelectedSpieler);

        }
    }
}
