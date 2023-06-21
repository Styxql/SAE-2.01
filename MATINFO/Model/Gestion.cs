using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO.Model
{
    /// <summary>
    /// Classe de gestion principale pour la manipulation des données
    /// </summary>
    public class Gestion
    {
        /// <summary>
        /// Définit la collection des catégories
        /// </summary>
        public ObservableCollection<Categorie> LesCategories { get; set; }

        /// <summary>
        /// Définit la collection des personnels
        /// </summary>
        public ObservableCollection<Personnel> LesPersonnels { get; set; }

        /// <summary>
        /// Définit la collection des matériels
        /// </summary>
        public ObservableCollection<Materiel> LesMateriels { get; set; }

        /// <summary>
        /// Définit la collection des attributions
        /// </summary>
        public ObservableCollection<Attribution> LesAttributions { get; set; }

        /// <summary>
        /// Constructeur de la classe Gestion
        /// </summary>
        public Gestion()
        {
            Refresh();
        }

        /// <summary>
        /// Fait un filtrage des attributions selon le matériel spécifié.
        /// </summary>
        /// <param name="materiel">Le matériel pour lequel effectuer le filtrage des attributions</param>
        /// <returns>Retourne une collection d'attributions filtrées</returns>
        public ObservableCollection<Attribution> FiltrageAttibution(Materiel materiel)
        {
            ObservableCollection<Attribution> filtreAttributions = new ObservableCollection<Attribution>(
                LesAttributions.Where(attribution => attribution.Materiel == materiel)
            );

            return filtreAttributions;
        }

        /// <summary>
        /// Fait un filtrage des matériels selon la categorie spécifiée.
        /// </summary>
        /// <param name="categorie">La categorie pour laquelle effectuer le filtrage des materiels</param>
        /// <returns>Retourne une collection de materiels filtrées</returns>
        public ObservableCollection<Materiel> FiltrageMateriel(Categorie categorie)
        {
            ObservableCollection<Materiel> filtreMateriel = new ObservableCollection<Materiel>(
                LesMateriels.Where(materiel => materiel.Categorie == categorie)
            );

            return filtreMateriel;
        }



        /// <summary>
        /// Actualise les collections de données en récupérant les données à partir des sources
        /// </summary>
        public void Refresh()
        {
            Categorie c = new Categorie();
            LesCategories = c.FindAll();
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();
            Materiel m = new Materiel();
            LesMateriels = m.FindAll();
            Attribution a = new Attribution();
            LesAttributions = a.FindAll();

            foreach (Materiel materiel in LesMateriels)
            {
                materiel.Categorie = LesCategories.First(c => c.Id_categorie == materiel.Id_categorie);
            }

            foreach (Attribution attribution in LesAttributions)
            {
                attribution.Materiel = LesMateriels.First(m => m.Id_materiel == attribution.Id_materiel);
                attribution.Personnel = LesPersonnels.First(p => p.Id_personnel == attribution.Id_personnel);
            }
        }
    }
}
