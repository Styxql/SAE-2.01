using MATINFO.Model;
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
using MATINFO;
using System.Collections.ObjectModel;

namespace MATINFO
{
    public partial class ModalePersonnel : Window
    {
        private Gestion gestionPersonnel;

        /// <summary>
        /// Obtient ou définit les données de gestion du personnel
        /// </summary>
        public Gestion GestionPersonnel
        {
            get
            {
                return this.gestionPersonnel;
            }
            set
            {
                this.gestionPersonnel = value;
            }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ModalePersonnel"/>
        /// </summary>
        public ModalePersonnel()
        {
            InitializeComponent();
            GestionPersonnel = (Gestion)Application.Current.MainWindow.DataContext;
        }
    

    private void Modale_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
           
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter un personnel.", "Ajout", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                Personnel personnel = new Personnel(nom, prenom, email);

                personnel.Create();
                gestion.Refresh();
                lvPersonnel.ItemsSource = gestion.LesPersonnels;
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtEmail.Text = "";
            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {
                Personnel personnelSelectionnee = (Personnel)lvPersonnel.SelectedItem;
                string nouveauNom = txtNom.Text;
                string nouveauPrenom = txtPrenom.Text;
                string nouveauEmail = txtEmail.Text;

                if (string.IsNullOrEmpty(nouveauNom) || string.IsNullOrEmpty(nouveauPrenom) || string.IsNullOrEmpty(nouveauEmail))
                {
                    MessageBox.Show("Veuillez remplir tous les champs pour modifier un personnel.", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                                 personnelSelectionnee.Nom = nouveauNom;
                                    personnelSelectionnee.Prenom = nouveauPrenom;
                                    personnelSelectionnee.Email = nouveauEmail;
                                    personnelSelectionnee.Update();
                                    gestion.Refresh();
                                    lvPersonnel.ItemsSource = gestion.LesPersonnels;

                                    txtNom.Text = "";
                                    txtPrenom.Text = "";
                                    txtEmail.Text = "";
                             
                }
            }
            else
                MessageBox.Show("Veuillez de séléctionner dans la liste un personnel à modifier", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {
                
                Personnel personnel = (Personnel)lvPersonnel.SelectedItem;
                MessageBoxResult resulat =  MessageBox.Show("Etes vous sur de vouloir supprimer : " + personnel.Nom + " " + personnel.Prenom, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resulat == MessageBoxResult.Yes)
                {
                    personnel.Delete();
                    gestion.Refresh();
                    lvPersonnel.ItemsSource = gestion.LesPersonnels;
                }
            }

            else MessageBox.Show("Veuillez de séléctionner dans la liste un personnel à supprimer", "Supperssion", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void lvPersonnel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lvPersonnel.SelectedItem = null;
        }
    }
}
