using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Parser;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        private string yamlExtension { get; set; }
        private string jsonExtension { get; set; }
        private string csvExtension { get; set; }
        private string txtExtension { get; set; }

        [SetUp]
        public void Setup()
        {
            yamlExtension = ".yaml";
            jsonExtension = ".json";
            csvExtension = ".csv";
            txtExtension = ".text";
        }

        [Test]
        public void GetJsonHandlerObject_EqualTest()
        {
            IProductsHandler productHandler = Factory.GetInstance(jsonExtension);
            Assert.NotNull(productHandler);
            Assert.AreEqual((new JsonProductsHandler()).GetType().FullName, productHandler.GetType().FullName);
        }
        [Test]
        public void GetYamlHandlerObject_EqualTest()
        {
            IProductsHandler productHandler = Factory.GetInstance(yamlExtension);
            Assert.NotNull(productHandler);
            Assert.AreEqual((new YamlProductsHandler()).GetType().FullName, productHandler.GetType().FullName);
        }

        [Test]
        public void GetCsvHandlerObject_EqualTest_Fail()
        {
            IProductsHandler productHandler = Factory.GetInstance(csvExtension);
            Assert.Null(productHandler);
        }

        [Test]
        public void GetTxtHandlerObject_EqualTest_Fail()
        {
            IProductsHandler productHandler = Factory.GetInstance(txtExtension);
            Assert.Null(productHandler);
        }
    }
}
