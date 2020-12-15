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

namespace WpfApp1.Ajouts
{
    /// <summary>
    /// Logique d'interaction pour AjoutActeur.xaml
    /// </summary>
    public partial class AjoutActeur : Window
    {
        public Manager manager => (App.Current as App).manager;
        List<Film> filmographie = new List<Film>();
        Personnage role;
        string image;

        public AjoutActeur()
        {
            InitializeComponent();
            listBoxFilms.DataContext = manager.MonEnsemble;
            comboBoxPersonnages.DataContext = manager.MonEnsemble;
            DataContext = this;
        }
        private void AjoutImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Image";
            dialog.DefaultExt = "jpg | png";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                image = dialog.FileName;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            role = e.AddedItems[0] as Personnage;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filmographie.Add(e.AddedItems[0] as Film);
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Acteur acteur = new Acteur(textBoxNom.Text, image);
            acteur.AjouterRole(role);
            foreach(Film f in filmographie)
            {
                acteur.AjouterFilm(f);
            }
            manager.MonEnsemble.AjouterElement((Element)acteur);
            manager.SauvegardeDonnees();
            this.Close();
        }
    }
}
