------Functions(user defined functions).For system define functions you can refer to day_11 github)
--2 types: scalar valued functions,table valued functions
--examples for scalar valued functions
Create function EvenOdd(@n int)returns varchar(30)
as
begin
	if(@n%2=0)
		begin
		return 'even number'
		end
	else
		begin
		return 'odd number'
		end
	return ' '
end
go

select dbo.EvenOdd(2)
select dbo.EvenOdd(5)

-- to return 10% commission from employee table
use wiprojuly
go
select * from employee
go

Create Function Fncommission(@basic INT) RETURNS Numeric(9,2)
AS
BEGIN
	RETURN @basic * 0.1
END
GO
select dbo.Fncommission(10000);
select Empno, Name, Gender, Dept, Basic, dbo.Fncommission(Basic) 'Commission',
			Basic - dbo.Fncommission(Basic) 'Take Home'
from Employee 
GO

select * from Agent
GO
-- below both ways ok for scalar udf(user define functions)
create function fnAgentMStat(@maritalStatus INT) RETURNS Varchar(30)
AS
BEGIN
	declare
		@res varchar(30)
	if @maritalStatus = 0
	BEGIN
		set @res = 'Unmarried'
	end  
	if @maritalStatus = 1 
	BEGIN
		set @res = 'Married'
	END
	return @res 
END
GO

create function fnAgentMStat1(@maritalStatus INT) RETURNS Varchar(30)
AS
BEGIN
	if @maritalStatus = 0
	BEGIN
		return 'Unmarried'
	end  
	if @maritalStatus = 1 
	BEGIN
		return 'Married'
	END
	return ' '
END
GO
select dbo.fnAgentMStat(0)
select dbo.fnAgentMStat1(1)

select AgentId, FirstName, LastName, City, MaritalStatus, dbo.fnAgentMStat(MaritalStatus)
from Agent 
GO

select * from policy
go

Create Function fnPaymode(@paymode INT) RETURNS varchar(30)
AS
BEGIN
	if @paymode = 1 
		return 'Yearly'
	if @paymode = 2
		return 'half yearly'
	return ' '
end
go
select PolicyId, AppNumber, AppDate, PaymentModeId, dbo.fnPaymode(PaymentModeId)
from Policy
GO