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

namespace WpfApp1.Masters
{
    /// <summary>
    /// Logique d'interaction pour ListeActeurs.xaml
    /// </summary>
    public partial class ListeActeurs : Window
    {
        public Manager manager => (App.Current as App).manager;

        public ListeActeurs()
        {
            InitializeComponent();
            masterActeurs.DataContext = manager.MonEnsemble;
            if (manager.UtilisateurCourant == null)
            {
                boutonConnexion.Content = "Connexion";
            }
            else
            {
                boutonConnexion.Content = "Déconnexion";
            }
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.ElementSelectionne = e.AddedItems[0] as Acteur;
            Details.FicheActeur ficheActeur = new Details.FicheActeur();
            ficheActeur.Show();
            Close();
        }
    }
}
