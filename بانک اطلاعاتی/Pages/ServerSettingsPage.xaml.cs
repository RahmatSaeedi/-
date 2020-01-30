using System;
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
using بانک_اطلاعاتی.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace بانک_اطلاعاتی.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServerSettingsPage : Page
    {
        public ServerSettingsPage()
        {
            this.InitializeComponent();
            hostTextBox.Text = "localhost";
            databaseTextBox.Text = "postgres";
            usernameTextBox.Text = "postgres";
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            bool requiredFieldsMissing = false;
            if (String.IsNullOrEmpty(hostTextBox.Text))
            {
                hostTextBox.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,255,200,200));
                requiredFieldsMissing = true;
            }
            if (String.IsNullOrEmpty(databaseTextBox.Text))
            {
                databaseTextBox.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 200, 200));
                requiredFieldsMissing = true;
            }
            if (String.IsNullOrEmpty(usernameTextBox.Text))
            {
                usernameTextBox.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 200, 200));
                requiredFieldsMissing = true;
            }
            if (String.IsNullOrEmpty(passwordBox.Password))
            {
                passwordBox.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 200, 200));
                requiredFieldsMissing = true;
            }
            if (requiredFieldsMissing)
            {
                return;
            } else
            {
                App.SQL = new psql(hostTextBox.Text, databaseTextBox.Text, usernameTextBox.Text, passwordBox.Password);
                psqlMessages.types result = App.SQL.Connect();
                resultsTextBox.Text = psqlMessages.messages(result);
                resultsTextBox.Foreground = new SolidColorBrush(psqlMessages.messageColour(result));

                //var parent = VisualTreeHelper.GetParent(this);
                
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Background = new SolidColorBrush(Windows.UI.Colors.White);
        }
        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Background = new SolidColorBrush(Windows.UI.Colors.White);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Text = "Not implemented yet.";
            resultsTextBox.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
        }
    }
}
