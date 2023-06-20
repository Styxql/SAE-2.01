using MATINFO;
using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MATINFO
{
    public partial class ModaleCategorie : Window
    {
        public Gestion GestionCategorie { get; set; }





        public ModaleCategorie()
        {
            InitializeComponent();
            GestionCategorie = (Gestion)Application.Current.MainWindow.DataContext;

        }



        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

        }

        private void Modale_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
           

        }

      

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nomCategorie = tbSaisie.Text;

            Categorie categorie = new Categorie(nomCategorie);
            categorie.Create();
            GestionCategorie.Refresh();
            tbSaisie.Text = "";
            lvCategorie.ItemsSource = gestion.LesCategories;

        }


        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategorie.SelectedItem != null)
            {
                Categorie categorieSelectionnee = (Categorie)lvCategorie.SelectedItem;
                string nouveauNom = tbSaisie.Text;

              
                categorieSelectionnee.Nomcategorie = nouveauNom;

               
                categorieSelectionnee.Update();

              
                GestionCategorie.Refresh();

         
                tbSaisie.Text = "";
                lvCategorie.ItemsSource = gestion.LesCategories;

            }
        }
        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategorie.SelectedItem != null)
            {
                Categorie categorieSelectionnee = (Categorie)lvCategorie.SelectedItem;

                MessageBoxResult resulat = MessageBox.Show("Etes vous sur de vouloir supprimer : " + categorieSelectionnee.Nomcategorie, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resulat == MessageBoxResult.Yes)
                {
                    categorieSelectionnee.Delete();
                    GestionCategorie.Refresh();
                    lvCategorie.ItemsSource = gestion.LesCategories;
                }
            }

            else MessageBox.Show("Veuillez de séléctionner dans la liste un personnel à supprimer", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);


        }
    }


}

