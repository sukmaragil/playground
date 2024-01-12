using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestClass]
public class AlertTest
{
  private IWebDriver driver;

  [TestInitialize]
  public void Setup()
  {
    driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
  }

  [TestCleanup]
  public void TearDown()
  {
    driver.Quit();
  }

  [TestMethod]
  public void TestDismissNormalAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS Alert", alertText);

    alert.Accept();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You successfully clicked an alert", ResultText.Text);
  }

  [TestMethod]
  public void TestAcceptConfirmationAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS Confirm", alertText);

    alert.Accept();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You clicked: Ok", ResultText.Text);
    driver.Quit();
  }

  [TestMethod]
  public void TestDeclineConfirmationAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS Confirm", alertText);

    alert.Dismiss();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You clicked: Cancel", ResultText.Text);
    driver.Quit();
  }

  [TestMethod]
  public void TestSendTextAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS prompt", alertText);

    alert.SendKeys("Text alert");
    alert.Accept();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You entered: Text alert", ResultText.Text);
    driver.Quit();
  }

  [TestMethod]
  public void TestEmptySendTextAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS prompt", alertText);

    alert.SendKeys("");
    alert.Accept();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You entered:", ResultText.Text);
    driver.Quit();
  }

  [TestMethod]
  public void TestCancelSendTextAlert()
  {
    // click button trigger alert
    driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button")).Click();

    IAlert alert = driver.SwitchTo().Alert();
    // Wait for the alert to be present
    string alertText = alert.Text;
    Console.WriteLine($"Alert Text: {alertText}");
    Assert.AreEqual("I am a JS prompt", alertText);

    alert.SendKeys("");
    alert.Dismiss();
    // check status alert is successfully clicked
    IWebElement ResultText = driver.FindElement(By.Id("result"));

    Assert.AreEqual("You entered: null", ResultText.Text);
    driver.Quit();
  }
}