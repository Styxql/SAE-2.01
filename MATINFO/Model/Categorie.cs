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
    public class Categorie : Crud<Categorie>
    {
        private int id_categorie;
        private string nomcategorie;
        public Categorie()
        {

        }

        public Categorie(int id_categorie, string nomcategorie)
        {
            this.Id_categorie = id_categorie;
            this.Nomcategorie = nomcategorie;
        }



        public Categorie(string nomcategorie)
        {
            this.Id_categorie = id_categorie;
            this.Nomcategorie = nomcategorie;
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
        public void Create()
        {

            DataAccess accesBD = new DataAccess();
            string sql = $"insert into categorie_materiel (idcategorie, nomcategorie) values (nextval('categorie_materiel_idcategorie_seq'::regclass), '{Nomcategorie}')";
            accesBD.GetData(sql);
        }
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"DELETE FROM categorie_materiel WHERE idcategorie = {Id_categorie}";
            accesBD.GetData(sql);
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string sql = $"UPDATE categorie_materiel SET nomcategorie = '{Nomcategorie}' WHERE idcategorie = {Id_categorie}";
            DataTable datas = accesBD.GetData(sql);
        }


        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
       

      
    }
}
