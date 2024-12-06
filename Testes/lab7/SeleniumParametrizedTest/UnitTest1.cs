namespace SeleniumParametrizedTest;

using System;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
using WebDriverManager;	
using WebDriverManager.DriverConfigs.Impl;
using Xunit;	
using AventStack.ExtentReports;	
using AventStack.ExtentReports.Reporter;	
public class UnitTest1 : IDisposable	
{	
    private readonly IWebDriver _driver;	
    private readonly ExtentReports _extent;	
    private readonly ExtentTest _test;	
    public UnitTest1()	
    {	
        // Usar o WebDriverManager para configurar o ChromeDriver
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();	
        // Configurar o ExtentReports
        var htmlReporter = new ExtentSparkReporter("extent_report.html");	
        _extent = new ExtentReports();	
        _extent.AttachReporter(htmlReporter);	
        // Criar um teste no relatório
        _test = _extent.CreateTest("GoogleSearchTests");	
    }	
    [Fact]	
    public void TestGoogleSearch()	 
    {	
        try	
        {	
            // Navegar para a página do Google
            _driver.Navigate().GoToUrl("https://www.bing.com");	
            _test.Log(Status.Pass, "Navegou para Google.com");	
            // Encontrar a caixa de pesquisa pelo atributo name	
            IWebElement searchBox = _driver.FindElement(By.Name("q"));	
            _test.Log(Status.Pass, "Encontrou a caixa de pesquisa");	
            // Realizar a pesquisa	
            var searchTerm = "Selenium Webdriver";	
            searchBox.SendKeys(searchTerm);	
            searchBox.SendKeys(Keys.Enter);	
            _test.Log(Status.Pass, $"Realizou a pesquisa por {searchTerm}");	
            // Esperar um pouco para ver os resultados	
            System.Threading.Thread.Sleep(3000);	
            // Verificar se o título da página contém o termo de pesqu
            Assert.Contains(searchTerm, _driver.Title, StringComparison.OrdinalIgnoreCase);	
            _test.Log(Status.Pass, $"O título da página contém o termo de pesquisa {searchTerm}");	
        }	
        catch (Exception e)	
        {	
            _test.Log(Status.Fail, e.ToString());	
            throw;	
        }	
    }	
    public void Dispose()	
    {	
        // Fechar o navegador	
        _driver.Quit();	
        _driver.Dispose();	
        // Escrever o relatório
        _extent.Flush();	
    }	
}