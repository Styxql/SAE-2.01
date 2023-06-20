using MATINFO.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace MATINFO
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    /// //hugo
    public partial class LoginWindow : Window
    {
        DataAccess access = new DataAccess();
        public LoginWindow()
        {
            InitializeComponent();
            usernameTextBox.Focus();
            progressBar.Visibility = Visibility.Collapsed;
        }
        private void Login_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }



        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (access.VerifyUserCredentials(usernameTextBox.Text, passwordBox.Password)
         )
            { 
                lbInformation.Text = "";
            progressBar.Visibility = Visibility.Visible;
            this.lbInformation.Foreground = Brushes.Green;
            this.lbInformation.Text = "Connexion réussie";
            progressBar.IsIndeterminate = true;
            await Task.Delay(2000);
            this.Hide();
        }

           else
            {
                progressBar.IsIndeterminate = false;
                this.lbInformation.Foreground = Brushes.Red;
                this.lbInformation.Text = $"Connexion échouée";
                passwordBox.Password = "";
            }
        }
    }
}

