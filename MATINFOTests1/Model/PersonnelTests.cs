using Microsoft.VisualStudio.TestTools.UnitTesting;
using MATINFO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATINFO.Model;
using System.Security.Cryptography.X509Certificates;

namespace MATINFO.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        

        [TestMethod()]
        public void FindAllTest()
        {

        }

        [TestMethod()]
        public void CreateTest()
        {
            Personnel personnel1 = new Personnel("OVEL", "Mattéo", "matteoovel@gmail.com");
            personnel1.Create();

            Personnel personnel2 = new Personnel("OVEL", "Mattéo", "matteoovel@gmail.com");
            personnel2.Read();

            Assert.AreEqual(personnel1, personnel2, "Test de creation d'un Personnel");

        }

        [TestMethod()]
        public void DeleteTest()
        {
            Personnel personnel1 = new Personnel("DE SOUSA", "Hugo", "hugo.desousa@gmail.com");
            personnel1.Create();

            personnel1.Delete();

            Personnel personnel2 = new Personnel("DE SOUSA", "Hugo", "hugo.desousa@gmail.com");
            personnel2.Read();

            Assert.AreEqual(0, personnel2.Id_personnel, "Test de suppression d'un Personnel");

        }

        [TestMethod()]
        public void ReadTest()
        {
            Personnel personnel1 = new Personnel("LAVAL", "Quentin", "Quentin.laval@gmail.com");
            personnel1.Create();

            Personnel personnel2 = new Personnel("LAVAL", "Quentin", "Quentin.laval@gmail.com");
            personnel2.Read();

            Assert.AreEqual(personnel1, personnel2, "Test de lecture d'un Personnel");

        }

        [TestMethod()]
        public void UpdateTest()
        {
            Personnel personnel1 = new Personnel("DIARD", "Benoît", "benoît.diard@gmail.com");
            personnel1.Create();

            personnel1.Prenom = "Nathalie";
            personnel1.Nom = "GRUSON";
            personnel1.Email = "nath.gruson@gmail.com";
            personnel1.Update();

            Personnel personnel2 = new Personnel("GRUSON", "Nathalie", "nath.gruson@gmail.com");
            personnel2.Read();

            Assert.AreEqual(personnel2, personnel1, "Test de mise à jour d'un Personnel");

        }

        [TestMethod()]
        public void FindBySelectionTest()
        {

        }
    }
}