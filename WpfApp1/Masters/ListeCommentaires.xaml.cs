using Modele;
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

namespace WpfApp1.Masters
{
    /// <summary>
    /// Logique d'interaction pour Commentaires.xaml
    /// </summary>
    public partial class ListeCommentaires : Window
    {
        public Manager manager => (App.Current as App).manager;

        public ListeCommentaires()
        {
            InitializeComponent();
            DataContext = manager.ElementSelectionne as Film;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
                nouveauCommentaire.Visibility = Visibility.Hidden;
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Details.FicheFilm liste = new Details.FicheFilm();
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

        private void Nouveau_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutCommentaire ajoutCommentaire = new Ajouts.AjoutCommentaire();
            ajoutCommentaire.ShowDialog();

        }
    }
}
