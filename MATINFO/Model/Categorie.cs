using MATINFO.Model;
using Npgsql;
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
    /// Classe représentant une catégorie de matériel.
    /// </summary>
    public class Categorie : Crud<Categorie>
    {
        private int id_categorie;
        private string nomcategorie;

        /// <summary>
        /// Constructeur par défaut de la classe Categorie.
        /// </summary>
        public Categorie()
        {

        }

        /// <summary>
        /// Constructeur de la classe Categorie.
        /// </summary>
        /// <param name="id_categorie">L'identifiant de la catégorie.</param>
        /// <param name="nomcategorie">Le nom de la catégorie.</param>
        public Categorie(int id_categorie, string nomcategorie)
        {
            this.Id_categorie = id_categorie;
            this.Nomcategorie = nomcategorie;
        }

        /// <summary>
        /// Constructeur de la classe Categorie.
        /// </summary>
        /// <param name="nomcategorie">Le nom de la catégorie.</param>
        public Categorie(string nomcategorie)
        {
            this.Id_categorie = id_categorie;
            this.Nomcategorie = nomcategorie;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la catégorie.
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
        /// Obtient ou définit le nom de la catégorie.
        /// </summary>
        public string Nomcategorie
        {
            get
            {
                return this.nomcategorie;
            }

            set
            {
                this.nomcategorie = value;
            }
        }

        /// <summary>
        /// Retourne toutes les catégories de matériel existantes.
        /// </summary>
        /// <returns>Une collection observable contenant toutes les catégories de matériel.</returns>
        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from categorie_materiel;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie c = new Categorie(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesCategories.Add(c);
                }
            }
            return lesCategories;
        }

        /// <summary>
        /// Crée une nouvelle catégorie de matériel dans la base de données.
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into categorie_materiel (idcategorie, nomcategorie) values (nextval('categorie_materiel_idcategorie_seq'::regclass), '{Nomcategorie}')";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Supprime la catégorie de matériel de la base de données.
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM categorie_materiel WHERE idcategorie = {Id_categorie}";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Met à jour les informations de la catégorie de matériel dans la base de données.
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE categorie_materiel SET nomcategorie = '{Nomcategorie}' WHERE idcategorie = {Id_categorie}";
            DataTable datas = accesBD.GetData(sql);
        }

        /// <summary>
        /// Recherche les catégories de matériel en fonction des critères spécifiés.
        /// </summary>
        /// <param name="criteres">Les critères de recherche.</param>
        /// <returns>Une collection observable contenant les catégories de matériel correspondantes aux critères de recherche.</returns>
        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lit les détails de la catégorie de matériel à partir de la base de données.
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
