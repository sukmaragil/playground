using OpenQA.Selenium;

public class ComputerDatabasePage
{
  private IWebDriver driver;

  public ComputerDatabasePage(IWebDriver driver)
  {
    this.driver = driver;
  }

  public IWebElement PageHeaders => driver.FindElement(By.XPath("/html/body/header/h1/a"));
  public IWebElement AlertMessage => driver.FindElement(By.XPath("//*[@id='main']/div[1]"));
  public IWebElement AddComputerButton => driver.FindElement(By.Id("add"));
  public IWebElement SearchBox => driver.FindElement(By.Id("searchbox"));
  public IWebElement SearchButton => driver.FindElement(By.Id("searchsubmit"));
  public IWebElement FirstCellData => driver.FindElement(By.XPath("//*[@id='main']/table/tbody/tr[1]/td[1]/a"));

  public void Open()
  {
    driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
  }

  public void NavigateToAddNewComputer()
  {
    AddComputerButton.Click();
  }

  public void OpenAddNewPage()
  {
    driver.Navigate().GoToUrl("https://computer-database.gatling.io/computers/new");
  }

  // Add more methods for interacting with the web elements as needed
}
