----exercise1
--1:Write a query to Get a List of Employees who have a one part name
SELECT * FROM dbo.tblEmployees
WHERE Name NOT LIKE '% %';


--2:Write a query to Get a List of Employees who have a three part name
SELECT * FROM dbo.tblEmployees
WHERE LEN(Name) - LEN(REPLACE(Name, ' ', '')) = 2; -- it is giving 2 names also because of extra spaces which is not giving 100% accurate so we are using ltrim rtrim.

SELECT * 
FROM dbo.tblEmployees
WHERE LEN(LTRIM(RTRIM(REPLACE(Name, '  ', ' ')))) 
      - LEN(REPLACE(LTRIM(RTRIM(REPLACE(Name, '  ', ' '))), ' ', '')) = 2;


--3:write a query to get a list of Employees who have a First Middle Or last name as Ram, and not any thing else
SELECT * 
FROM dbo.tblEmployees
WHERE 
    (Name = 'Ram') OR
    (Name LIKE 'Ram %' AND LEN(Name) - LEN(REPLACE(Name, ' ', '')) = 1) OR --ram kumar
    (Name LIKE '% Ram' AND LEN(Name) - LEN(REPLACE(Name, ' ', '')) = 1) OR --kumar ram
    (Name LIKE '% Ram %' AND LEN(Name) - LEN(REPLACE(Name, ' ', '')) = 2); --kumar ram singh 
/*since the condn is first middle last only 3 parts of name we are using above..
if we want for any nuber of parts of name we use the below.below one can be used to anyy case.since they specifically mentioned three parts the above one was used.*/

SELECT * 
FROM dbo.tblEmployees
WHERE ' ' + Name + ' ' LIKE '% Ram %'; --ram,ram kumar,kumar ram,kumar ram singh,a b ram d,a ram b d,......


--4
--4.1: 65 OR 11
select emp.EmployeeNumber, emp.Name, emp.CentreCode
from dbo.tblEmployees emp
where emp.CentreCode = 65 or emp.CentreCode = 11;

--4.2: 65 XOR 11
select COUNT(*)
from dbo.tblEmployees emp
where (emp.CategoryCode = 65 and emp.CentreCode <> 11) or ((emp.CategoryCode <> 65 and emp.CentreCode = 11));

--4.3: 65 AND 11
select emp.EmployeeNumber, emp.Name, emp.CentreCode, emp.CategoryCode
from tblEmployees emp
where emp.CategoryCode = 12 and emp.CentreCode = 4;

--4.4: (12 AND 4) OR (13 AND 1)
select emp.EmployeeNumber, emp.Name, emp.CentreCode, emp.CategoryCode
from dbo.tblEmployees emp
where (emp.CategoryCode=12 and emp.CentreCode=4)or (emp.CategoryCode=13 and emp.CentreCode=1);

--4.5: 127 OR 64
select emp.EmployeeNumber, emp.Name
from dbo.tblEmployees emp
where emp.EmployeeNumber = 127 or emp.EmployeeNumber = 64;

--4.6: 127 XOR 64
select emp.EmployeeNumber,emp.Name
from dbo.tblEmployees emp
where (emp.CategoryCode = 127 and emp.CentreCode <> 64) or ((emp.CategoryCode <> 127 and emp.CentreCode = 64));

--4.7: 127 XOR 128
select emp.EmployeeNumber,emp.Name
from dbo.tblEmployees emp
where (emp.CategoryCode = 127 and emp.CentreCode <> 128) or ((emp.CategoryCode <> 127 and emp.CentreCode = 128));

--4.8: 127 AND 64
select emp.EmployeeNumber, emp.Name
from dbo.tblEmployees emp
where emp.EmployeeNumber = 127 and emp.AreaCode = 64;

--4.9: 127 AND 128
select emp.EmployeeNumber, emp.Name
from dbo.tblEmployees emp
where emp.EmployeeNumber = 127 and emp.AreaCode = 128;

--5: Write a query which returns data in all columns from the table dbo.tblCentreMaster
SELECT * FROM dbo.tblCentreMaster;

--6: Write a query which gives employee types in the organization.
SELECT * FROM dbo.tblEmployeeTypes; 

select distinct emp.EmployeeType
from dbo.tblEmployees emp;

/*7: Write a query which returns Name, FatherName, DOB of employees whose PresentBasic is

a. Greater than 3000.

b. Less than 3000.

c. Between 3000 and 5000.*/

SELECT Name, FatherName, DOB 
FROM dbo.tblEmployees
WHERE PresentBasic > 3000;

SELECT Name, FatherName, DOB 
FROM dbo.tblEmployees
WHERE PresentBasic < 3000;

SELECT Name, FatherName, DOB 
FROM dbo.tblEmployees
WHERE PresentBasic BETWEEN 3000 AND 5000;

/* 8. Write a query which returns All the details of employees whose Name

a. Ends with 'KHAN'

b. Starts with 'CHANDRA'

c. Is 'RAMESH' and their initial will be in the rage of alphabets a-t.

EX:If an employee name is T.Ramesh then your query should return his record*/

SELECT * FROM dbo.tblEmployees
WHERE Name LIKE '%KHAN';

SELECT * FROM dbo.tblEmployees
WHERE Name LIKE 'CHANDRA%';

SELECT * FROM dbo.tblEmployees
WHERE Name LIKE '[A-T].RAMESH';












