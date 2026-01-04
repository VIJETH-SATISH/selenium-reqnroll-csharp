Feature: Sauce Demo Secret Login Demo

@secretlogin
Scenario: Login into the page with secret credentials
  Given I open the Sauce Demo login page
  When I login with secret credentials
  