using Labores.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Labores.Tests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para XMLContextTest y se pretende que
    ///contenga todas las pruebas unitarias XMLContextTest.
    ///</summary>
    [TestClass()]
    public class XMLContextTest
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
        ///Una prueba de SaveChanges
        ///</summary>
        [TestMethod()]
        public void SaveChangesTest()
        {
            string contextString = @"D:\Labores.xml"; 
            XMLContext target = new XMLContext(contextString);
            Entities.Labor labor = new Entities.Labor { Instrucciones = "Haz punto" };
            labor.Materiales.Add(new Entities.Material { Nombre = "Lana" });
            target.Labores.Add(labor);
            target.SaveChanges();
            XMLContext result = new XMLContext(contextString);

            Assert.AreEqual(1, result.Labores.Count);
            Assert.AreEqual("Haz punto", result.Labores[0].Instrucciones);
        }
    }
}
