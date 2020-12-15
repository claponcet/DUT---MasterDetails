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

namespace WpfApp1.Ajouts
{
    /// <summary>
    /// Logique d'interaction pour AjoutFilmographie.xaml
    /// </summary>
    public partial class AjoutFilmographie : Window
    {
        public Manager manager => (App.Current as App).manager;
        Film film;

        public AjoutFilmographie()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            film = e.AddedItems[0] as Film;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            if (manager.ElementSelectionne.GetType() == typeof(Acteur))
            {
                Details.FicheActeur fiche = new Details.FicheActeur();
                fiche.Show();
                this.Close();
            }
            if (manager.ElementSelectionne.GetType() == typeof(Allie) || manager.ElementSelectionne.GetType() == typeof(Avenger) || manager.ElementSelectionne.GetType() == typeof(Ennemi))
            {
                Details.FichePersonnage fiche = new Details.FichePersonnage();
                fiche.Show();
                this.Close();
            }
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (manager.ElementSelectionne.GetType() == typeof(Acteur))
            {
                (manager.ElementSelectionne as Acteur).AjouterFilm(film);
                manager.SauvegardeDonnees();
                Details.FicheActeur fiche = new Details.FicheActeur();
                fiche.Show();
                this.Close();
            }
            if (manager.ElementSelectionne.GetType() == typeof(Allie) || manager.ElementSelectionne.GetType() == typeof(Avenger) || manager.ElementSelectionne.GetType() == typeof(Ennemi))
            {
                (manager.ElementSelectionne as Personnage).AjouterFilm(film);
                manager.SauvegardeDonnees();
                Details.FichePersonnage fiche = new Details.FichePersonnage();
                fiche.Show();
                this.Close();
            }
            
        }
    }
}
