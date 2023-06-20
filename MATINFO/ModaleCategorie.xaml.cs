using MATINFO;
using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MATINFO
{
    /// <summary>
    /// Logique d'interaction pour la fenêtre de la modale de catégorie.
    /// </summary>
    public partial class ModaleCategorie : Window
    {
        /// <summary>
        /// Obtient ou définit les données de gestion de catégorie.
        /// </summary>
        public Gestion GestionCategorie { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ModaleCategorie"/>.
        /// </summary>
        public ModaleCategorie()
        {
            InitializeComponent();
            GestionCategorie = (Gestion)Application.Current.MainWindow.DataContext;
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

              

              
                if (string.IsNullOrEmpty(nouveauNom))
                {
                    MessageBox.Show("Veuillez remplir tous les champs pour ajouter un materiel.", "Ajout", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else if(!string.IsNullOrEmpty(nouveauNom)) 
                {
                    categorieSelectionnee.Nomcategorie = nouveauNom;


                    categorieSelectionnee.Update();


                    GestionCategorie.Refresh();


                    tbSaisie.Text = "";
                    lvCategorie.ItemsSource = gestion.LesCategories;
                }
            }
            else
                MessageBox.Show("Veuillez de séléctionner dans la liste un personnel à modifier", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);

        
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

