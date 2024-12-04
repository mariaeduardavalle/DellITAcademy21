using System;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
class Program	
{	
    static void Main(string[] args)	
    {	
        // Configurar o ChromeDriver
        IWebDriver driver = new ChromeDriver();	
        try	
        {	
        // Navegar para um site	
        driver.Navigate().GoToUrl("https://www.google.com");	
        // Encontrar um elemento pelo atributo name	
        IWebElement searchBox = driver.FindElement(By.Name("q"));	
        // Realizar ações no elemento (se necessário
        searchBox.SendKeys("Selenium WebDriver");	
        searchBox.SendKeys(Keys.Enter);	
        // Esperar um pouco para ver os resultados	
        System.Threading.Thread.Sleep(3000);	
        // Imprimir o título da págin
        Console.WriteLine("Título da página: " + driver.Title);
        // Fechar o navegador	
        driver.Quit();	
        }	
        catch (Exception e)	
        {	
        Console.WriteLine("Ocorreu um erro: " + e.Message);	
        driver.Quit();	
        }	
    }	
}	
