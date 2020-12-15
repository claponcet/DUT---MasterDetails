using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Modele;
using Data;

namespace Modele
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public Manager manager = new Manager(new PersXML());

        public App()
        {
            InitializeComponent();
            manager.ChargeDonnees();
        }
    }
}
