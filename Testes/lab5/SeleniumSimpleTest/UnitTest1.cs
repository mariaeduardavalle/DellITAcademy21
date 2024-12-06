using System;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
using WebDriverManager;	
using WebDriverManager.DriverConfigs.Impl;
using Xunit;	
public class GoogleSearchTest : IDisposable	
{	
private readonly IWebDriver _driver;	
public GoogleSearchTest()	
{	
// Usar o WebDriverManager para configurar o ChromeDriver
new DriverManager().SetUpDriver(new ChromeConfig());
_driver = new ChromeDriver();	
}	
[Fact]	
public void TestGoogleSearch()	
{	
// Navegar para a página do Google
_driver.Navigate().GoToUrl("https://www.google.com");	
// Encontrar a caixa de pesquisa pelo atributo name	
IWebElement searchBox = _driver.FindElement(By.Name("q"));	
// Realizar a pesquisa	
searchBox.SendKeys("Selenium WebDriver");	
searchBox.SendKeys(Keys.Enter);	
// Esperar um pouco para ver os resultados	
System.Threading.Thread.Sleep(3000);	
// Verificar se o título da página contém "Selenium WebDriv
Assert.Contains("Selenium WebDriver", _driver.Title,
StringComparison.OrdinalIgnoreCase);	
}	
public void Dispose()	
{	
// Fechar o navegador	
_driver.Quit();	
_driver.Dispose();	
}	
}	