﻿Feature: Course Equipment
	As a department chair
	I want to track the equipment required to properly teach a course

@domain
Scenario: Add required instructor equipment for course
	Given I have set up a course
	When I require 1 "whiteboard" for the course
	Then 1 "whiteboard" is required for the course, for a total of 1
	And it does nothing else

@domain
Scenario: Add required student equipement for course
	Given I have set up a course
	When I require 1 "PC" per student for the course
	Then 1 "PC" per student is required for the course
	And it does nothing else

@domain
Scenario: Add required shared student equipement for course
	Given I have set up a course
	When I require 1 "lab sink" per 2 students for the course
	Then 1 "lab sink" per 2 students is required for the course
	And it does nothing else

@domain
Scenario: Remove required instructor equipment for course
	Given I have set up a course
	And I require 1 "whiteboard" for the course 
	When I no longer require 1 "whiteboard" for the course
	Then 1 "whiteboard" is no longer required for the course, for a total of 0
	And it does nothing else

@domain
Scenario: Remove required student equipement for course
	Given I have set up a course
	When I no longer require 1 "PC" per student for the course
	Then 1 "PC" per student is no longer required for the course
	And it does nothing else

@domain
Scenario: Remove required shared student equipement for course
	Given I have set up a course
	When I no longer require 1 "lab sink" per 2 students for the course
	Then 1 "lab sink" per 2 students is no longer required for the course
	And it does nothing else

@domain
Scenario: Add additional student equipment
	Given I have set up a course
	And I require 1 "PC" per 2 students for the course
	When I require 1 "PC" per student for the course
	Then 1 "PC" per student is required for the course
	And it does nothing else

@domain
Scenario: Add additional instructor equipment
	Given I have set up a course
	And I require 1 "PC" for the course
	When I require 2 "PC" for the course
	Then 2 "PC" is required for the course, for a total of 3
	And it does nothing else

@domain
Scenario: Instructor equipment doesnt affect student equipment
	Given I have set up a course
	And I require 1 "PC" per student for the course
	When I require 1 "PC" for the course
	Then 1 "PC" is required for the course, for a total of 1
	And it does nothing else
