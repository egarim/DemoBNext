﻿using DevExpress.EasyTest.Framework;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

// To run functional tests for ASP.NET Web Forms and ASP.NET Core Blazor XAF Applications,
// install browser drivers: https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/.
//
// -For Google Chrome: download "chromedriver.exe" from https://chromedriver.chromium.org/downloads.
// -For Microsoft Edge: download "msedgedriver.exe" from https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/.
//
// Selenium requires a path to the downloaded driver. Add a folder with the driver to the system's PATH variable.
//
// Refer to the following article for more information: https://docs.devexpress.com/eXpressAppFramework/403852/

namespace DemoBNext.Module.E2E.Tests;

public class DemoBNextTests : IDisposable {
    const string BlazorAppName = "DemoBNextBlazor";
    const string WinAppName = "DemoBNextWin";
    const string AppDBName = "DemoBNext";
    EasyTestFixtureContext FixtureContext { get; } = new EasyTestFixtureContext();

	public DemoBNextTests() {
        FixtureContext.RegisterApplications(
            new BlazorApplicationOptions(BlazorAppName, string.Format(@"{0}\..\..\..\..\DemoBNext.Blazor.Server", Environment.CurrentDirectory)),
            new WinApplicationOptions(WinAppName, string.Format(@"{0}\..\..\..\..\DemoBNext.Win\bin\EasyTest\net6.0-windows\DemoBNext.Win.exe", Environment.CurrentDirectory))
        );
        FixtureContext.RegisterDatabases(new DatabaseOptions(AppDBName, "DemoBNextEasyTest", server: @"(localdb)\mssqllocaldb"));	           
	}
    public void Dispose() {
        FixtureContext.CloseRunningApplications();
    }
    [Theory]
    [InlineData(BlazorAppName)]
    public void TestBlazorApp(string applicationName) {
        FixtureContext.DropDB(AppDBName);
        var appContext = FixtureContext.CreateApplicationContext(applicationName);
        appContext.RunApplication();
        appContext.GetForm().FillForm(("User Name", "Admin"));
        appContext.GetAction("Log In").Execute();
        Assert.True(appContext.Navigate("My Details"));
        Assert.True(appContext.Navigate("Role"));
        Assert.True(appContext.Navigate("Users"));
    }
    [Theory]
    [InlineData(WinAppName)]
    public void TestWinApp(string applicationName) {
        FixtureContext.DropDB(AppDBName);
        var appContext = FixtureContext.CreateApplicationContext(applicationName);
        appContext.RunApplication();
        appContext.GetForm().FillForm(("User Name", "Admin"));
        appContext.GetAction("Log In").Execute();
        Assert.True(appContext.Navigate("My Details"));
        Assert.True(appContext.Navigate("Role"));
        Assert.True(appContext.Navigate("Users"));
    }
}
