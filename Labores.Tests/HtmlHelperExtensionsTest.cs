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
using System.Linq.Expressions;
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


        #region InstructionsFor

        public void InstructionsForTestHelper<TModel>(TModel model, string property, string expectedString = "")
        {
            HtmlHelper<TModel> html = MvcHelper.GetHtmlHelper<TModel>(new ViewDataDictionary<TModel>(model));

            MvcHtmlString expected = new MvcHtmlString(expectedString); // TODO: Inicializar en un valor adecuado
            MvcHtmlString actual;
            var item = html.ViewContext as ControllerContext;
            actual = html.InstructionsForOBS(property);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContext"]);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContexts"]);

            PropertyInfo propertyInfo = model.GetType().GetProperty(property);
            InstructionsAttribute instructionAtt = propertyInfo.GetCustomAttribute<InstructionsAttribute>();

            Assert.IsTrue(actual.ToString().Contains(property), "Generated string not contains {0}", property);
            Assert.IsTrue(actual.ToString().Contains(instructionAtt.Instructions), "Generated string not contains {0}", instructionAtt.Instructions);
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        public void InstructionsForTest()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(), "Property1");
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstructionsFor_Should_Throw_ArgumentNullException_PropertyNullOrEmpty()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(), "");
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstructionsFor_Should_Throw_ArgumentNullException_HTMLHELPER_Is_Null()
        {
            var actual = HtmlHelperExtensions.InstructionsForOBS<TestModel>(null, "Proeper");
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        [ExpectedException(typeof(ArgumentException))]
        public void InstructionsFor_Should_Throw_ArgumentException_PropertyNotExistsOnModel()
        {
            InstructionsForTestHelper<TestModel>(new TestModel(), "Panete");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("InstructionsForOBS")]
        public void InstructionsFor_Should_Throw_ArgumentException_InstructionsAttNotExistsOnModel()
        {
            var model = new TestModel { Property1 = "Property2" };

            InstructionsForTestHelper<TestModel>(model, "panete");
        }

        public void InstructionsForHelperWithExpresion<TModel, TValue>(TModel model, Expression<Func<TModel, TValue>> expression, 
                                                                    string instructions,string property)
        {
            HtmlHelper<TModel> html = MvcHelper.GetHtmlHelper<TModel>(new ViewDataDictionary<TModel>(model));

            MvcHtmlString actual;
            var item = html.ViewContext as ControllerContext;
            
            actual = html.InstructionsForOBS(expression);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContext"]);
            Assert.IsNotNull(html.ViewContext.HttpContext.Items["ScriptContexts"]);


            var accessPropertyString = property.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in accessPropertyString) {
                Assert.IsTrue(actual.ToString().Contains(s), "Generated string not contains {0}", s);
            
            }
            Assert.IsTrue(actual.ToString().Contains(instructions), "Generated string not contains {0}", instructions);
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        public void IntructionsForWithTestExpression()
        {
            var model = new TestModel();
            InstructionsForHelperWithExpresion(model, tm => tm.Property1,"Instructions content","Property1");
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        public void IntructionsForWithTestExpression_ChildProperty()
        {
            var model = new TestModel();
            InstructionsForHelperWithExpresion(model, tm => tm.ComplexProperty.ChildProperty,"Instructions ChildProperty","ComplexProperty.ChildProperty");
        }

        [TestMethod()]
        [TestCategory("InstructionsForOBS")]
        public void IntructionsForWithTestExpression_GrandsonProperty()
        {
            var model = new TestModel();
            InstructionsForHelperWithExpresion(model, tm => tm.ComplexProperty.ChilComplexProperty.GrandsonProperty, "Instructions GrandchildProperty", "ComplexProperty.ChilComplexProperty.GrandsonProperty");
        }
        #endregion

        #region GetPropertyName
        [TestMethod]
        [TestCategory("GetPropertyName")]
        public void GetPropertyNameTest()
        {
            string expected = "Property1";
            string actual = HtmlHelperExtensions.GetPropertyName<TestModel, string>(tm => tm.Property1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("GetPropertyName")]
        public void GetPropertyNameTest_Method()
        {
            string actual = HtmlHelperExtensions.GetPropertyName<TestModel, string>(tm => tm.Method());
        }

        [TestMethod]
        [TestCategory("GetPropertyName")]
        public void GetChildPropertyNameTest()
        {
            string expected = "ComplexProperty.ChildProperty";
            string actual = HtmlHelperExtensions.GetPropertyName<TestModel, string>(tm => tm.ComplexProperty.ChildProperty);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("GetPropertyName")]
        public void GetGrandsonPropertyNameTest()
        {
            string expected = "ComplexProperty.ChilComplexProperty.GrandsonProperty";
            string actual = HtmlHelperExtensions.GetPropertyName<TestModel, string>(tm => tm.ComplexProperty.ChilComplexProperty.GrandsonProperty);
            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region TestModel
        private class TestModel
        {
            [Labores.Web.Attributes.Instructions("Instructions content")]
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public ChildTestModel ComplexProperty { get; set; }
            public string Method()
            {
                return "Panete";
            }
        }
        private class ChildTestModel
        {
            [Labores.Web.Attributes.Instructions("Instructions ChildProperty")]
            public string ChildProperty { get; set; }
            public GrandsonTestModel ChilComplexProperty { get; set; }
        }

        private class GrandsonTestModel
        {
                [Labores.Web.Attributes.Instructions("Instructions GrandchildProperty")]
            public string GrandsonProperty { get; set; }
        }
        #endregion

    }

}
