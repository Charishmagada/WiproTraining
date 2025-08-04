select * from employee

declare
	@name varchar(30)
	set @name='Uday'
	print 'name is '+@name

SELECT COUNT(*) FROM emp	--Simple output / result checking
SELECT @count = COUNT(*) ... + PRINT	--Logic, conditions, reuse, logging

select count(*) from employee
 
DECLARE @count INT
SELECT @count = COUNT(*) FROM Employee
PRINT 'Total No.of Records are ' + CONVERT(VARCHAR, @count)

--PRINT 'Total No.of Records are ' + @count
-- Error: "Operand data type int is invalid for add operator"

DECLARE @empCount INT
SELECT @empCount = COUNT(*) FROM employee
IF @empCount > 100
    PRINT 'Large Employee Table'
ELSE
    PRINT 'Table has fewer than 100 employees'
 Print 'Total No.of Records are  ' +convert(varchar,@empcount)

select * from employee where empno=1

declare
    @empno INT,
	@name varchar(30),
	@Gender varchar(10),
	@dept varchar(30),
	@desgn varchar(30),
	@basic numeric(9,2)
BEGIN
	set @empno = 33 
	if Exists(select * from Employee where empno = @empno) 
	BEGIN
		select @name = name, @gender=Gender, @dept = Dept, 
			@Desgn=Desgn, @Basic = Basic
		from EMployee where empno = @empno 
		Print 'Employ Name ' +@name
		Print 'Gender ' +@gender
		Print 'Department ' +@dept 
		Print 'Designation ' +@desgn
		print 'Salary ' +Convert(varchar,@basic)
	END
	ELSE 
	BEGIN	
		PRINT 'Record Not Found...'
	END
END
Declare
   @empno INT,
   @name varchar(30),
   @gender varchar(10),
   @dept varchar(30),
   @desgn varchar(30),
   @basic numeric(9,2)
BEGIN
	select @empno = max(empno) from Employee
	set @empno = @empno + 1
	set @name = 'Arya'
	set @gender = 'MALE'
	set @dept = 'Dotnet'
	set @desgn = 'Manager'
	set @basic = 84823
    Insert into Employee(Empno,Name,Gender,Dept, Desgn,Basic) 
		values(@empno,@name,@Gender,@dept,@desgn,@basic)
	Print 'Employ Record Inserted...'
END

select * from employee