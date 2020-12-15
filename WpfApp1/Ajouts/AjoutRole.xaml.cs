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
    /// Logique d'interaction pour AjoutRole.xaml
    /// </summary>
    public partial class AjoutRole : Window
    {
        public Manager manager => (App.Current as App).manager;
        Personnage role;

        public AjoutRole()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            role = e.AddedItems[0] as Personnage;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Details.FicheActeur fiche = new Details.FicheActeur();
            fiche.Show();
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            (manager.ElementSelectionne as Acteur).AjouterRole(role);
            manager.SauvegardeDonnees();
            Details.FicheActeur fiche = new Details.FicheActeur();
            fiche.Show();
            this.Close();
        }
    }
}
