using System;	
using Xunit;	
using OpenQA.Selenium;	
using OpenQA.Selenium.Chrome;	
using OpenQA.Selenium.Support.UI;	
using SeleniumExtras.WaitHelpers;	
namespace SeleniumExamples	
{	
public class GoogleCelsiusToFahrenheitTest : IDisposable	
{	
IWebDriver driver;	
WebDriverWait wait;	
public GoogleCelsiusToFahrenheitTest()	
{	
driver = new ChromeDriver();	
driver.Manage().Window.Maximize();	
wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));	
}	
[Fact]	
public void TestCelsiusToFahrenheitConversion()	
{	
try	
{	
// Navegar para a página de pesquisa do Google
driver.Navigate().GoToUrl("https://www.google.com/search?q=celsius+to+fahrenheit&oq=celsius+to+&gs_lcrp=EgZjaHJvbWUqCQgAEEUYOxiABDIJCAAQRRg7GIAEMgYIARBFGDkyBwgCEAAYgAQyBwgDEAAYgAQyBwgEEAAYgAQyBwgFEAAYgAQyBwgGEAAYgAQyBggHEEUYPNIBCDIwMzRqMGo3qAIIsAIB&sourceid=chrome&ie=UTF-8");	
// Localizar o campo de entrada Celsius usando o atributo apropriado	
IWebElement celsiusInputField =
wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@jsname='axsL6b']")));	
// Inserir um valor no campo Celsius	
celsiusInputField.Clear();	
celsiusInputField.SendKeys("100");	
// Localizar o campo de resultado Fahrenheit usando o atributo apropriado	
IWebElement fahrenheitResultField =
wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@jsname='fPLMtf']")));	
// Verificar o resultado Fahrenheit
string result = fahrenheitResultField.GetAttribute("value");	
Assert.Equal("212", result);	
}	
catch (NoSuchElementException e)	
{	
Console.WriteLine("Elemento não encontrado: " + e.Message);
throw;	
}	
catch (WebDriverException e)	
{	
Console.WriteLine("Erro no WebDriver: " + e.Message);	
throw;	
}	
catch (Exception e)	
{	
Console.WriteLine("Erro inesperado: " + e.Message);	
throw;	
}	
}	
public void Dispose()	
{	
driver.Quit();	
}	
}	
}