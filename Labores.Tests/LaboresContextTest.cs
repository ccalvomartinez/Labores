﻿using Labores.Context.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void LaboresContextConstructorTest()
        {
            using (LaboresContext target = new LaboresContext())
            {
                Labores.Entities.Labor labor = new Labores.Entities.Labor { Instrucciones = "Tejer" };
                labor.Materiales = new List<Entities.Material>();
                labor.Materiales.Add(new Labores.Entities.Material { Nombre = "Lana" });
                target.Labores.Add(labor);
                target.SaveChanges();
            }
            using (LaboresContext result = new LaboresContext())
            {
                Assert.AreEqual(0, result.Labores.Count());
                Assert.AreEqual("Tejer", result.Labores.First().Instrucciones);
            }

        }
    }
}