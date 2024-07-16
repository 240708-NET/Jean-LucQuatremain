-- SQL Notes

-- Comments in SQL are noted with a "--"
/* 
    multi-line comments are a thing as well
    see?
*/

-- DDL - Data Definition - Creating and modifying the structure of the data/tables/database
-- DQL - Data Query - Retreiving the data in interesting ways
-- DML - Data Manipulation - Creating and modifying the data inside the established structure
-- DCL - Data Control - Access control, and server administration

-- DQL - 
--  SELECT - sorting, filtering, and gathering data from tables within the database - Select ALWAYS returns tables

USE MyDatabase;
GO

SELECT 2; -- Select always returns a table
SELECT 2 + 2; -- The server can be pretty powerful
SELECT SYSUTCDATETIME(); -- can respond to requests with computation or calculation
select 'this is a string'; -- capitalization of keywords is a good idea but not strictly enforced

SELECT * FROM [MyDatabase].[dbo].[Artist]; -- Use SELECT to specify that we want a response, and using FROM to specify where we want the data gathered from

-- Get all of the entries from the customer table, from the dbo schema, from the MyDatabase database
SELECT * FROM [MyDatabase].[dbo].[Customer];

-- Gather fewer columns from the Customer Table?
-- Don't use the *, or use WHERE
SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer];
SELECT LastName, FirstName FROM [MyDatabase].[dbo].[Customer];
SELECT LastName + ', ' + FirstName AS CustomerName FROM [MyDatabase].[dbo].[Customer];
-- Concatenate and Alias

-- Using WHERE to filter a response
SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer] WHERE LastName = 'Smith';
SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer] WHERE Country = 'Canada' AND City = 'Vancouver';
SELECT FirstName, LastName FROM [MyDatabase].[dbo].[Customer] WHERE Country = 'Canada' OR Country = 'France';


SELECT LastName + ', ' + FirstName AS CustomerName 
    FROM [MyDatabase].[dbo].[Customer] 
    WHERE Country = 'Canada' 
        OR Country = 'France'; -- SQL is not indent or whitespace sensitive, but it looks good!

-- Aggregate functions - accepts a parameter (the thing it's going to need) returns a Scalar value (just the one, not many rows and columns)
SELECT COUNT(*)
    FROM [MyDatabase].[dbo].[Customer];

SELECT SUM(Total)
    FROM [MyDatabase].[dbo].[Invoice];

SELECT CustomerId, Count(Total) 
    FROM [MyDatabase].[dbo].[Invoice]
    GROUP BY CustomerId;

SELECT CustomerId, Sum(Total) AS Sum_Total
    FROM [MyDatabase].[dbo].[Invoice]
    WHERE BillingCountry = 'USA'
    GROUP BY CustomerId
    HAVING SUM(Total) > 40
    ORDER BY Sum_Total DESC, CustomerId;

/*
Logical order of operations:

- FROM
- WHERE
- GROUP BY
- HAVING
- SELECT
- ORDER BY
*/