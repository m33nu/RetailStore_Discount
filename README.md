# RetailStore_Discount
#About

Program to find net payable amount from given bill

Input Files: 

Github Location:  ..\RetailStore\RetailStore\bin\Release

Customer_Details.txt : 

Stores the customer data which includes the following:
1.	CustomerID
2.	CustomerName
3.	Customer joining date(DD MM YYYY)
4.	Customer Status: 0/1/2 (Employee/Affiliate/Normal User)

File is already filled with 4 customers(Additional customer data can be added)
(CustomerID:1. Employee, CustomerID:2 Affiliate, CustomerID:3 Customer(>2yrs), CustomerID:4. Customer(<2yrs))

Bill_Details.txt : 

Takes the input bill details which includes the following:
1.	Bill Number
2.	CustomerID ( as defined in customer database file Customer_Details.txt	)
3.	Bill Date(DD MM YYYY) (to calculate the number loyalty years)
4.	Total Cost
5.	Grocery Cost

File is already filled with 1 sample input. The programs accepts one bill at a time. After every run, the input can be altered. Just change the customer id value after every run.

TestCase1: CustomerID:1   (Employee)

Testcase2: CustomerID:2  (Affiliate)

Testcase3: CustomerID:3  (Customer with  >2  loyalty years)

Testcase4: CustomerID:4  (Customer with <2loyalty years)

Testcase4:CustomerID:5 (Invalid customer)

Output File:

Github Location:  ..\RetailStore\RetailStore\bin\Release
Outputfile.txt : This file contains the final bill amount is written into this file.

How to execute:
Pre-requisite: .Net Version 4.5
1.	Download the project from github. The project is a console application.
2.	Navigate to \RetailStore\RetailStore\bin\Release
3.	Set the input files as mentioned above: Customer_Details.txt & Bill_Details.txt
4.	Double click on the .exe file – RetailStore
5.	Once the execution is completed the output can be viewed in Outpufile.txt
