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
    /// Logique d'interaction pour FicheFilm.xaml
    /// </summary>
    public partial class FicheFilm : Window
    {
        public Manager manager => (App.Current as App).manager;

        public FicheFilm()
        {
            InitializeComponent();
            DataContext = manager.ElementSelectionne as Film;
            maListBoxActeurs.DataContext = (manager.ElementSelectionne as Film).Casting;
            maListBoxPersonnages.DataContext = (manager.ElementSelectionne as Film).Casting;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
                checkBoxVu.Visibility = Visibility.Hidden;
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
                if (manager.UtilisateurCourant.Administrateur)
                {
                    ajouterCasting.Visibility = Visibility.Visible;
                }
                bool vu = manager.UtilisateurCourant.listeFilmsVus[manager.ElementSelectionne as Film];
                if (vu)
                {
                    checkBoxVu.IsChecked = true;
                    checkBoxVu.Content = "Déjà vu";
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Masters.ListeFilms liste = new Masters.ListeFilms();
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

        private void Commentaire_Click(object sender, RoutedEventArgs e)
        {
            Masters.ListeCommentaires commentaires = new Masters.ListeCommentaires();
            Close();
            commentaires.Show();
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            int indiceCourant = manager.MonEnsemble.CollectionFilms.IndexOf(manager.ElementSelectionne as Film);
            indiceCourant=indiceCourant-1;
            if (indiceCourant >= 0)
            {
                manager.ElementSelectionne = manager.MonEnsemble.CollectionFilms[indiceCourant];
                FicheFilm ficheFilm = new FicheFilm();
                ficheFilm.Show();
                Close();
            }
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            int indiceCourant = manager.MonEnsemble.CollectionFilms.IndexOf(manager.ElementSelectionne as Film);
            indiceCourant=indiceCourant+1;
            if (indiceCourant<manager.MonEnsemble.CollectionFilms.Count)
            {
                manager.ElementSelectionne = manager.MonEnsemble.CollectionFilms[indiceCourant];
                FicheFilm ficheFilm = new FicheFilm();
                ficheFilm.Show();
                Close();
            }
            
        }

        private void maListBoxActeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Acteur;
            FicheActeur ficheActeur = new FicheActeur();
            ficheActeur.Show();
            Close();
        }

        private void maListBoxPersonnages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Personnage;
            FichePersonnage fichePerso = new FichePersonnage();
            fichePerso.Show();
            Close();
        }

        private void ajouterCasting_Click(object sender, RoutedEventArgs e)
        {
            Ajouts.AjoutCasting fenetre = new Ajouts.AjoutCasting();
            fenetre.Show();
            this.Close();
        }

        private void checkBoxVu_Checked(object sender, RoutedEventArgs e)
        {
            manager.UtilisateurCourant.MarquerFilmCommeVu(manager.ElementSelectionne as Film);
            checkBoxVu.Content = "Déjà vu";
            manager.SauvegardeDonnees();
        }

        private void checkBoxVu_Unchecked(object sender, RoutedEventArgs e)
        {
            manager.UtilisateurCourant.listeFilmsVus[manager.ElementSelectionne as Film] = false;
            checkBoxVu.Content = "Pas encore vu";
            manager.SauvegardeDonnees();
        }
    }

}
