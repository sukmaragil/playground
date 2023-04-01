*** Settings ***
Documentation  Simple example using AppiumLibrary
Library  AppiumLibrary
Library    XML

*** Variables ***
${ANDROID_AUTOMATION_NAME}    UIAutomator2
${ANDROID_APP}                ${CURDIR}/../demoapp/mydemoapp.apk
${ANDROID_PLATFORM_NAME}      Android
${ANDROID_PLATFORM_VERSION}   %{ANDROID_PLATFORM_VERSION=10}

*** Test Cases ***
Login using valid credential
  Open Test Application
  Navigate to Login Page
  Input Text    accessibility_id=Username input field    bob@example.com
  Input Text    accessibility_id=Password input field    10203040
  Click Element    accessibility_id=Login button
  Navigate to Login Page
  Element Should Be Visible    //android.widget.ScrollView[@content-desc="cart screen"]/android.view.ViewGroup
  Close Application

Logout Application
  Open Test Application
  Navigate to Login Page
  Input Text    accessibility_id=Username input field    bob@example.com
  Input Text    accessibility_id=Password input field    10203040
  Click Element    accessibility_id=Login button
  Navigate to log out
  # Alert confirm logout
  Click Element    id=android:id/button1
  # Alert OK button
  Click Element    id=android:id/button1

Login using invalid credential
  Open Test Application
  Navigate to Login Page
  Input Text    accessibility_id=Username input field    bob@example.com
  Input Text    accessibility_id=Password input field    102030
  Click Element    accessibility_id=Login button
  ${error_message}    Get Element Text    //android.view.ViewGroup[@content-desc="generic-error-message"]/android.widget.TextView
  Should Be Equal    "Provided credentials do not match any user in this service."    ${error_message}

*** Keywords ***
Open Test Application
  Open Application  http://127.0.0.1:4723/wd/hub  automationName=${ANDROID_AUTOMATION_NAME}
  ...  platformName=${ANDROID_PLATFORM_NAME}  platformVersion=${ANDROID_PLATFORM_VERSION}
  ...  app=${ANDROID_APP}  appPackage=com.saucelabs.mydemoapp.rn

Navigate to Login Page
  Click Element    xpath=//android.view.ViewGroup[@content-desc="open menu"]/android.widget.ImageView
  # accessibility id=menu item log in
  Click Element    accessibility_id=menu item log in

Navigate to log out
  Click Element    xpath=//android.view.ViewGroup[@content-desc="open menu"]/android.widget.ImageView
  Click Element    xpath=//android.view.ViewGroup[@content-desc="menu item log out"]