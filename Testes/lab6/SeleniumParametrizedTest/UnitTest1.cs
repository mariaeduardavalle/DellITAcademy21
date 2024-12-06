namespace SeleniumParametrizedTest;

using System;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
using WebDriverManager;	
using WebDriverManager.DriverConfigs.Impl;
using Xunit;	
public class GoogleSearchTests : IDisposable	
{	
    private readonly IWebDriver _driver;	
    public GoogleSearchTests()	
    {	
        // Usar o WebDriverManager para configurar o ChromeDriver
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();	
    }	
    [Theory]	
    [InlineData("Selenium WebDriver")]	
    [InlineData("xUnit testing")]	
    [InlineData("C# tutorials")]	
    public void TestGoogleSearch(string searchTerm)	
    {	
        // Navegar para a página do Google
        _driver.Navigate().GoToUrl("https://www.bing.com");	
        // Encontrar a caixa de pesquisa pelo atributo name	
        IWebElement searchBox = _driver.FindElement(By.Name("q"));	
        // Realizar a pesquisa	
        searchBox.SendKeys(searchTerm);	
        searchBox.SendKeys(Keys.Enter);	
        // Esperar um pouco para ver os resultados	
        System.Threading.Thread.Sleep(3000);	
        // Verificar se o título da página contém o termo de pesqu
        Assert.Contains(searchTerm, _driver.Title, StringComparison.OrdinalIgnoreCase);	
    }	
    public void Dispose()	
    {	
        // Fechar o navegador	
        _driver.Quit();	
        _driver.Dispose();	
    }	
}	