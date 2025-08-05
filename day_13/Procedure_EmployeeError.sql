create table EmployeePrc
(
	eno int primary key,
	name varchar(30),
	gender varchar(10) constraint chk_dummy_gen check(gender in('MALE','FEMALE')),
	salary numeric(9,2) constraint chk_dummy_sal check(salary between 10000 and 80000)
)
go
--system generated errors
if exists(select * from sysobjects where name='prcEmpIns') 
drop proc prcEmpIns
go

create proc PrcEmpIns
		@eno int,
		@name varchar(30),
		@gender varchar(10),
		@salary numeric(9,2)
as
begin
	declare @erno int
	begin try
		insert into EmployeePrc values(@eno,@name,@gender,@salary)
	end try
	begin catch
		select @erno=Error_number()
		print 'error number '+convert(varchar,@erno)
		print error_message()
		print error_severity()
		print error_line()
	end catch
end
go

select * from EmployeePrc
Exec PrcEmpIns 1,'Arya','MALE',80000
GO
--creating custom error message above we will have system generated
if exists(select * from sysobjects where name='prcEmpRaise') 
drop proc prcEmpRaise
go

Create Proc PrcEmpRaise
				@eno INT,
				@name varchar(30),
				@gender varchar(30),
				@salary numeric(9,2)
AS
BEGIN
	  Declare 
		@erNo INT
		BEGIN TRY
		Insert into EmployeePrc values(@eno,@name,@gender,@salary)
	END TRY
	BEGIN CATCH
		RAISERROR('Error Occurred In Constraints please check table Definition',16,3)
		/*severity:
			11 to 16: Errors caused by the user that can be fixed.
			17 to 25 :More serious; require admin intervention or terminate the connection.
			state: Can be any number from 1 to 255, used for debugging*/

	END CATCH
END
GO

Exec PrcEmpRaise 3,'Venkata','MALE',90000
GO

-- error raised based on total number of records effected
if exists(select * from sysobjects where name='prcEmpMult') 
drop proc prcEmpMult
go

Create Proc PrcEmpMult
				@eno INT,
				@name varchar(30),
				@gender varchar(30),
				@salary numeric(9,2)
AS
BEGIN
	  Declare @erNo INT
		BEGIN TRAN T1
		BEGIN TRY
		Insert into EmployeePrc values(@eno,@name,@gender,@salary)
		Update EmployeePrc set Salary = Salary + 10000 where eno = @eno 
		Print @@TranCount
		if @@TRANCOUNT > 2
		BEGIN
			Print 'Both Transactions are committed'
			Commit Tran T1
		END
	END TRY
	BEGIN CATCH
		PRINT @@TRANCOUNT 
	    if @@TRANCOUNT >= 1 
		BEGIN
			Print 'No Operation Committed'
			Rollback Tran T1
		END		
	END CATCH
END
GO
Exec PrcEmpMult 2911,'Venkata','MALE',78822
GO
select * from EmployeePrc