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

namespace WpfApp1.Suppressions
{
    /// <summary>
    /// Logique d'interaction pour SuppressionActeur.xaml
    /// </summary>
    public partial class SuppressionActeur : Window
    {
        public Manager manager => (App.Current as App).manager;

        public SuppressionActeur()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            manager.MonEnsemble.SuppressionElement(manager.ElementSelectionne as Acteur);
            manager.SauvegardeDonnees();
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Acteur;
        }
    }
}
