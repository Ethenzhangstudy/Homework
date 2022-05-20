--Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.

USE NorthwindDB
GO

--1.      Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.

CREATE VIEW view_product_order_Zhang
AS
SELECT p.ProductName, COUNT(od.Quantity) AS TotalQuantity
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName

SELECT *
FROM view_product_order_Zhang

--2.      Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
CREATE PROC sp_product_order_quantity_Zhang
@ProductID INT,
@TotalQuantity SMALLINT OUT
AS
BEGIN
SELECT t.TotalQuantity FROM (SELECT p.ProductID, COUNT(od.Quantity) AS TotalQuantity
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID) t WHERE @ProductID = t.ProductID
END

-- Test follows
BEGIN
DECLARE @TotalQuantity SMALLINT
EXEC sp_product_order_quantity_Zhang 4, @TotalQuantity out
PRINT @TotalQuantity
END

--3.      Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and
-- top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.

CREATE PROC sp_product_order_city_Zhang
@ProductName VARCHAR(40)
AS
BEGIN
SELECT TOP 5 c.City, count(o.OrderID) AS NumOfOrders
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID INNER JOIN Customers c ON c.CustomerID = o.CustomerID 
WHERE p.ProductName = @ProductName
GROUP BY c.City
END

-- Test follows
EXEC sp_product_order_city_Zhang Chai

--4.      Create 2 new tables “people_your_last_name” “city_your_last_name”. 
-- City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
-- People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
-- Remove city of Seattle. 
-- If there was anyone from Seattle, put them into a new city “Madison”. 
-- Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.

CREATE TABLE people_Zhang(
Id int,
City varchar(20))

INSERT INTO people_Zhang VALUES(1, 'Seattle')
INSERT INTO people_Zhang VALUES(2, 'Green Bay')

CREATE TABLE city_Zhang(
Id int,
Name varchar(20),
City int
)

INSERT INTO city_Zhang VALUES(1, 'Aaron Rodgers', 2)
INSERT INTO city_Zhang VALUES(2, 'Russell Wilson', 1)
INSERT INTO city_Zhang VALUES(3, 'Jody Nelson', 2)


DELETE FROM people_Zhang WHERE City = 'Seattle' 

INSERT INTO people_Zhang VALUES(1, 'Madison')


CREATE VIEW Packers_Yixing_Zhang
AS
SELECT cz.Name
FROM people_Zhang pz INNER JOIN city_Zhang cz ON pz.Id = cz.City
WHERE pz.City = 'Green Bay'


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city_Zhang]') AND type in (N'U'))
DROP TABLE [dbo].[city_Zhang]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[people_Zhang]') AND type in (N'U'))
DROP TABLE [dbo].[people_Zhang]
GO

DROP VIEW [dbo].[Packers_Yixing_Zhang]
GO

--5.       Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
CREATE PROC sp_birthday_employees_Zhang
AS
BEGIN
CREATE TABLE birthday_employees_Zhang(
EmployeeName VARCHAR(50))
INSERT INTO birthday_employees_Zhang(EmployeeName) SELECT t.EmployeeNames FROM (SELECT e.FirstName + ' ' + e.LastName AS EmployeeNames
FROM Employees e
WHERE MONTH(e.BirthDate) = 2) AS t
END

EXECUTE sp_birthday_employees_Zhang

SELECT * 
FROM birthday_employees_Zhang

--6.      How do you make sure two tables have the same data?

Step 1: check the lengths of both tables. If they are equal, to Step 2.
Step 2: Using following query
select * From Table1
union
select * From Table2
If the length of the result is equal to the length of Table1 or Table2, then Table1 and Table2 have the same data. 
