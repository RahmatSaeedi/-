﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Npgsql;
using بانک_اطلاعاتی.Models;
using بانک_اطلاعاتی.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace بانک_اطلاعاتی
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public psql SQL
        {
            get { return App.SQL; }
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ServerSettings_Click(object sender, RoutedEventArgs e)
        {
            mainPageFrame.Navigate(typeof(ServerSettingsPage));
        }

        private void Databases_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
