create view Example1
as
select * from employee
go

select * from Example1
go

create view EmployeeReport
AS
	select Empno, Name, Gender, Dept, Basic, dbo.Fncommission(Basic) 'Commission',
			Basic - dbo.Fncommission(Basic) 'Take Home' from Employee
GO

select * from EmployeeReport 
GO

create view ViewAgentPolicy 
AS
select 
	A.AgentId, FirstName, LastName, City, State,
	P.PolicyId, AppNumber, AppDate, ModalPremium, AnnualPremium
from Agent A INNER JOIN AgentPolicy AP
ON A.AgentId = AP.AgentID 
INNER JOIN Policy P 
ON P.PolicyId = AP.PolicyID
GO

select * from ViewAgentPolicy 
GO
