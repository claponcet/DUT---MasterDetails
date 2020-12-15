using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour SeConnecter1.xaml
    /// </summary>
    public partial class SeConnecter1 : Window
    {
        public Manager manager => (App.Current as App).manager;

        public SeConnecter1()
        {
            InitializeComponent();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            List<Utilisateur> utilisateur = manager.MonEnsemble.listeUtilisateurs;
            string pseudo = textBoxPseudo.Text;
            string mdp = passwordBox.Password;
            utilisateur = (manager.MonEnsemble.listeUtilisateurs).Where(n => n.Pseudo == pseudo && n.Motdepasse == mdp).ToList();
            if (utilisateur.Count == 0)
            {
                MessageBox.Show("Pseudo ou mot de passe incorrect.", "Authentification impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                manager.UtilisateurCourant = utilisateur[0];
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void CreerUnCompte_Click(object sender, RoutedEventArgs e)
        {
            CreerUnCompte fenetre = new CreerUnCompte();
            fenetre.ShowDialog();
        }
    }
}
