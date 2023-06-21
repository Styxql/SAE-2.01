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

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            Personnel personnel1 = new Personnel("OVEL", "Mattéo", "matteoovel@gmail.com");

            // Act
            personnel1.Create();
            Personnel personnel2 = new Personnel();
            personnel2.Id_personnel = personnel1.Id_personnel;
            personnel2.Read();

            // Assert
            Assert.AreEqual(personnel1.Nom, personnel2.Nom, "Le nom du personnel n'est pas correct.");
            Assert.AreEqual(personnel1.Prenom, personnel2.Prenom, "Le prénom du personnel n'est pas correct.");
            Assert.AreEqual(personnel1.Email, personnel2.Email, "L'adresse e-mail du personnel n'est pas correcte.");
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            Personnel personnel1 = new Personnel("DE SOUSA", "Hugo", "hugo.desousa@gmail.com");
            personnel1.Create();

            // Act
            personnel1.Delete();
            Personnel personnel2 = new Personnel();
            personnel2.Id_personnel = personnel1.Id_personnel;
            personnel2.Read();

            // Assert
            Assert.AreEqual(0, personnel2.Id_personnel, "La suppression du personnel a échoué.");
        }

        [TestMethod]
        public void ReadTest()
        {
            // Arrange
            Personnel personnel1 = new Personnel("LAVAL", "Quentin", "Quentin.laval@gmail.com");
            personnel1.Create();

            // Act
            Personnel personnel2 = new Personnel();
            personnel2.Id_personnel = personnel1.Id_personnel;
            personnel2.Read();

            // Assert
            Assert.AreEqual(personnel1.Nom, personnel2.Nom, "Le nom du personnel n'est pas correct.");
            Assert.AreEqual(personnel1.Prenom, personnel2.Prenom, "Le prénom du personnel n'est pas correct.");
            Assert.AreEqual(personnel1.Email, personnel2.Email, "L'adresse e-mail du personnel n'est pas correcte.");
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            Personnel personnel1 = new Personnel("DIARD", "Benoît", "benoît.diard@gmail.com");
            personnel1.Create();
            personnel1.Prenom = "Nathalie";
            personnel1.Nom = "GRUSON";
            personnel1.Email = "nath.gruson@gmail.com";

            // Act
            personnel1.Update();
            Personnel personnel2 = new Personnel();
            personnel2.Id_personnel = personnel1.Id_personnel;
            personnel2.Read();

            // Assert
            Assert.AreEqual(personnel1.Nom, personnel2.Nom, "La mise à jour du nom du personnel a échoué.");
            Assert.AreEqual(personnel1.Prenom, personnel2.Prenom, "La mise à jour du prénom du personnel a échoué.");
            Assert.AreEqual(personnel1.Email, personnel2.Email, "La mise à jour de l'adresse e-mail du personnel a échoué.");
        }

        [TestMethod()]
        public void FindBySelectionTest()
        {

        }
    }
}