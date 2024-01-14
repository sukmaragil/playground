## Selenium using C#

### Setup automation in VS CODE

1. install latest dotnet version from [here](https://dotnet.microsoft.com/en-us/download)
2. Install [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) and [Nuget package manager](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager) extensions into VS Code
3. Download this repo and navigate to selenium-c#/HelloTest for specific test using Selenium and C#
4. Install Selenium chrome driver, make sure already have (Chrome)
    - Press “Cmd+Shift+P” to start Command Palette, type “nuget” and select “NuGet Package Manager: Add Package”
    - search Selenium.WebDriver and select it, choose latest version
5. You can run by click directly Run Test command inside test script

### Test Overview

Target website : http://computer-database.gatling.io/computers

#### Test cases
1. As a user, i can create and submit new computer in to database
2. As a user, i can search computer by its name

Target website : https://the-internet.herokuapp.com/javascript_alerts

#### Test cases
1. Test normal alert and dismiss alert
2. Test confirmation alert and dismiss alert
3. Test prompt alert and dismiss alert