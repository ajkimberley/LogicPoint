#
#	Behavioural specification of a Propositional Grammar Syntax-Checker
#
Feature: Propositional Grammar Syntax-Checker
	As a logic student
	I want to be able to pass in strings into the application and
	have the grammatical category of that string/character returned
	In order to help me learn the grammar of the propositional calculus.

#
# Terminal Categories
#
Background: 
	Given a propositional grammar parser

Scenario Outline: Basic Grammatical Categories
	When I enter the expression <expression>
	Then I should have a <grammatical category>

	Examples: 
		| expression | grammatical category	  |
		| 'P'        | 'Atomic Variable'      |
		| '&'        | 'Binary Connective'    |
		| '~'        | 'Unary Connective'     |
		| '('        | 'Left Bracket'         |
		| ')'        | 'Right Bracket'        |

#
# Well-Formed Formulas
#
Scenario Outline: Well-Formed Formulas
	When I enter the expression <expression>
	Then I have a well-formed formula
	
	Scenarios:
		| expression            |
		| 'P'                   |
		| 'P & Q'               |
		| '(P & Q)              |
		| 'P -> (P V Q)         |
		| '(P & Q) V R'         |
		| '(P & Q) V (R & Q)    |
		| '((Q -> (R V P)) & P) |

#
# Invalid Characters
#
Scenario Outline: Ungrammatical Characters
	When I enter the expression <expression>
	Then I should have an invalid character

	Scenarios: 
		| expression |
		| 'x'        |
		| 'a'        |
		| '@'        |
		| '#'        |
		| ';'        |


#
# Ill-Formed Formulas
#
Scenario Outline: Ill-Formed Formulas
	When I enter the expression <expression>
	Then I should have an ill-formed formula

	Scenarios: 
		| expression      |
		| 'PP'            |
		| 'PQP'           |
		| 'P &'           |
		| 'P & Q P'       |
		| 'P & Q & P'     |
		| '(P & Q'        |
		| '(P & Q))       |
		| '((P & Q)       |
		| '((P -> Q) ^ R' |