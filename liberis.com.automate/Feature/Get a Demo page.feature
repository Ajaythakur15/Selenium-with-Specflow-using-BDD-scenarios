Feature: libris
	Open ‘Get a Demo’ page

@smoke
Scenario: Verify user has landed on Partner Selection page and it has the required 3 Types of Partners
    #Steps
	Given I launch the application
	When I press the Get a Demo button
	Then It should be navigate to Partner Selection page
	Then Partner Selection page has the required 3 Types of Partner

@smoke
Scenario: Verify validation message when user does not make a partner selection and click ‘Get a demo’
#Steps
    Given I launch the application
	When I press the Get a Demo button
	Then It should be navigate to Partner Selection page
	Then I should validate the message when user does not make a partner selection and click ‘Get a demo’ button
	Then I press the radio button
	Then I press the Get a Demo button on partner page after select

@smoke
Scenario Outline: Execute application in two urls
#Steps
    Given I launch the application with <url>
	When I press the Get a Demo button
	Then It should be navigate to Partner Selection page
	Then I should validate the message when user does not make a partner selection and click ‘Get a demo’ button
	Then I press the radio button
	Then I press the Get a Demo button on partner page after select

	Examples: 
	| url |
	|  https://www.liberis.com/ 
	|  https://www.liberis.com/become-a-partner   |

