
if exists(select * from sysobjects where name='prcEmpOut') 
Drop Proc prcEmpOut
GO

Create proc prcEmpOut
				@empno INT,
				@name varchar(30) OUTPUT,
				@gender varchar(30) OUTPUT,
				@dept varchar(30) OUTPUT,
				@desgn varchar(30) OUTPUT,
				@basic numeric(9,2) OUTPUT
AS
BEGIN
	if exists(select * from Employee where empno = @empno) 
	BEGIN
		select @name=name, @gender = Gender, @dept = Dept,
				@desgn = Desgn, @basic = Basic 
		from Employee WHERE Empno = @empno
		RETURN 1
	END
	RETURN 0
END

if exists(select * from sysobjects where name='prcEmpOutExec') 
Drop Proc prcEmpOutExec
GO

Create Proc prcEmpOutExec
					@empno INT
AS
BEGIN
	declare 
		@ret INT,
		@name varchar(30),
		@gender varchar(10),
		@dept varchar(30),
		@desgn varchar(30),
		@basic numeric(9,2)
		Exec @ret = prcEmpOut @empno, @name OUTPUT, @Gender OUTPUT, @Dept OUTPUT, @Desgn OUTPUT,
				@BAsic OUTPUT 
		if @ret = 1
		BEGIN
			print 'Name ' +@name 
			Print 'Gender ' +@gender
			Print 'Department ' +@dept
			Print 'Designation ' +@desgn 
			Print 'Basic ' +convert(varchar,@basic)
		END
		ELSE 
		BEGIN
			Print 'Employ Record Not Found'
		END
END
GO
Exec prcEmpOutExec 1 

--- 
if exists(select * from sysobjects where name='prcEmpAutoGen') 
Drop Proc prcEmpAutoGen
GO

create  procedure prcEmpAutoGen
			@empno INT OUTPUT
AS
BEGIN
	select @empno = 
		case when max(empno) IS NULL THEN 1 else max(empno)+1 END from Employee 

END
GO

if exists(select * from sysobjects where name='PrcEmpInsert') 
Drop Proc PrcEmpInsert
GO

Create proc PrcEmpInsert
			@name varchar(30),
			@gender varchar(10),
			@dept varchar(30),
			@desgn varchar(30),
			@basic numeric(9,2)
AS
BEGIN
	Declare
		@empno INT 
	BEGIN
		Exec prcEmpAutoGen @empno OUTPUT 
		Insert into Employee(Empno,Name,Gender,Dept,Desgn,Basic) values(@empno,@name,@gender,
				@dept,@desgn,@basic)
		Print 'Employ Record Inserted'
	END
END
GO

Exec PrcEmpInsert 'Vasim','MALE','Dotnet','Manager',88233 
GO

select * from Employee 
GO