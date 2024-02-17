select * from Products

select ProductID, UnitPrice, 2*UnitPrice from Products

/* Alias :temporary names given to the column 
Can write the alias name in doube inverted commas, single inverted commas,or even without commas

If we do not assign any alias, then it displays "(No column name)"
*/
select ProductID, UnitPrice,(UnitPrice*0.10) discountAmt, UnitPrice-(UnitPrice*0.10)finalAmt from Products

-- Why temporay? If someone else writes this query, he can name it differently
select ProductID, UnitPrice,(UnitPrice*0.10) discountFig, UnitPrice-(UnitPrice*0.10)SellingPriceAfterDiscount from Products


----------------------------------------------------------------------------
/*
Comparison of NULL is not allowed with following operators: 
Null cannot be compared with >,<,>=,<=, !=, =. These opeartors are applied with numbers

To comapre NULL we use "is null" or "is not null" operator
*/

select * from Customers
where Region = null

select * from Customers
where Region is null

select * from Customers
where Region is not null

select ProductID, UnitPrice,(UnitPrice*0.10) discountFig, UnitPrice-(UnitPrice*0.10)SellingPriceAfterDiscount from Products
where UnitPrice>10

----------------------------------------------------------------------------------
/*
ISNULL() function is used to replace NULL values with a specified replacement value. 

Syntax: ISNULL(expression, replacement_value)
	Expression: This is the expression or column you want to check for NULL values.

	Replacement Value: This is the value that will be returned if the expression evaluates to NULL.
*/
select CustomerID, region,isnull(region, 'Absent') from Customers

select * from Suppliers
-- using as keyword and trying different ways to write aliases:
select SupplierID, CompanyName,City, ISNULL(HomePage, 'Cannot Find') as HomePage from Suppliers

--select SupplierID, CompanyName,City, ISNULL(HomePage, 'Cannot Find')"HomePage" from Suppliers

--select SupplierID, CompanyName,City, ISNULL(HomePage, 'Cannot Find')'HomePage' from Suppliers

-------------------------------------------------------------------------------

/* TOP Clause & order by clause
When you use TOP in a query, it instructs the database to return only a specified number of rows that meet the query criteria. 

Used for TOP N Analysis:
*/
select top 10 SupplierID, CompanyName from Suppliers

select top 10 ProductID, ProductName from Products

select ProductID, ProductName from Products
order by ProductName 

select top 10 ProductID, ProductName from Products

-- There is nothing called as BOTTOM 10, so we can use order by descending order to get the bottom values 
select ProductID, ProductName from Products
order by ProductName desc

select top 10 ProductID, ProductName from Products
order by ProductName desc

select top 10 ProductID, UnitPrice from Products
order by UnitPrice asc

select ProductID, UnitPrice from Products
order by UnitPrice asc



