using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace WeatherApp.UITests
{
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }


        [Test]
        public void WelcomeTextIsDisplayed()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query cityLabel = x => x.Marked("cityLabel");

            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] cityLabelResult = app.Query(cityLabel);

            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = cityLabelResult?.FirstOrDefault()?.Text;

            // `Assert.AreEqual` tells Xamarin.UITest to compare the expected string, "Welcome to Xamarin Forms!", with the actual string in helloWorldLabelText
            // If the strings are equal, our test will pass.
            // If the strings are not equal, our test will fail.
            Assert.AreEqual("City:", helloWorldLabelText);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
    }
}
