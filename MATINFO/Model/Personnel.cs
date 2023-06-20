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

    public class Personnel : Crud<Personnel>
    {
        private int id_personnel;
        private string nom;
        private string prenom;
        private string email;

        public Personnel(int id_personnel, string nom, string prenom, string email)
        {
            this.Id_personnel= id_personnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }

        public Personnel(string nom, string prenom, string email)
        {
            this.Id_personnel = id_personnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }
        public Personnel()
        {

        }
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
                else this.prenom = "";
            
            }
        }


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
        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, nompersonnel, prenompersonnel , emailpersonnel from personnel;";
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

        public void Create()
        {

            DataAccess accesBD = new DataAccess();
            string sql = $"insert into personnel (idpersonnel, nompersonnel,prenompersonnel,emailpersonnel) values (nextval('personnel_idpersonnel_seq'::regclass), '{Nom}','{Prenom}','{Email}')";
            accesBD.GetData(sql);
        }
       

        public void Read()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"select idpersonnel, nompersonnel, prenompersonnel , emailpersonnel from personnel where idpersonnel =  {Id_personnel}";
            accesBD.GetData(sql);
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE personnel SET nompersonnel = '{Nom}',prenompersonnel='{Prenom}',emailpersonnel='{Email}' WHERE idpersonnel = {Id_personnel}";
            DataTable datas = accesBD.GetData(sql);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM personnel WHERE idpersonnel = {Id_personnel}";
            accesBD.GetData(sql);
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
