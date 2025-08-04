------------ PROCEDURES(can use proc or procedure for create,alter,drop etc)

if exists(select * from sysobjects where name='procedure1')
drop proc procedure1 
go

create procedure procedure1
as
begin
	print 'hello,welcome to t-sql'
end
go

exec procedure1
go

-- to search

if exists(select * from sysobjects where name='prcEmpSearch')
drop proc prcEmpSearch
go

create proc prcEmpSearch
@empno int
as
BEGIN
declare @name varchar(30),
	@gender varchar(10),
	@dept varchar(20),
	@desgn varchar(20),
	@basic numeric(9,2)
	IF EXISTS (SELECT * FROM Employee WHERE empno = @empno) 
    BEGIN
        SELECT @name = Name, @gender = Gender, 
               @dept = Dept, @desgn = Desgn,
               @basic = Basic 
        FROM Employee 
        WHERE Empno = @empno

        PRINT 'Employ Name ' + @name 
        PRINT 'Gender ' + @gender 
        PRINT 'Department ' + @dept 
        PRINT 'Designation ' + @desgn 
        PRINT 'Basic ' + CONVERT(VARCHAR, @basic)
    END
    ELSE
    BEGIN
        PRINT 'Record Not Found...'
    END
END
GO
 exec prcEmpSearch 1

 sp_helptext prcEmp

 --insert values
 if exists(select * from sysobjects where name='prcEmpInsert')
 drop proc prcEmpInsert;
 go

 create proc prcEmpInsert
		@Name varchar(30),
		@gender varchar(10),
		@dept varchar(30),
		@desgn varchar(30),
		@basic Numeric(9,2)
AS
begin
declare @empno int
		begin
			select @empno= case when max(empno) is NULL THEN 1 else 
			max(empno)+1 END from Employee
			Insert into Employee(empno,Name,Gender,Dept,Desgn,Basic) 
			values(@empno,@name,@gender,@dept,@desgn,@basic) 
			Print 'Employ Record Inserted';
		end
end
go

Exec PrcEmpInsert 'Madhu','Male','Dotnet','Expert',88323 
GO
select * from employee;