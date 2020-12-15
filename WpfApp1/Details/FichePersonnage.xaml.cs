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
using Data;

namespace WpfApp1.Details
{
    /// <summary>
    /// Logique d'interaction pour FichePersonage.xaml
    /// </summary>
    public partial class FichePersonnage : Window
    {
        public Manager manager => (App.Current as App).manager;

        public FichePersonnage()
        {
            InitializeComponent();
            DataContext = manager.ElementSelectionne as Personnage;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
                if (manager.UtilisateurCourant.Administrateur)
                {
                    ajoutInterprete.Visibility = Visibility.Visible;
                    ajouterFilm.Visibility = Visibility.Visible;
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Masters.ListePersos liste = new Masters.ListePersos();
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

        private void ListBox_SelectionChangedActeur(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Acteur;
            FicheActeur ficheActeur = new FicheActeur();
            ficheActeur.Show();
            Close();
        }

        private void ListBox_SelectionChangedFilm(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Film;
            FicheFilm ficheFilm = new FicheFilm();
            ficheFilm.Show();
            Close();
        }

        private void ajoutInterprete_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutInterprete fenetre = new Ajouts.AjoutInterprete();
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
