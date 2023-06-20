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
            Personnel personnel1 = new Personnel("TestNom","TestPrenom","TestEmail@gmail.com");
            personnel1.Create();
            Personnel personnel2 = new Personnel("TestNom", "TestPrenom", "TestEmail@gmail.com");
            personnel2.Read();
            Assert.AreEqual(personnel1.Id_personnel, personnel2.Id_personnel,"Test du create");
        }

    
       

        [TestMethod()]
        public void ReadTest()
        {

        }

        [TestMethod()]
        public void UpdateTest()
        {

        }

        [TestMethod()]
        public void DeleteTest()
        {
            Personnel personnel1 = new Personnel("TestNom1", "TestPrenom1", "TestEmail1@gmail.com");
            personnel1.Create();
            personnel1.Delete();
            Personnel personnel2 = new Personnel("TestNom1", "TestPrenom1", "TestEmail1@gmail.com");
            personnel1.Read();
            Assert.AreEqual(0, personnel2.Id_personnel, "Test du delete");
        }

        [TestMethod()]
        public void FindBySelectionTest()
        {

        }
    }
}