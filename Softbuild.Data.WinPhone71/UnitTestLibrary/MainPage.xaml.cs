using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Softbuild.Data;

namespace UnitTestLibrary
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TestInitialize();
            TestMethod1();
            TestMethod2();
            TestMethod3();
            TestMethod4();
            TestMethod5();
        }

        void TestInitialize()
        {
            Settings.Remove("TestMethod1");
            Settings.Remove("TestMethod2");
            Settings.Remove("TestMethod3");
            Settings.Remove("TestMethod4");
            Settings.Remove("TestMethod5");
        }

        void AssertEquals<T>(T a, T b)
        {
            if (!a.Equals(b))
            {
                throw new Exception();
            }
        }

        void TestMethod1()
        {
            var value = "てすと";
            Settings.Set("TestMethod1", value);

            var getValue = Settings.Get<string>("TestMethod1");
            AssertEquals(getValue, value);
        }

        void TestMethod2()
        {
            var value = 23;
            Settings.Set("TestMethod2", value);

            var getValue = Settings.Get<int>("TestMethod2");
            AssertEquals(getValue, value);
        }

        void TestMethod3()
        {
            var value = 44.3;
            Settings.Set("TestMethod3", value);

            var getValue = Settings.Get<double>("TestMethod3");
            AssertEquals(getValue, value);
        }

        void TestMethod4()
        {
            Settings.Remove("TestMethod4");

            var value = 44.3;
            var getValue = Settings.Get("TestMethod4", value);
            AssertEquals(getValue, value);
        }

        void TestMethod5()
        {
            Settings.Remove("TestMethod5");

            try
            {
                var getValue = Settings.Get<double>("TestMethod5");

                // Settings.Getメソッドで例外が発生しなければテストFailed
                throw new Exception();
            }
            catch
            {
                // テストSuccess
            }
        }
    }
}