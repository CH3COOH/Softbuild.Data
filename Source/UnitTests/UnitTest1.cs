using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Softbuild.Data;
using System;
using System.Collections.Generic;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        [TestCategory("取得系")]
        public void GetTest_1()
        {
            var result = Settings.Get<string>("dummy_key");
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("取得系")]
        public void GetTest_2()
        {
            var result = Softbuild.Data.Settings.Get("dummy_key", "default_value");
            Assert.IsNotNull(result);
            Assert.AreEqual<string>(result, "default_value");
        }

        [TestMethod]
        [TestCategory("削除系")]
        public void RemoveTest_1()
        {
            var result = Settings.Get<string>("dummy_key_0001");
            Assert.IsNull(result);

            Settings.Set("dummy_key_0001", "test_value");

            result = Settings.Get<string>("dummy_key_0001");
            Assert.AreEqual<string>(result, "test_value");

            Settings.Remove("dummy_key_0001");

            result = Settings.Get<string>("dummy_key_0001");
            Assert.IsNull(result);
        }
    }
}
