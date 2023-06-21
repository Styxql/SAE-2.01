using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO
{
    /// <summary>
    /// Classe représentant une attribution de matériel à un personnel
    /// </summary>
    public class Attribution : Crud<Attribution>
    {
        private int id_personnel;
        private int id_materiel;
        private DateTime dateAttribution;
        private string commentaireAttribution;
        private Personnel personnel;
        private Materiel materiel;

        /// <summary>
        /// Constructeur par défaut de la classe Attribution
        /// </summary>
        public Attribution()
        {

        }

        /// <summary>
        /// Constructeur de la classe Attribution
        /// </summary>
        /// <param name="id_personnel">L'identifiant du personnel concerné par l'attribution</param>
        /// <param name="id_materiel">L'identifiant du matériel attribué</param>
        /// <param name="dateAttribution">La date d'attribution du matériel</param>
        /// <param name="commentaireAttribution">Le commentaire associé à l'attribution</param>
        public Attribution(int id_personnel, int id_materiel, DateTime dateAttribution, string commentaireAttribution)
        {
            this.Id_personnel = id_personnel;
            this.Id_materiel = id_materiel;
            this.DateAttribution = dateAttribution;
            this.CommentaireAttribution = commentaireAttribution;
           
        }

        /// <summary>
        /// Définit l'identifiant du personnel concerné par l'attribution
        /// </summary>
        public int Id_personnel
        {
            get
            {
                return this.id_personnel;
            }

            set
            {
                this.id_personnel = value;
            }
        }

        /// <summary>
        /// Définit l'identifiant du matériel attribué
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
        /// Définit la date d'attribution du matériel
        /// </summary>
        public DateTime DateAttribution
        {
            get
            {
                return this.dateAttribution;
            }

            set
            {
                this.dateAttribution = value;
            }
        }

        /// <summary>
        /// Définit le commentaire associé à l'attribution
        /// </summary>
        public string CommentaireAttribution
        {
            get
            {
                return this.commentaireAttribution;
            }

            set
            {
                this.commentaireAttribution = value;
            }
        }

        /// <summary>
        /// Définit le personnel concerné par l'attribution
        /// </summary>
        public Personnel Personnel
        {
            get
            {
                return this.personnel;
            }

            set
            {
                this.personnel = value;
            }
        }

        /// <summary>
        /// Définit le matériel attribué
        /// </summary>
        public Materiel Materiel
        {
            get
            {
                return this.materiel;
            }

            set
            {
                this.materiel = value;
            }
        }

       

        /// <summary>
        /// Retourne toutes les attributions existantes
        /// </summary>
        /// <returns>Une collection observable contenant toutes les attributions</returns>
        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributions = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, idmateriel, dateattribution, commentaireattribution from est_attribue;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution m = new Attribution(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)(row["dateattribution"]), (String)row["commentaireattribution"]);
                    lesAttributions.Add(m);
                }
            }
            return lesAttributions;
        }

        /// <summary>
        /// Création d'une nouvelle attribution dans la BDD
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into est_attribue (idpersonnel, idmateriel, dateattribution, commentaireattribution) values ('{Id_personnel}','{Id_materiel}','{DateAttribution.ToString("yyyy/MM/dd")}','{CommentaireAttribution}');";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Supprime l'attribution de la base de données
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM est_attribue WHERE idpersonnel = {Id_personnel} AND idmateriel = {Id_materiel} AND dateattribution = '{DateAttribution.ToString("yyyy/MM/dd")}' AND commentaireattribution = '{CommentaireAttribution}'";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Recherche les attributions selon les critères spécifiés
        /// </summary>
        /// <param name="criteres">Les critères de recherche</param>
        /// <returns>Une collection observable contenant les attributions correspondantes aux critères de recherche</returns>
        public ObservableCollection<Attribution> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lit les détails de l'attribution à partir de la base de données
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour les informations de l'attribution dans la base de données
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE est_attribue SET dateattribution ='{DateAttribution.ToString("yyyy/MM/dd")}', commentaireattribution ='{CommentaireAttribution}' WHERE idmateriel = {Id_materiel} AND idpersonnel = {Id_personnel}";
            DataTable datas = accesBD.GetData(sql);
        }
    }
}
