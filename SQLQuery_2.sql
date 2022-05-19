USE AdventureWorks2019
GO

SELECT *
FROM person.CountryRegion pc

SELECT *
FROM person.StateProvince ps 

-- 1. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
-- Country Province 
SELECT pc.CountryRegionCode AS Country, ps.StateProvinceCode AS Province
FROM person.CountryRegion pc INNER JOIN person.StateProvince ps ON  pc.CountryRegionCode =  ps.CountryRegionCode

--2. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada.
--Join them and produce a result set similar to the following.
-- Country Province 
SELECT pc.CountryRegionCode AS Country, ps.StateProvinceCode AS Province
FROM person.CountryRegion pc INNER JOIN person.StateProvince ps ON  pc.CountryRegionCode =  ps.CountryRegionCode
WHERE pc.CountryRegionCode IN ('CA', 'DE')


USE NorthwindDB
GO


--3. List all Products that has been sold at least once in last 25 years.
SELECT DISTINCT p.ProductName
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE o.OrderDate > '1997-05-18'

--4. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 o.ShipPostalCode, count(o.OrderID) AS NumOfOrders
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE o.OrderDate > '1997-05-18'
GROUP BY o.ShipPostalCode
ORDER BY NumOfOrders DESC

--5. List all city names and number of customers in that city.  
SELECT c.City, COUNT(c.ContactName) AS NumberofCustomers
FROM Customers c
GROUP BY c.City

--6. List city names which have more than 2 customers, and number of customers in that city
SELECT c.City, COUNT(c.ContactName) AS NumberofCustomers
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.ContactName) > 2

--7. Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, COUNT(od.Quantity) AS NumberofProducts
FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY NumberofProducts DESC

--8. Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID, COUNT(od.Quantity) AS NumberofProducts
FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.Quantity) > 100
ORDER BY NumberofProducts DESC

--9. List all of the possible ways that suppliers can ship their products. Display the results as below
--  Supplier Company Name                Shipping Company Name
SELECT sp.CompanyName AS [Supplier Company Name], o.ShipName AS [Shipping Company Name]
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID INNER JOIN Suppliers sp ON p.SupplierID = sp.SupplierID

--10. Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID 

--11. Displays pairs of employees who have the same job title.
SELECT e1.FirstName  + ' '  + e1.LastName AS employ1, e2.FirstName  + ' '+ e2.LastName AS employ2
FROM Employees e1, Employees e2
WHERE e1.Title = e2.Title AND e1.FirstName  + e1.LastName <>  e2.FirstName + e2.LastName

--12. Display all the Managers who have more than 2 employees reporting to them.
SELECT m.FirstName + ' ' + m.LastName as ManagerName, COUNT(e.FirstName) as NumberofEmployee
FROM Employees e INNER JOIN Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(e.FirstName) > 2

--13. Display the customers and suppliers by city. The results should have the following columns
--City Name, Contact Name, Type (Customer or Supplier)
SELECT c.City, c.ContactName, 'Customer' AS Type
FROM Customers c
UNION 
SELECT sp.City, sp.ContactName, 'Supplier' AS Type
FROM Suppliers sp

--14. List all cities that have both Employees and Customers.
SELECT DISTINCT c.City
FROM Customers c INNER JOIN Employees e ON c.City = e.City

--15 List all cities that have Customers but no Employee.
--a Use sub-query
SELECT DISTINCT c.City
FROM Customers c 
WHERE c.City NOT IN 
(SELECT DISTINCT e.City
FROM Employees e)

--b Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL


--16 List all products and their total order quantities throughout all orders.
SELECT p.ProductName, COUNT(od.Quantity)
FROM Orders o INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID
GROUP BY p.ProductName

--17.  List all Customer Cities that have at least two customers.
--a. Use union
SELECT DISTINCT c1.City, COUNT(c1.ContactName) AS NumberofCustomers
FROM Customers c1
GROUP BY c1.City
HAVING COUNT(c1.ContactName)>=2



--b. Use sub-query and no union
SELECT DISTINCT c1.City
FROM Customers c1
WHERE EXISTS (SELECT 1 FROM Customers c2 WHERE c1.city = c2.city AND c1.ContactName != c2.ContactName)


--18. List all Customer Cities that have ordered at least two different kinds of products.
SELECT DISTINCT c.City, COUNT(od.ProductID) as KindsofProducts
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(od.ProductID) >= 2

--19. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5 p.ProductName, COUNT(od.ProductID) AS NumberofProduct, AVG(od.Quantity * od.UnitPrice) AS AvgRevenuePerCustomer
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID
GROUP BY p.ProductName
ORDER BY COUNT(od.ProductID) DESC


SELECT TOP 1 c.City, COUNT(od.ProductID) AS NumberofProduct
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID
GROUP BY c.City
ORDER BY COUNT(od.ProductID) DESC


--20. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered
--from. (tip: join  sub-query)
SELECT c.City, COUNT(od.ProductID) AS NumberofProduct
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID INNER JOIN [Order Details] od ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID INNER JOIN (SELECT e.City
FROM Orders o INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID) n ON n.City = c.City 
GROUP BY c.City
ORDER BY COUNT(od.ProductID) DESC


--21. How do you remove the duplicates record of a table?
--We can use a common table expression (CTE) to delete duplicate rows.

-- STEP 1: Adding one column to show the DuplicateCount
WITH CTE(COL1, 
    COL2, 
    COL3, 
    duplicatecount)
AS (SELECT COL1, 
    COL2, 
    COL3, 
    ROW_NUMBER() OVER(PARTITION BY COL1, 
    COL2, 
    COL3
    ORDER BY id) AS DuplicateCount
    FROM Table)
SELECT *
FROM CTE;
-- STEP 2 removes the rows having the value of [DuplicateCount] greater than 1
WITH CTE(COL1, 
    COL2, 
    COL3, 
    DuplicateCount)
AS (SELECT COL1, 
    COL2, 
    COL3, 
    ROW_NUMBER() OVER(PARTITION BY COL1, 
    COL2, 
    COL3
    ORDER BY ID) AS DuplicateCount
    FROM TABLE)
DELETE FROM CTE
WHERE DuplicateCount > 1;


