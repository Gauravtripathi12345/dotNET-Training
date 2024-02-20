/*
-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$--------------------
											Select Query and its clauses:-
-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$-----------------------------------

select [columnname/names] from [table/s]
where [condition]
group by [columnname/s] ===> (something wise: ex: Dept wise)
having [condition/s] ===> filter/condition on aggregated column
order by [columnname/names] ===> ascending/descending 


NOTE: 
1) Whenever it is wise something then we require aggregate function (something that returns a single value. Ex: sum, avg, count) in the select clause of the query.
==> Group by is used only when we have aggregate function in the select clause of the query.

2) To apply condition on aggregated column, we use having

3) To order the data in ascending/descending order, we use order by.

===> Learn by heart these keywords (Select from where group by having order by) <=== */

select * from Customers

--a. using select (someColumnName) from [tableName]
select ContactTitle, CustomerID, CompanyName from Customers
-- The sequence in which the column names are passed, they are represented in the same manner in the output.

--b. using select (someCoulumnName) from [tableName] where (someCondition)
select ContactTitle, CustomerID, CompanyName, Country from Customers
where Country='Germany'

select * from Suppliers

-- Show details of SupplierID 1
select * from Suppliers
where SupplierID=1

-- Show list of Products supplied by SupplierID 1
select * from Products 
where SupplierID=1





-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------
                                         /* Theory of Relation amongst tables*/
-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------

/* 
#### DBMS Concepts:
TableName--> Entity
column ---> attributes
row ----> tuple

##### relation---->relationship between entities:

1) 1-1-------> One customer has only one GST no./ One person has only one aadhar no/one person--one pan_no

a) For 1-1 relationship, primary key (unique + compulsory + not null) in both the columns is important. 
      (Null ---> unknown): It is different from a zero

b) Example for null vs 0: 

		A employee who is salesman is eligible for commision on sales.
		Empno       Ename         Job           Commission
		1			A              Clerk           NULL
		2           B              Salesman         0---------
		3           c            salesman          100

c) Example for Primary Key in both the tables:

	i) Consider a customer table with following attributes
	Customer table
				   cstname   aadharNo (PrimaryKey)
							   123
	==> Every customer will have a aadhar no which is unique to him

	ii) Consider a table with government that has follwoing attributes:
	AadharData table

			regid     aadharno
			  101     123


2) 1-M-------->
	1 Person---M Phone nos
	1 Cart----M Products
	1 Category----M Products
	For example: Dairy Category has Milk, Curd, Cheese etc. as products

a) For 1-M relationship there exists a concept called Foreign Key (referential integrity):

 * Referential integrity: If there is a category, then only there can be a product in that category. It is not unique and can be null.

 * Example:
	 If categoryId for dairy is 1:

			 categoryId(Primary Key)				  category
				1										Dairy

	Then in the products table, whenever I will be writing a productID
      
		  productId		Product   categoryId(Foreign Key)
			  101		 milk			1

	=> If categoryId does not exist in Categort table, then it will not exist in Product Table
	=> In Category table categoryId = PK, but in Product table categoryId = FK.

3) M-N
	1 Person----> M Languages
	M Persons------1 Languages


*/

-- Example for PrimaryKey and FK:=> This concept of PK and FK is used to search faster.
-- 1:M => 1 Category---->M Products
select * from Categories -- categoryId (PK) => unique
select * from Products  -- categoryId (FK) => can be multiple

select * from Products 
where CategoryID=4

/* NOTE: 
When there is 1-M relationship: Include the key attribute (PK) of the table "one" in table "many"

For example:
	1 Supplier----M Products
	The supplierid where it will repeated?--> Products

	Learnings: Include the key attribute (supplierid: PK) of one (Supplier) into (Products).
*/





-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------
                                         /* Stored Procedures */
-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------



/*A stored procedure is a precompiled collection of SQL statements and procedural logic that is stored in the database and can be executed on demand. Stored procedures can accept input parameters, perform operations such as querying or modifying data, and return results to the caller.*/

-- use sp_help [TableName] to know all the details of a table.
sp_help Suppliers
sp_help Products



-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------
                                         /* OR , AND , IN, BETWEEN opeartor */
-------------------------------$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$---------------------------------------------



select * from Customers
-- Find cutomers who are form London or Berlin => "or" operator
select * from Customers
where city = 'London' or City='Berlin'

-- Find cutomers who are form London or Berlin and they must be Sales Representatives ==> "and" operator

select * from Customers
where (city = 'London' or City='Berlin') and ContactTitle='Sales Representative'


/* Practise Problem on OR, AND operator: // Write a query for the following condition:
1) list the data from the products table
2) The supplierid can be 1 or 2 or 3
3) The category id=1
*/
select * from products
where (supplierid=1 or supplierid=2 or supplierid=3) and categoryid=1

/* IN operator: solution to avoid repeating task done using "or" operator*/

select * from products
where supplierid in(1,2,3) and categoryid=1 -- Here comma represents "or"

select * from products
where categoryid=1 and supplierid in(1,2,3) 



/*Working with Dates*/
/* BETWEEN Operator:
It is an inclusive operator (i.e. the values mentioned will also be included) to work with range (range of dates, range of nos)
*/

select * from employees
where HireDate between '1993-10-17' and '1994-01-02'

select * from products
where categoryid=1 and supplierid between 1 and 3 




/*
NOTES:
1) Dates are also treated as Strings
*/
