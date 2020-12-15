using System;
using Modele;
using Data;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Masters
{
    /// <summary>
    /// Logique d'interaction pour ListeFilms.xaml
    /// </summary>
    public partial class ListeFilms : Window
    {
        public Manager manager => (App.Current as App).manager;

        public ListeFilms()
        {
            InitializeComponent();
            maListBox.DataContext = manager.MonEnsemble;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            if (manager.UtilisateurCourant == null)
            {
                SeConnecter1 seConnecter1 = new SeConnecter1();
                seConnecter1.Show();
                this.Close();
            }
            else
            {
                manager.UtilisateurCourant = null;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Film;
            Details.FicheFilm ficheFilm = new Details.FicheFilm();
            ficheFilm.Show();
            Close();
        }
    }
}
