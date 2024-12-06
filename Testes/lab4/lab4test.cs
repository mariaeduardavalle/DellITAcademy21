// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class UntitledTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void untitled() {
    driver.Navigate().GoToUrl("https://www.google.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
    driver.FindElement(By.Id("APjFqb")).SendKeys("selenium");
    {
      var element = driver.FindElement(By.CssSelector(".gb_Xa"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.Id("APjFqb")).Click();
    driver.FindElement(By.Id("APjFqb")).SendKeys("selenium");
    js.ExecuteScript("window.scrollTo(0,208)");
    driver.Close();
  }
}
