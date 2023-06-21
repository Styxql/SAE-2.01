using MATINFO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MATINFO
{
    /// <summary>
    /// Représente une classe pour gérer les informations relatives au personnel.
    /// </summary>
    public class Personnel : Crud<Personnel>
    {
        private int id_personnel;
        private string nom;
        private string prenom;
        private string email;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Personnel avec les valeurs par défaut.
        /// </summary>
        public Personnel()
        {

        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Personnel avec les valeurs spécifiées.
        /// </summary>
        /// <param name="id_personnel">L'identifiant du personnel.</param>
        /// <param name="nom">Le nom du personnel.</param>
        /// <param name="prenom">Le prénom du personnel.</param>
        /// <param name="email">L'adresse e-mail du personnel.</param>
        public Personnel(int id_personnel, string nom, string prenom, string email)
        {
            this.Id_personnel = id_personnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Personnel avec les valeurs spécifiées (sans l'identifiant).
        /// </summary>
        /// <param name="nom">Le nom du personnel.</param>
        /// <param name="prenom">Le prénom du personnel.</param>
        /// <param name="email">L'adresse e-mail du personnel.</param>
        public Personnel(string nom, string prenom, string email)
        {
            this.Id_personnel = id_personnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }

        /// <summary>
        /// Obtient ou définit le nom du personnel.
        /// </summary>
        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value.ToUpper();
            }
        }

        /// <summary>
        /// Obtient ou définit le prénom du personnel.
        /// </summary>
        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                if (value != null)
                {
                    this.prenom = char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    this.prenom = "";
                }
            }
        }

        /// <summary>
        /// Obtient ou définit l'adresse e-mail du personnel.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du personnel.
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
        /// Récupère tous les personnels depuis la source de données.
        /// </summary>
        /// <returns>Retourne une collection de personnels.</returns>
        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, nompersonnel, prenompersonnel, emailpersonnel from personnel;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel p = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["nompersonnel"], (String)row["prenompersonnel"], (String)row["emailpersonnel"]);
                    lesPersonnels.Add(p);
                }
            }
            return lesPersonnels;
        }

        /// <summary>
        /// Crée un nouveau personnel dans la source de données.
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into personnel (idpersonnel, nompersonnel, prenompersonnel, emailpersonnel) values (nextval('personnel_idpersonnel_seq'::regclass), '{Nom}', '{Prenom}', '{Email}')";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Lit les informations du personnel depuis la source de données.
        /// </summary>
        public void Read()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"select idpersonnel, nompersonnel, prenompersonnel, emailpersonnel from personnel where idpersonnel = {Id_personnel}";
            DataTable datas  = accesBD.GetData(sql);

            
        }

        /// <summary>
        /// Met à jour les informations du personnel dans la source de données.
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE personnel SET nompersonnel = '{Nom}', prenompersonnel = '{Prenom}', emailpersonnel = '{Email}' WHERE idpersonnel = {Id_personnel}";
            DataTable datas = accesBD.GetData(sql);
        }

        /// <summary>
        /// Supprime le personnel de la source de données.
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM personnel WHERE idpersonnel = {Id_personnel}";
            accesBD.GetData(sql);
        }

        /// <summary>
        /// Recherche les personnels en fonction des critères de sélection.
        /// </summary>
        /// <param name="criteres">Les critères de sélection.</param>
        /// <returns>Retourne une collection de personnels correspondant aux critères de sélection.</returns>
        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
