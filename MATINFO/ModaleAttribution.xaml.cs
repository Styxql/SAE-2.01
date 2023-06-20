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

namespace MATINFO
{


    /// <summary>
    /// Logique d'interaction pour la fenêtre de la modale d'attribution.
    /// </summary>
    public partial class ModaleAttribution : Window
    {
        /// <summary>
        /// Obtient ou définit les données de gestion.
        /// </summary>
        public Gestion GestionData { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ModaleAttribution"/>.
        /// </summary>
        public ModaleAttribution()
        {
            InitializeComponent();
            GestionData = (Gestion)Application.Current.MainWindow.DataContext;
        }

        private void Modale_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }



        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string commentaire = tbCommentaire.Text;
            if (string.IsNullOrEmpty(commentaire) || dpDate.SelectedDate.Value.Date == null || ((Personnel)(cbPersonnel.SelectedValue)).Id_personnel ==null || ((Materiel)(cbMateriel.SelectedValue)).Id_materiel ==null)
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter une attribution.", "Ajout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Attribution attribution = new Attribution(((Personnel)(cbPersonnel.SelectedValue)).Id_personnel, ((Materiel)(cbMateriel.SelectedValue)).Id_materiel, dpDate.SelectedDate.Value.Date, commentaire);
                attribution.Create();
                gestion.Refresh();
                lvAttributions.ItemsSource = gestion.LesAttributions;
                tbCommentaire.Text = "";
                cbMateriel.SelectedItem = null;
                cbPersonnel.SelectedItem = null;
            }


        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttributions.SelectedItem != null)
            {
                Attribution attributionSelectionne = (Attribution)lvAttributions.SelectedItem;
                MessageBoxResult resulat = MessageBox.Show("Etes vous sur de vouloir supprimer : " + attributionSelectionne.Personnel.Nom + " " + attributionSelectionne.Materiel.Nom_materiel, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resulat == MessageBoxResult.Yes)
                {
                    attributionSelectionne.Delete();
                    gestion.Refresh();
                    lvAttributions.ItemsSource = gestion.LesAttributions;

                }

                else MessageBox.Show("Veuillez séléctionner dans la liste une attribution à supprimer", "Suppression", MessageBoxButton.OK, MessageBoxImage.Warning);



            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttributions.SelectedItem != null)
            {
                Attribution attribution = (Attribution)lvAttributions.SelectedItem;
                string commentaire = tbCommentaire.Text;
                DateTime? date = dpDate.SelectedDate;

                if (string.IsNullOrEmpty(commentaire) || date == null)
                {
                    MessageBox.Show("Veuillez remplir tous les champs pour modifier une attribution.", "Mofification", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    attribution.CommentaireAttribution = commentaire;

                    attribution.DateAttribution = date.Value;

                    attribution.Update();
                    gestion.Refresh();
                    lvAttributions.ItemsSource = gestion.LesAttributions;
                    tbCommentaire.Text = "";
                    cbMateriel.SelectedItem = null;
                    cbPersonnel.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner dans la liste une attribution à modifier", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
