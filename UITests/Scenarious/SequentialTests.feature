Feature: SequentialTests
	
Scenario: Task 1 - Validate Black Belt Program file can be successfully downloaded 
	Given User navigates to home page
	And User selects 'Professional Services' option from 'Services' header menu
	And User expands 'Black Belt Program' option from 'Consulting Services' menu on 'Services' page
	When User downloads file for 'Black Belt Program' menu option from 'Professional Services page'
	Then File is successfully downloaded from the page
	And Download folder contains 1 files

Scenario: Task 2 - Validate selected options title matches blog title value
	Given User navigates to home page
	And User selects 'Blog' top header menu option
	When User enters 'Quantum' value into the search field of the blog page
	And User obtains available search drop down options of the blog page
	And User selects first suggestion from search drop down list
	Then The selected option from search list matches blog title