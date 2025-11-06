using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightCICD
{
    [TestFixture]
    public class PlaywrightTest1
    {
        [Test]

        public async Task FirstTest()
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();

            // Launch a Chrome browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set to false to see the browser UI
                Channel = "chrome" // Specifically use Chrome browser
            });

            // Create a new page
            var page = await browser.NewPageAsync();

            // Navigate to Amazon website
            await page.GotoAsync("https://www.amazon.com");

            // Optional: Add a small delay to see the page
            await Task.Delay(3000);

            // Verify that Amazon page loaded (check title contains "Amazon")

        }

        [Test]
       
         public async Task Search()
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();

            // Launch a Chrome browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set to false to see the browser UI
                Channel = "chrome" // Specifically use Chrome browser
            });

            // Create a new page
            var page = await browser.NewPageAsync();

            // Navigate to Amazon website
            await page.GotoAsync("https://www.amazon.com");

            // Optional: Add a small delay to see the page
            await Task.Delay(3000);

            await page.Locator("//input[@placeholder='Search Amazon.in']").ClickAsync();
            await page.Locator("//input[@placeholder='Search Amazon.in']").FillAsync("Puma shoes");
            await page.WaitForTimeoutAsync(10000);
        }

        
    }
}
