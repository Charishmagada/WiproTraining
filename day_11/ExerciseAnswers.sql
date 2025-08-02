
DROP TABLE IF EXISTS Names;
CREATE TABLE Names (Word VARCHAR(50));
INSERT INTO Names VALUES ('Keerthi');
SELECT 
  LEN(Word) - CHARINDEX('e', REVERSE(Word)) + 1 AS LastPositionOf_e
FROM Names;

DROP TABLE IF EXISTS FullName;
CREATE TABLE FullName (Name VARCHAR(100));
INSERT INTO FullName VALUES ('Venkata Narayana');
SELECT 
  LEFT(Name, CHARINDEX(' ', Name) - 1) AS FirstName,
  RIGHT(Name, LEN(Name) - CHARINDEX(' ', Name)) AS LastName
FROM FullName;

Drop table if exists words;
CREATE TABLE Words (Word1 VARCHAR(50));
INSERT INTO Words VALUES ('missisipi');
SELECT 
  LEN(Word1) - LEN(REPLACE(Word1, 'i', '')) AS CountOf_i
FROM Words;

SELECT EOMONTH(GETDATE(), 1) AS LastDayOfNextMonth;

SELECT 
  DATEFROMPARTS(
    YEAR(DATEADD(MONTH, -1, GETDATE())), 
    MONTH(DATEADD(MONTH, -1, GETDATE())), 
    1
  ) AS FirstDayOfPrevMonth;

  -- Step 1: Use a recursive CTE to generate all days of current month
WITH Calendar AS (
    SELECT CAST(DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AS DATE) AS dt
    UNION ALL
    SELECT DATEADD(DAY, 1, dt)
    FROM Calendar
    WHERE MONTH(dt) = MONTH(GETDATE()) AND dt < EOMONTH(GETDATE())
)

-- Step 2: Filter only Fridays
SELECT dt AS Friday
FROM Calendar
WHERE DATENAME(WEEKDAY, dt) = 'Friday'
OPTION (MAXRECURSION 31);









