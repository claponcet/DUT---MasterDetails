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
    /// Logique d'interaction pour AjouterCasting.xaml
    /// </summary>
    public partial class AjoutCasting : Window
    {
        public Manager manager => (App.Current as App).manager;
        Personnage role;
        Acteur interprete;

        public AjoutCasting()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }

        private void Acteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            interprete = e.AddedItems[0] as Acteur;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            role = e.AddedItems[0] as Personnage;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Details.FicheFilm fiche = new Details.FicheFilm();
            fiche.Show();
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if ((manager.ElementSelectionne as Film).Casting.ContainsKey(interprete))
            {
                MessageBox.Show("Cet acteur fait déjà parti du casting de ce film.", "Ajout impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                (manager.ElementSelectionne as Film).AjouterUnCasting(interprete, role);
                manager.SauvegardeDonnees();
                Details.FicheFilm fiche = new Details.FicheFilm();
                fiche.Show();
                this.Close();
            }
        }
    }
}
