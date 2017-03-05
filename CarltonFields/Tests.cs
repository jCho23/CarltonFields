using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CarltonFields
{
	[TestFixture(Platform.Android)]
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
		public void SmokeTest()
		{
			app.Screenshot("SmokeTest");
		}


		[Test]
		public void FirstTest()
		{
			app.Tap(x => x.Class("android.widget.Button"));
			app.Screenshot("Tapped on 'OK, I Agree' button");

			app.WaitForElement("OFFICES");
			app.ScrollDown();
			app.ScrollDown();
			app.Screenshot("Scrolling down to 'My Favorites'");

			app.Tap(x => x.Class("android.widget.TextView").Text("MY FAVORITES"));
			app.Screenshot("Tapped on 'My Favorites'");

			app.Tap(x => x.Class("android.widget.TextView").Text("My Offices"));
			app.Screenshot("Tapped on 'My Offices' button");

			app.Tap(x => x.Class("android.widget.ImageView").Index(0));
			app.Screenshot("Tapped on Hamburger Icon");

			app.Tap(x => x.Class("android.widget.TextView").Index(0));
			app.Tap(x => x.Class("android.widget.Button"));
			app.Screenshot("Tapped on 'OK, I Agree' button to go back to Main Menu");

			app.Tap(x => x.Class("android.widget.TextView").Text("OFFICES"));
			app.Screenshot("Tapped on Offices");

			app.ScrollDown();
			app.ScrollDown();
			app.ScrollDown();
			app.Screenshot("Scrolling down to 'Washington, D.C.'");

			app.WaitForElement("Washington, D.C.");
			app.Tap("Washington, D.C.");
			app.Screenshot("Tapped on Washington, D.C.");


			app.WaitForElement("Map");
			app.Tap(x => x.Class("android.view.ViewGroup").Index(19));
			app.Screenshot("Tapped on Heart Icon");

			app.Back();
			app.Screenshot("Pressed Back Button");

			app.Tap(x => x.Class("android.widget.ImageView").Index(0));
			app.Screenshot("Tapped on Hamburger Icon");

			app.Tap(x => x.Class("android.widget.TextView").Index(0));
			app.Tap(x => x.Class("android.widget.Button"));
			app.Screenshot("Tapped on 'OK, I Agree' button to go back to Main Menu");

		}
	}
}
