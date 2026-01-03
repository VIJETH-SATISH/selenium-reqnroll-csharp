Feature: Google Search

@smoke
Scenario: Open Google homepage
  Given I open the Google homepage
  Then the page title should contain "House MD"

@smoke
Scenario: Search for a term Dr Cameroon
  Given I open the Google homepage
  Then the page title should contain "Dr Cameroon Alison"
