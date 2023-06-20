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

    public partial class ModaleAttribution : Window
    {
        public Gestion GestionData { get; set; }

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

            Attribution attribution = new Attribution(((Personnel)(cbPersonnel.SelectedValue)).Id_personnel, ((Materiel)(cbMateriel.SelectedValue)).Id_materiel, dpDate.SelectedDate.Value.Date, commentaire);
            attribution.Create();
            gestion.Refresh();
            lvAttributions.ItemsSource = gestion.LesAttributions;
            tbCommentaire.Text = "";



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

                else MessageBox.Show("Veuillez de séléctionner dans la liste une attribution à supprimer", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);



            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttributions.SelectedItem != null)
            {
                Attribution attribution = (Attribution)lvAttributions.SelectedItem;
                string commentaire = tbCommentaire.Text;
                DateTime date = dpDate.SelectedDate.Value;
                attribution.CommentaireAttribution = commentaire;
                attribution.DateAttribution = date;
                attribution.Update();
                gestion.Refresh();
                lvAttributions.ItemsSource = gestion.LesAttributions;
                tbCommentaire.Text = "";

            }
        }
    }
}