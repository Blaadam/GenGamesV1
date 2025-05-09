﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GenGamesV1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow = null;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadingScreen splash = new LoadingScreen();
            splash.Show();
            mainWindow = new MainWindow();
            mainWindow.Show();
            splash.Close();
        }
    }
}
