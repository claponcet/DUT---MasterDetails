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
    /// Logique d'interaction pour SuppressionFilm.xaml
    /// </summary>
    public partial class SuppressionFilm : Window
    {
        public Manager manager => (App.Current as App).manager;

        public SuppressionFilm()
        {
            InitializeComponent();
            DataContext = manager.MonEnsemble;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            manager.MonEnsemble.SuppressionElement(manager.ElementSelectionne as Film);
            manager.SauvegardeDonnees();
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Film;
        }
    }
}
