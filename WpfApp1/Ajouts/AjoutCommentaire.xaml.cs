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
    /// Logique d'interaction pour AjoutCommentaire.xaml
    /// </summary>
    public partial class AjoutCommentaire : Window
    {
        public Manager manager => (App.Current as App).manager;

        public AjoutCommentaire()
        {
            InitializeComponent();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Commentaire commentaire = new Commentaire((comboBox.SelectedIndex) + 1, textBox.Text, manager.UtilisateurCourant.Pseudo);
            (manager.ElementSelectionne as Film).AjouterCommentaire(commentaire);
            manager.SauvegardeDonnees();
            this.Close();
        }
    }
}
