using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AddComputerPage
{
  private IWebDriver driver;

  public AddComputerPage(IWebDriver driver)
  {
    this.driver = driver;
  }

  public IWebElement ComputerNameField => driver.FindElement(By.Id("name"));
  public IWebElement IntroducedDateField => driver.FindElement(By.Id("introduced"));
  public IWebElement DiscontinuedDateField => driver.FindElement(By.Id("discontinued"));
  public IWebElement CompanyDropdown => driver.FindElement(By.Id("company"));

  public void SelectCompany(string companyName)
    {
        SelectElement select = new SelectElement(CompanyDropdown);
        select.SelectByText(companyName);
    }
  public IWebElement CreateButton => driver.FindElement(By.CssSelector("input[type='submit']"));
}