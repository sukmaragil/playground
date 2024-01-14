using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class ComputerDatabaseTests
{
  private IWebDriver driver;
  private ComputerDatabasePage computerDatabasePage;
  private AddComputerPage addComputerPage;

  [TestInitialize]
  public void Setup()
  {
    driver = new ChromeDriver();
    computerDatabasePage = new ComputerDatabasePage(driver);
    addComputerPage = new AddComputerPage(driver);
  }

  [TestCleanup]
  public void TearDown()
  {
    driver.Quit();
  }

  [TestMethod]
  public void AddComputerTest()
  {
    computerDatabasePage.Open();
    // check correct website accessed
    // Navigate to add computer
    computerDatabasePage.AddComputerButton.Click();
    Assert.AreEqual("Computers database", driver.Title);

    // Add new computer data
    addComputerPage.ComputerNameField.SendKeys("Sukma PC");
    addComputerPage.IntroducedDateField.SendKeys("2024-01-01");
    addComputerPage.DiscontinuedDateField.SendKeys("2024-01-12");
    addComputerPage.SelectCompany("ASUS");

    addComputerPage.CreateButton.Click();
    // Assert successfully add data
    Assert.AreEqual("Done ! Computer Sukma PC has been created", computerDatabasePage.AlertMessage.Text);
  }

  [TestMethod]
  public void SearchComputerByName() {
    computerDatabasePage.Open();

    computerDatabasePage.SearchBox.SendKeys("ASCI");
    computerDatabasePage.SearchButton.Click();
    Thread.Sleep(1000);

    Assert.IsTrue(computerDatabasePage.FirstCellData.Text.Contains("ASCI"));
  }

}