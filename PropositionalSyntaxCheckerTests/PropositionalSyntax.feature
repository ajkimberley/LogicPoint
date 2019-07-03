#
# Properties of a Propositional Syntax Checker
#


Feature: PropositionalSyntax
	As a undergraduate logic student
	I want to enter propositions
	In order to check if they are well-formed or not

#
# Atomic Propositions
#
@PropositionalSyntax
Scenario: Atomic Proposition P
	Given a logic parser
	When I enter 'P'
	Then I have a well-formed formula



