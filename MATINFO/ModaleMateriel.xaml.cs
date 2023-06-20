﻿using MATINFO.Model;
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
    /// Logique d'interaction pour ModaleMateriel.xaml
    /// </summary>
    public partial class ModaleMateriel : Window
    {
        public Gestion GestionData { get; set; }

        public ModaleMateriel()
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
            string codeBarre = txtCodeBarre.Text;
            string nomMat = txtNomMat.Text;
            string reference = txtRef.Text;
            
                Materiel materiel = new Materiel(((Categorie)(cbMateriel.SelectedValue)).Id_categorie, codeBarre, reference, nomMat);
                materiel.Create();
                gestion.Refresh();
                lvMateriel.ItemsSource = gestion.LesMateriels;
                txtCodeBarre.Text = "";
                txtNomMat.Text = "";
                txtRef.Text = "";
                
            
            
        }



        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lvMateriel.SelectedItem != null)
            {
                Materiel materiel = (Materiel)lvMateriel.SelectedItem;
                string codeBarre = txtCodeBarre.Text;
                string nomMat = txtNomMat.Text;
                string reference = txtRef.Text;


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
    }
}
