using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO
{
    public class Materiel :Crud<Materiel>
    {
        private int id_materiel;
        private Categorie categorie;
        private int id_categorie;
        private string code_barre;
        private string nom_materiel;
        private string ref_constructeur;

        
        public Materiel()
        {

        }

        public Materiel(int id_materiel, int id_categorie, string code_barre, string nom_materiel, string ref_constructeur)
        {
            this.Id_materiel = id_materiel;
            this.Id_categorie = id_categorie;
            this.Code_barre = code_barre;
            this.Nom_materiel = nom_materiel;
            this.Ref_constructeur = ref_constructeur;
        }

        public Materiel(int id_categorie, string code_barre, string nom_materiel, string ref_constructeur)
        {
            this.Id_materiel = id_materiel;
            this.Id_categorie = id_categorie;
            this.Code_barre = code_barre;
            this.Nom_materiel = nom_materiel;
            this.Ref_constructeur = ref_constructeur;
        }




        public string Code_barre
        {
            get
            {
                return this.code_barre;
            }

            set
            {
                this.code_barre = value;
            }
        }

        public string Nom_materiel
        {
            get
            {
                return this.nom_materiel;
            }

            set
            {
                this.nom_materiel = value;
            }
        }

        public string Ref_constructeur
        {
            get
            {
                return this.ref_constructeur;
            }

            set
            {
                this.ref_constructeur = value;
            }
        }

        public int Id_materiel
        {
            get
            {
                return this.id_materiel;
            }

            set
            {
                this.id_materiel = value;
            }
        }

        public int Id_categorie
        {
            get
            {
                return this.id_categorie;
            }

            set
            {
                this.id_categorie = value;
            }
        }

        public Categorie Categorie
        {
            get
            {
                return this.categorie;
            }

            set
            {
                this.categorie = value;
            }
        }

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "SELECT idmateriel, idcategorie, codebarreinventaire, referenceconstructeurmateriel,nommateriel FROM materiel;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["idmateriel"].ToString()), (int)row["idcategorie"], (String)row["codebarreinventaire"], (String)row["referenceconstructeurmateriel"], (String)row["nommateriel"]);
                    lesMateriels.Add(m);
                }
            }
            return lesMateriels;
        }
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into materiel (idmateriel, idcategorie, codebarreinventaire, referenceconstructeurmateriel, nommateriel) values (nextval('materiel_idmateriel_seq'::regclass),'{Id_categorie}','{Code_barre}','{Ref_constructeur}','{Nom_materiel}')";
            accesBD.GetData(sql);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM materiel WHERE idmateriel = {Id_materiel}";
            accesBD.GetData(sql);
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE materiel SET idcategorie = '{Id_categorie}', codebarreinventaire ='{Code_barre}', referenceconstructeurmateriel = '{Ref_constructeur}'  WHERE idmateriel = {Id_materiel}";
            DataTable datas = accesBD.GetData(sql);
        }



        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        
    }
}
