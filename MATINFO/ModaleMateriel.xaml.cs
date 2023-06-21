using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class ModaleMateriel : Window
    {
        /// <summary>
        /// Obtient ou définit les données de gestion
        /// </summary>
        public Gestion GestionData { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ModaleMateriel"/>.
        /// </summary>
        public ModaleMateriel()
        {
            InitializeComponent();
            GestionData = (Gestion)Application.Current.MainWindow.DataContext;
        }


        private void Modale_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            cbFiltre.SelectedIndex = -1;
            this.Hide();
        }



        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string codeBarre = txtCodeBarre.Text;
            string nomMat = txtNomMat.Text;
            string reference = txtRef.Text;
            if (string.IsNullOrEmpty(cbMateriel.Text) || string.IsNullOrEmpty(codeBarre) || string.IsNullOrEmpty(nomMat) || string.IsNullOrEmpty(reference))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter un materiel.", "Ajout", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                Materiel materiel = new Materiel(((Categorie)(cbMateriel.SelectedValue)).Id_categorie, codeBarre, reference, nomMat);
                materiel.Create();
                gestion.Refresh();
                lvMateriel.ItemsSource = gestion.LesMateriels;
                txtCodeBarre.Text = "";
                txtNomMat.Text = "";
                txtRef.Text = "";
                cbMateriel.SelectedItem = null;
                



            }

        }

        private void cbFiltre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = (Categorie)cbFiltre.SelectedItem;

            if (categorie != null)
            {
                ObservableCollection<Materiel> filtreCategorie = gestion.FiltrageMateriel(categorie);
                lvMateriel.ItemsSource = filtreCategorie;
            }
            
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvMateriel.SelectedItem != null)
            {
                Materiel materiel = (Materiel)lvMateriel.SelectedItem;
                string codeBarre = txtCodeBarre.Text;
                string nomMat = txtNomMat.Text;
                string reference = txtRef.Text;

                if (string.IsNullOrEmpty(codeBarre) || string.IsNullOrEmpty(nomMat) || string.IsNullOrEmpty(reference))
                {
                    MessageBox.Show("Veuillez remplir tous les champs pour modifier un materiel.", "Modificaion", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    materiel.Nom_materiel = nomMat;
                    materiel.Code_barre = codeBarre;
                    materiel.Ref_constructeur = reference;
                    materiel.Id_categorie = ((Categorie)(cbMateriel.SelectedValue)).Id_categorie;
                    materiel.Update();
                    gestion.Refresh();
                    lvMateriel.ItemsSource = gestion.LesMateriels;

                    txtCodeBarre.Text = "";
                    txtNomMat.Text = "";
                    txtRef.Text = "";
                    cbMateriel.SelectedItem = null;
                    
                }
            }
        }
        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvMateriel.SelectedItem != null)
            {
                Materiel materiel = (Materiel)lvMateriel.SelectedItem;

                MessageBoxResult resulat = MessageBox.Show("Etes vous sur de vouloir supprimer : " + materiel.Nom_materiel , "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resulat == MessageBoxResult.Yes)
                {
                    materiel.Delete();
                    gestion.Refresh();
                    lvMateriel.ItemsSource = gestion.LesMateriels;
                }
            }
            
            else MessageBox.Show("Veuillez de séléctionner dans la liste un materiel à supprimer", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);

            
            
        }

        private void lvMateriel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lvMateriel.SelectedItem = null;
        }
    }
}
