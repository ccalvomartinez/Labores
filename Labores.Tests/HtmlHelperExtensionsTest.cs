using Labores.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moq;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Routing;
using System.IO;
using Forloop.HtmlHelpers;
using System.Reflection;
using Labores.Web.Attributes;
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
        public void InstructionsForTestHelper<TModel>(TModel model,string property,string expectedString="")
        {
            HtmlHelper<TModel> html = MvcHelper.GetHtmlHelper<TModel>(new ViewDataDictionary<TModel>(model));

            MvcHtmlString expected = new MvcHtmlString(expectedString); // TODO: Inicializar en un valor adecuado
            MvcHtmlString actual;
            var item = html.ViewContext as ControllerContext;
            actual = HtmlHelperExtensions.InstructionsFor<TModel>(html, property);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContext"]);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContexts"]);

            PropertyInfo propertyInfo = model.GetType().GetProperty(property);
            InstructionsAttribute instructionAtt = propertyInfo.GetCustomAttribute<InstructionsAttribute>();

            Assert.IsTrue(actual.ToString().Contains(property),"Generated string not contains {0}",property);
            Assert.IsTrue(actual.ToString().Contains(instructionAtt.Instructions), "Generated string not contains {0}", instructionAtt.Instructions);
        }

        [TestMethod()]
        public void InstructionsForTest()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(),"Property1");
        }

        [TestMethod()][ExpectedException(typeof(ArgumentNullException))]
        public void InstructionsFor_Should_Throw_ArgumentNullException_PropertyNullOrEmpty()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(), "");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstructionsFor_Should_Throw_ArgumentNullException_HTMLHELPER_Is_Null()
        {
            var actual = HtmlHelperExtensions.InstructionsFor<TestModel>(null, "Proeper");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InstructionsFor_Should_Throw_ArgumentException_PropertyNotExistsOnModel()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(), "Panete");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InstructionsFor_Should_Throw_ArgumentException_InstructionsAttNotExistsOnModel()
        {
            var model = new TestModel { Property1= "Property2" };

            InstructionsForTestHelper<TestModel>(model, "panete");
        }

        private class TestModel {
            [Labores.Web.Attributes.Instructions("Instructions content")]
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        }
    }
   
}
