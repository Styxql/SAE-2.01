using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO.Model
{
    public class Gestion
    {
        public ObservableCollection<Categorie> LesCategories { get; set; }
        public ObservableCollection<Personnel> LesPersonnels { get; set; }
        public ObservableCollection<Materiel> LesMateriels { get; set; }
        public ObservableCollection<Attribution> LesAttributions { get; set; }



        public Gestion()
        {
            Refresh();
        }

        public ObservableCollection<Attribution> FiltrageAttibution(Materiel materiel)
        {
            
            ObservableCollection<Attribution> filtreAttributions = new ObservableCollection<Attribution>(
                LesAttributions.Where(attribution => attribution.Materiel == materiel)
            );

            return filtreAttributions;
        }

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

