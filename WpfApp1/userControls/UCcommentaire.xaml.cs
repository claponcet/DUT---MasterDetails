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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.userControls
{
    /// <summary>
    /// Logique d'interaction pour UCcommentaire.xaml
    /// </summary>
    public partial class UCcommentaire : UserControl
    {
        public UCcommentaire()
        {
            InitializeComponent();
        }

        public int Note
        {
            get { return (int)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(int), typeof(UCcommentaire), new PropertyMetadata(0));


        public string Commentaire
        {
            get { return (string)GetValue(CommentaireProperty); }
            set { SetValue(CommentaireProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Commentaire.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentaireProperty =
            DependencyProperty.Register("Commentaire", typeof(string), typeof(UCcommentaire), new PropertyMetadata("commentaire"));



        public string Pseudo
        {
            get { return (string)GetValue(PseudoProperty); }
            set { SetValue(PseudoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Auteur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PseudoProperty =
            DependencyProperty.Register("Pseudo", typeof(string), typeof(UCcommentaire), new PropertyMetadata("pseudo"));


    }
}
