using System;
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
using Modele;

namespace WpfApp1.Details
{
    /// <summary>
    /// Logique d'interaction pour FicheActeur.xaml
    /// </summary>
    public partial class FicheActeur : Window
    {
        public Manager manager => (App.Current as App).manager;

        public FicheActeur()
        {
            InitializeComponent();
            DataContext = manager.ElementSelectionne;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
                if (manager.UtilisateurCourant.Administrateur)
                {
                    ajoutRole.Visibility = Visibility.Visible;
                    ajouterFilm.Visibility = Visibility.Visible;
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Masters.ListeActeurs liste = new Masters.ListeActeurs();
            liste.Show();
            Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
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

        private void Role_Click(object sender, RoutedEventArgs e)
        {
            manager.ElementSelectionne = (manager.ElementSelectionne as Acteur).Role;
            Details.FichePersonnage fichePerso = new Details.FichePersonnage();
            fichePerso.Show();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Film;
            Details.FicheFilm ficheFilm = new Details.FicheFilm();
            ficheFilm.Show();
            Close();
        }

        private void AjoutRole_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutRole fenetre = new Ajouts.AjoutRole();
            fenetre.Show();
            this.Close();
        }

        private void ajouterFilm_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutFilmographie fenetre = new Ajouts.AjoutFilmographie();
            fenetre.Show();
            this.Close();
        }
    }
}
