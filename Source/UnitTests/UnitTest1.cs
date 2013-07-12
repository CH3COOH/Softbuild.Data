using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Softbuild.Data;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hoge = Settings.Get<string>("hoge");
            Assert.IsNotNull(hoge);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var hoge = Softbuild.Data.Settings.Get("hoge", "dddddd");
            Assert.IsNull(hoge);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var hoge = Settings.Get<bool>("eeee");
            Assert.IsNotNull(hoge);
        }
    }
}
