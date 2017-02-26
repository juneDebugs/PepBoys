using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PepBoys
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
			app.Screenshot("App launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			//E-Mail= pepboys@microsoft.com
			//Password: microsoft1
			app.Tap(x => x.Css("input[ng-model=\"user.email\"]"));
			app.Screenshot("Let's start by Tapping on the 'Email' Text Field");

			app.EnterText("pepboys@microsoft.com");
			app.Screenshot("We entered our e-mail,'pepboys@microsoft.com'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css("input[ng-model=\"user.password\"]"));
			app.Screenshot("Then we Tapped on the 'Password' Text Field");
			app.EnterText("microsoft1");
			app.Screenshot("We entered our password,'microsoft1'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css("button[class=\"button pb-button\"]"));
			app.Screenshot("Then we Tapped on the 'sign in' Button");

			app.Tap(x => x.Css(".nobr"));
			app.Screenshot("Next, we Tapped on 'Change Location'");

			app.Tap(x => x.Css(".ng-pristine.ng-untouched.ng-valid.ng-valid-minlength.ng-valid-maxlength"));
			app.Screenshot("We Tapped on the 'Change Location' Text Field");
			app.EnterText("94111");
			app.Screenshot("Then we entered in our zip code, '94111'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css(".button"));
			app.Screenshot("We Tapped on the Sign In Button");

			app.Tap(x => x.Css(".store-card-details.ng-binding"));
			app.Screenshot("We Tapped on the 'San Leandro' location");
		}

	}
}
