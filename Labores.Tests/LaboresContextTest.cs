using Labores.Context.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Labores.Entities;
using Moq;
using System.Data.Entity;

namespace Labores.Tests
{


    /// <summary>
    ///Se trata de una clase de prueba para LaboresContextTest y se pretende que
    ///contenga todas las pruebas unitarias LaboresContextTest.
    ///</summary>
    [TestClass()]
    public class LaboresContextTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de Constructor LaboresContext
        ///</summary>
        [TestMethod()]
        public void LaboresContextAddLaborTest()
        {
            int laboresCount;
            Labores.Entities.Labor labor = new Labores.Entities.Labor { Instrucciones = "Tejer" };
            labor.Materiales = new List<Entities.Material>();
            labor.Materiales.Add(new Labores.Entities.Material { Nombre = "Lana" });

            Mock<DbSet<Labor>> LaboresSet = new Mock<DbSet<Labor>>();
            Mock<DbSet<Material>> MaterialSet = new Mock<DbSet<Material>>();
            Mock<LaboresContext> context = new Mock<LaboresContext>();
          
            context.Setup(c => c.Labores).Returns(LaboresSet.Object);
            context.Setup(c => c.Materiales).Returns(MaterialSet.Object);
            context.Setup(c => c.Set<Labor>()).Returns(LaboresSet.Object);
            
            context.Object.Labores.Add(labor);
            context.Object.SaveChanges();
            laboresCount = context.Object.Labores.Count();

            LaboresSet.Verify(m => m.Add(It.IsAny<Labor>()), Times.Once);
        }
    }
}
