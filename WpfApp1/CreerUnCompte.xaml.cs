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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour CreerUnCompte.xaml
    /// </summary>
    public partial class CreerUnCompte : Window
    {
        public Manager manager => (App.Current as App).manager;

        public CreerUnCompte()
        {
            InitializeComponent();
        }

        private void Confirmer_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur utilisateur = new Utilisateur(textBoxPseudo.Text, passwordBox.Password, false, manager.MonEnsemble.CollectionFilms);
            if (manager.MonEnsemble.listeUtilisateurs != null && manager.MonEnsemble.listeUtilisateurs.Contains(utilisateur))
            {
                MessageBox.Show("Ce pseudo est déjà utilisé.", "Création d'un nouveau compte impossible",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                manager.MonEnsemble.AjouterUtilisateur(utilisateur);
                manager.SauvegardeDonnees();
                manager.UtilisateurCourant = utilisateur;
                this.Close();
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
