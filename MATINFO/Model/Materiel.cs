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
    /// <summary>
    /// Classe représentant un matériel.
    /// </summary>
    public class Materiel : Crud<Materiel>
    {
        private int id_materiel;
        private Categorie categorie;
        private int id_categorie;
        private string code_barre;
        private string nom_materiel;
        private string ref_constructeur;

        /// <summary>
        /// Constructeur par défaut de la classe Materiel.
        /// </summary>
        public Materiel()
        {

        }

        /// <summary>
        /// Constructeur de la classe Materiel.
        /// </summary>
        /// <param name="id_materiel">L'identifiant du matériel.</param>
        /// <param name="id_categorie">L'identifiant de la catégorie du matériel.</param>
        /// <param name="code_barre">Le code-barre du matériel.</param>
        /// <param name="nom_materiel">Le nom du matériel.</param>
        /// <param name="ref_constructeur">La référence du constructeur du matériel.</param>
        public Materiel(int id_materiel, int id_categorie, string code_barre, string nom_materiel, string ref_constructeur)
        {
            this.Id_materiel = id_materiel;
            this.Id_categorie = id_categorie;
            this.Code_barre = code_barre;
            this.Nom_materiel = nom_materiel;
            this.Ref_constructeur = ref_constructeur;
        }

        /// <summary>
        /// Constructeur de la classe Materiel.
        /// </summary>
        /// <param name="id_categorie">L'identifiant de la catégorie du matériel.</param>
        /// <param name="code_barre">Le code-barre du matériel.</param>
        /// <param name="nom_materiel">Le nom du matériel.</param>
        /// <param name="ref_constructeur">La référence du constructeur du matériel.</param>
        public Materiel(int id_categorie, string code_barre, string nom_materiel, string ref_constructeur)
        {
            this.Id_materiel = id_materiel;
            this.Id_categorie = id_categorie;
            this.Code_barre = code_barre;
            this.Nom_materiel = nom_materiel;
            this.Ref_constructeur = ref_constructeur;
        }

        /// <summary>
        /// Obtient ou définit le code-barre du matériel.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit le nom du matériel.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit la référence du constructeur du matériel.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit l'identifiant du matériel.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit l'identifiant de la catégorie du matériel.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit la catégorie du matériel.
        /// </summary>
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

        /// <summary>
        /// Récupère tous les matériels depuis la source de données.
        /// </summary>
        /// <returns>Retourne une collection de matériels.</returns>
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

        /// <summary>
        /// Crée un nouveau matériel dans la source de données.
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into materiel (idmateriel, idcategorie, codebarreinventaire, referenceconstructeurmateriel, nommateriel) values (nextval('materiel_idmateriel_seq'::regclass),'{Id_categorie}','{Code_barre}','{Ref_constructeur}','{Nom_materiel}')";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Supprime le matériel de la source de données.
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM materiel WHERE idmateriel = {Id_materiel}";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Met à jour les informations du matériel dans la source de données.
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE materiel SET idcategorie = '{Id_categorie}', codebarreinventaire ='{Code_barre}', referenceconstructeurmateriel = '{Ref_constructeur}'  WHERE idmateriel = {Id_materiel}";
            DataTable datas = accesBD.GetData(sql);
        }

        /// <summary>
        /// Recherche des matériels en fonction des critères de sélection spécifiés.
        /// </summary>
        /// <param name="criteres">Les critères de sélection.</param>
        /// <returns>Retourne une collection de matériels correspondant aux critères de sélection.</returns>
        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lit les informations du matériel depuis la source de données.
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
