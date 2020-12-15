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
    /// Logique d'interaction pour UC1imgLegende.xaml
    /// </summary>
    public partial class UC1imgLegende : UserControl
    {
        public UC1imgLegende()
        {
            InitializeComponent();
        }



        public string Legende
        {
            get { return (string)GetValue(LegendeProperty); }
            set { SetValue(LegendeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Legende.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendeProperty =
            DependencyProperty.Register("Legende", typeof(string), typeof(UC1imgLegende), new PropertyMetadata("Nom"));



        public string NomImg
        {
            get { return (string)GetValue(NomImgProperty); }
            set { SetValue(NomImgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomImg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomImgProperty =
            DependencyProperty.Register("NomImg", typeof(string), typeof(UC1imgLegende), new PropertyMetadata("Images;Component/img/heros/iron_man.jpg"));


    }
   
    
}
