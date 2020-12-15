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
    /// Logique d'interaction pour AjouterPerso.xaml
    /// </summary>
    public partial class AjoutPerso : Window
    {
        public Manager manager => (App.Current as App).manager;
        List<Film> filmographie = new List<Film>();
        Acteur interprete;
        string image;
        int faction;

        public AjoutPerso()
        {
            InitializeComponent();
            listBoxFilms.DataContext = manager.MonEnsemble;
            comboBoxActeurs.DataContext = manager.MonEnsemble;
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

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxFaction.SelectedIndex)
            {
                case 0:
                    faction = 1;
                    break;
                case 1: faction = 2;
                    break;
                case 2: faction = 3;
                    break;
                default: faction = 0;
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            interprete = e.AddedItems[0] as Acteur;
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
            Personnage personnage;
            string nom = textBoxNom.Text;
            string surnom = textBoxSurnom.Text;
            switch (faction)
            {
                case 1: Allie allie = new Allie(nom, image, surnom);
                    personnage = allie;
                    break;
                case 2:
                    Avenger avenger = new Avenger(nom, image, surnom);
                    personnage = avenger;
                    break;
                case 3:
                    Ennemi ennemi = new Ennemi(nom, image, surnom);
                    personnage = ennemi;
                    break;
                default: personnage = new Allie("nom par défaut", "img", "surnom");
                    break;
            }
            personnage.AjouterInterprete(interprete);
            foreach (Film f in filmographie)
            {
                personnage.AjouterFilm(f);
            }
            manager.MonEnsemble.AjouterElement((Element)personnage);
            manager.SauvegardeDonnees();
            this.Close();
        }
    }
}
