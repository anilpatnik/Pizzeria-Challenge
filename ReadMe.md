The goal of this exercise is to refactor the code and fix existing bugs. Please refactor the code applying best practices.

Hints:
- _Pizzeria_ will have another location in the future (Gold Coast)
- The menu in every pizzeria is a subject of change
- You cannot order pizzas that are not available in the selected location
- We still improve our baking process, so it will change in the future. The baking process will vary depending on pizza type
- The same pizza is prepared in the same way across all the locations. The only difference is the price
- We love built-in quality in our products

Nice-to-have:
- We would like to add pizza toppings to the menu: extra cheese, mayo, olive oil
- Our customers would like to order more than 1 pizza at a time


We appoint you a manager of this project, so feel free to add more features if you like :)

Anil Patnaik

Refactored the application as follows:
1.	Structured the code to obey SOLID principles
2.	Entity Framework – Used in-memory database for dev execution. This can fulfil the goal of  
	a.	Adding more locations in the future
	b.	Changing menu and price in pizzeria
	c.	Adding more pizza toppings
	d.	Provide baking, cutting instructions for each pizza type
3.	Dependency Injection - For decoupling and testability
4.	Unit Testing – Covered couple of methods only. Can make the code coverage > 90% for product quality
5.  ReSharper – Modern coding standards and practices