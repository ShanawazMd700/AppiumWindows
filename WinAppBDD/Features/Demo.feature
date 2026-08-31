Feature: Demo Feature

Simple calculator for adding two numbers

Background: 
When I Kill all the existing programs

@trialsteps
Scenario: Lauching FSW
	Given Launching "SmartFit" in the system
	When Add or Select Patients is clicked
	

Scenario: Launching FDTS
	Given Launching "FDTS" in the system
	When The product "VI960S-DRWC" is selected
	

Scenario: Launching NOAH
	Given Launching "NOAH" in the system
	#When The login password to NOAH "123" is entered
	When I click OK button in NOAH


Scenario: Changing the target rule in FSW
	Given Click the fitting options on the fine tuning window
	When I select a new target rule
	And I click close button in fitting options window
	
Scenario: Opening the NOAH and drwaing the audiogram
	Given Launching "NOAH" in the system
	When I click OK button in NOAH
	When I add new patient
	And I click on the Audiogram tab
	When I launch FSW "Smart Fit 2.5"
	When I launch in Simulation
	When I select the device "Sensia" and devicename "SN962-DRW" with side "left"
	When I click "Continue" in Physical Properties window
	When I click "Gain Adjustments" in side menu
	When I click "Fine Tuning" in side menu
	When I add Programs "Music" from programs
	When I add Programs "Outdoor" from programs
	Then I exit from FSW 

	

