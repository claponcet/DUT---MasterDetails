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
    /// Logique d'interaction pour AjoutFilm.xaml
    /// </summary>
    public partial class AjoutFilm : Window
    {
        public Manager manager => (App.Current as App).manager;
        string image;


        public AjoutFilm()
        {
            InitializeComponent();
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

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            string titre = textBoxTitre.Text;
            string synopsis = textBoxSynopsis.Text;
            int ordre = Int32.Parse(textBoxOrdre.Text);
            Film film = new Film(titre, synopsis, ordre, image);
            manager.MonEnsemble.AjouterElement((Element)film);
            manager.SauvegardeDonnees();
            this.Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
