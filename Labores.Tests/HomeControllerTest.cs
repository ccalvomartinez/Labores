using Labores.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using Labores.Entities;
using System.Collections.Generic;

namespace Labores.Tests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para HomeControllerTest y se pretende que
    ///contenga todas las pruebas unitarias HomeControllerTest.
    ///</summary>
    [TestClass()]
    public class HomeControllerTest
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
        ///Una prueba de Index
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        public void IndexTest()
        {
            HomeController target = new HomeController(); 
          
            ActionResult actual;
            actual = target.Index();

            Assert.AreEqual(typeof(ViewResult), actual.GetType());
            var actualView = (ViewResult)actual;

            Assert.IsTrue(typeof(IEnumerable<Labores.Entities.Labor>).IsAssignableFrom(actualView.Model.GetType()));
        }

        /// <summary>
        ///Una prueba de Create
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754/Home/Create")]
        public void CreateTest()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Create();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Create
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void CreateTest1()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            Labor labor = null; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Create(labor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Delete
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void DeleteTest()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            int id = 0; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Delete(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de DeleteConfirmed
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void DeleteConfirmedTest()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            int id = 0; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.DeleteConfirmed(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Details
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void DetailsTest()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            int id = 0; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Details(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Edit
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void EditTest()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            int id = 0; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Edit(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Edit
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:54754")]
        public void EditTest1()
        {
            HomeController target = new HomeController(); // TODO: Inicializar en un valor adecuado
            Labor labor = null; // TODO: Inicializar en un valor adecuado
            ActionResult expected = null; // TODO: Inicializar en un valor adecuado
            ActionResult actual;
            actual = target.Edit(labor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
