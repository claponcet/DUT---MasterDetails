using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager manager => (App.Current as App).manager;


        public MainWindow()
        { 
            InitializeComponent();
            if (manager.UtilisateurCourant==null)
            {
                boutonConnexion.Content = "Connexion";
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
                if (manager.UtilisateurCourant.Administrateur)
                {
                    gridAdministrateur.Visibility = Visibility.Visible;
                }
            }
        }

        private void Bouton_Acteur(object sender, RoutedEventArgs e)
        {
            Masters.ListeActeurs listeActeurs = new Masters.ListeActeurs();
            listeActeurs.Show();
            Close();
        }

        private void Bouton_Personnage(object sender, RoutedEventArgs e)
        {
            Masters.ListePersos listePersos = new Masters.ListePersos();
            listePersos.Show();
            Close();
        }

        private void Bouton_Film(object sender, RoutedEventArgs e)
        {
            Masters.ListeFilms listeFilm = new Masters.ListeFilms();
            listeFilm.Show();
            Close();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

        private void AjouterFilm_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutFilm ajoutFilm = new Ajouts.AjoutFilm();
            ajoutFilm.ShowDialog();
        }

        private void SupprimerFilm_Click(object sender, RoutedEventArgs e)
        {
            Suppressions.SuppressionFilm suppressionFilm = new Suppressions.SuppressionFilm();
            suppressionFilm.ShowDialog();
        }

        private void AjouterPerso_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutPerso ajouterPerso = new Ajouts.AjoutPerso();
            ajouterPerso.ShowDialog();
        }

        private void SupprimerPerso_Click(object sender, RoutedEventArgs e)
        {
            Suppressions.SuppressionPersonnage suppressionPersonnage = new Suppressions.SuppressionPersonnage();
            suppressionPersonnage.ShowDialog();
        }

        private void AjouterActeur_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutActeur ajoutActeur = new Ajouts.AjoutActeur();
            ajoutActeur.ShowDialog();
        }

        private void SupprimerActeur_Click(object sender, RoutedEventArgs e)
        {
            Suppressions.SuppressionActeur suppressionActeur = new Suppressions.SuppressionActeur();
            suppressionActeur.ShowDialog();
        }
    }
}
