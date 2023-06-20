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
    public class Attribution : Crud<Attribution>
    {
        private int id_personnel;
        private int id_materiel;
        private int id_attribution;
        private static int numAuto;
        private DateTime dateAttribution;
        private string commentaireAttribution;
        private Personnel personnel;
        private Materiel materiel;



        

        public Attribution()
        {

        }
        public Attribution(int id_personnel, int id_materiel, DateTime dateAttribution, string commentaireAttribution)
        {
           
            this.Id_personnel = id_personnel;
            this.Id_materiel = id_materiel;
            this.DateAttribution = dateAttribution;
            this.CommentaireAttribution = commentaireAttribution;
            Attribution.NumAuto++;
            this.Id_attribution = numAuto;
        }
     
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

        public int Id_attribution
        {
            get
            {
                return this.id_attribution;
            }

            set
            {
                this.id_attribution = value;
            }
        }

        public static int NumAuto
        {
            get
            {
                return numAuto;
            }

            set
            {
                numAuto = value;
            }
        }

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

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"insert into est_attribue (idpersonnel, idmateriel, dateattribution, commentaireattribution) values ('{Id_personnel}','{Id_materiel}','{DateAttribution.ToString("yyyy/MM/dd")}','{CommentaireAttribution}');";
            accesBD.GetData(sql);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM est_attribue WHERE idpersonnel = {Id_personnel} AND idmateriel = {Id_materiel} AND dateattribution = '{DateAttribution.ToString("yyyy/MM/dd")}' AND commentaireattribution = '{CommentaireAttribution}'" ;
            accesBD.GetData(sql);
        }

       
        public ObservableCollection<Attribution> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE est_attribue SET dateattribution ='{DateAttribution.ToString("yyyy/MM/dd")}', commentaireattribution ='{CommentaireAttribution}' WHERE idmateriel = {Id_materiel} AND idpersonnel = {Id_personnel}";
            DataTable datas = accesBD.GetData(sql);
        }
    }
}
