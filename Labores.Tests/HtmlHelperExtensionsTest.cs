using Labores.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moq;
using System.Collections;

namespace Labores.Tests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para HtmlHelperExtensionsTest y se pretende que
    ///contenga todas las pruebas unitarias HtmlHelperExtensionsTest.
    ///</summary>
    [TestClass()]
    public class HtmlHelperExtensionsTest
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
        ///Una prueba de InstructionsFor
        ///</summary>
        public void InstructionsForTestHelper<TModel>(TModel model)
        {
            HtmlHelper<TModel> html = MvcHelper.GetHtmlHelper<TModel>(new ViewDataDictionary<TModel>(model));
            string Property = "Nombre"; // TODO: Inicializar en un valor adecuado
            MvcHtmlString expected = null; // TODO: Inicializar en un valor adecuado
            MvcHtmlString actual;
            actual = HtmlHelperExtensions.InstructionsFor<TModel>(html, Property);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        [TestMethod()]
        public void InstructionsForTest()
        {
            InstructionsForTestHelper<Labores.Entities.Material>(new Labores.Entities.Material());
        }
       
    }
   
}
