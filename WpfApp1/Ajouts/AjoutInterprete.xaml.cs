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
    /// Logique d'interaction pour AjoutInterprete.xaml
    /// </summary>
    public partial class AjoutInterprete : Window
    {
        public Manager manager => (App.Current as App).manager;
        Acteur interprete;

        public AjoutInterprete()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            interprete = e.AddedItems[0] as Acteur;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Details.FichePersonnage fiche = new Details.FichePersonnage();
            fiche.Show();
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            (manager.ElementSelectionne as Personnage).AjouterInterprete(interprete);
            manager.SauvegardeDonnees();
            Details.FichePersonnage fiche = new Details.FichePersonnage();
            fiche.Show();
            this.Close();
        }
    }
}
