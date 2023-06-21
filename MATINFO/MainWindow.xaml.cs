using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MATINFO.Model;
using System.Collections.ObjectModel;

namespace MATINFO
{
    /// <summary>
    /// Classe fenêtre MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        ModaleCategorie pageCategorie = new ModaleCategorie();
        ModaleMateriel pageMateriel = new ModaleMateriel();
        ModaleAttribution pageAttribution = new ModaleAttribution();
        ModalePersonnel pagePersonnel = new ModalePersonnel();
        LoginWindow login = new LoginWindow();

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            login.ShowDialog();
            InitializeComponent();
        }

        private async void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                Hide();
                login.passwordBox.Password = "";
                login.usernameTextBox.Text = "";
                login.lbInformation.Text = "Vous avez été déconnecté";
                login.lbInformation.Foreground = Brushes.Red;
                login.progressBar.IsIndeterminate = false;

                login.usernameTextBox.Focus();
                login.ShowDialog();
                ShowDialog();
            }
        }

        private void Categorie_Click(object sender, RoutedEventArgs e)
        {
            pageCategorie.Owner = this;
            pageCategorie.ShowDialog();
        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            pagePersonnel.Owner = this;
            pagePersonnel.ShowDialog();
        }

        private void Attributions_Click(object sender, RoutedEventArgs e)
        {
            pageAttribution.Owner = this;
            pageAttribution.ShowDialog();
        }

        private void Materiel_Click(object sender, RoutedEventArgs e)
        {
            pageMateriel.Owner = this;
            if (pageMateriel.cbFiltre.SelectedIndex == -1)
                pageMateriel.lvMateriel.ItemsSource = null;

            pageMateriel.ShowDialog();
        }

        private void cbMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materiel materiel = (Materiel)cbMateriel.SelectedItem;

            if (materiel != null)
            {
                ObservableCollection<Attribution> filtreAttribution = gestion.FiltrageAttibution(materiel);
                lbAttributions.ItemsSource = filtreAttribution;
            }
        }

        private void AfficherToutesAttributions_Click(object sender, RoutedEventArgs e)
        {
            cbMateriel.SelectedItem = null;
            lbAttributions.ItemsSource = gestion.LesAttributions;
        }
    }
}
