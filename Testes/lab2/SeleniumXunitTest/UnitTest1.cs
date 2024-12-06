using System;	
using Xunit;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
public class SeleniumTests : IDisposable	
{	
    private readonly IWebDriver _driver;	
    public SeleniumTests()	
    {	
        // Configurar o ChromeDriver
        _driver = new ChromeDriver();	
    }	
    [Fact]	
    public void GoogleSearchTest()	
    {	
        // Navegar para o site do Google	
        _driver.Navigate().GoToUrl("https://www.google.com");	
        // Encontrar a caixa de pesquisa pelo atributo name	
        IWebElement searchBox = _driver.FindElement(By.Name("q"));	
        // Realizar a pesquisa	
        searchBox.SendKeys("Selenium WebDriver");	
        searchBox.SendKeys(Keys.Enter);	
        // Esperar um pouco para ver os resultados	
        System.Threading.Thread.Sleep(3000);	
        // Verificar se o título da página contém "Selenium WebDriv
        Assert.Contains("Selenium WebDriver", _driver.Title);	
    }	
    public void Dispose()	
    {	
        // Fechar o navegador	
        _driver.Quit();	
        _driver.Dispose();	
    }	
}	