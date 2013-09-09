using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Softbuild.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [TestCategory("取得系")]
        public async Task Save()
        {
            var strUri = "ms-appx:///Images/UnitTestSmallLogo.png";
#if WINDOWS_PHONE
            strUri = "ms-appx:///Assets/ApplicationIcon.png";
#endif
            var uri = new Uri(strUri);
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            using (var strm = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                var result = await Softbuild.Data.StorageExtensions.SaveToPicturesLibraryAsync("hoge.png", strm);
                Assert.IsNotNull(result);
            }
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
