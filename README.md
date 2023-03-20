# bitcoin-transactions-BE
Team members
------------

Ueda Shehu
Gerta Duka
Klarisa Gjoka
Altea Maloku

Team leader
-----------

Ueda Shehu

Distribution of main roles and tasks
------------------------------------

Ueda Shehu - Sharing responsibilities within the team, make code review, work on Frontend part
Gerta Duka - Work on backend part, user authentication
Klarisa Gjoka - Crypto APIs research and analysis, work with Gerta to develop backend, Database schema (if needed) and setup
Altea Maloku - Check on best practices of designs, UI/UX, work together with Ueda to implement the frontend

Each of the team members have to work on documenting their respective development. Ueda as a team leader, makes a complete review of it.

Project description
-------------------

Goal

Create an app that helps to increase the productivity of end users of cryptocurrencies, financial institutions for the declaration of personal income or other stakeholders.

Objectives

 - Create frontend part of the app based on the requirements
 - Create backend part of the app based on the analysis of CoinAPI APIs
 - Integrate and analyse the available APIs related to cryptocurrency such as CoinAPI
 - Document the software engineering process
 
Description

This RESTful API software architecture integration application is implemented using
Angular 12 and .NET Core technologies. Reads data from CoinApi Marketplace through endpoints
that this API offers such as exchange rates, orders, sales, asset symbols of these currencies.
A user must successfully register and log in to access other interfaces. The user
has profile, where he modifies his data. There are two user roles: administrator and simple.
Admin view user list, delete/modify CoinApi key to authorize requests
in this API. It has a main home page, which has clickable images that redirect to the interfaces
application by facilitating the user experience. Application security is achieved through hashing
password, but also JWT generation with some user data. We use JWT for that
authorized almost any request in the backend part.
