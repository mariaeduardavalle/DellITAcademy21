using System;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
using NUnit.Framework;	
namespace SeleniumTests	
{	
public class GoogleSearchTest	
{	
private IWebDriver driver;	
[SetUp]	
public void SetupTest()	
{	
driver = new ChromeDriver();	
}	
[TearDown]	
public void TeardownTest()	
{	
driver.Quit();	
}	
[Test]	
public void TestGoogleSearch()	
{	
driver.Navigate().GoToUrl("https://www.google.com");	
driver.FindElement(By.Name("q")).SendKeys("Selenium WebDriver");	
driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);	
Assert.IsTrue(driver.Title.Contains("Selenium WebDriver"));	
}	
}	
}
